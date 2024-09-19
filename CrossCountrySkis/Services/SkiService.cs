using CrossCountrySkis.Models;
using CrossCountrySkis.Services.Interfaces;
using CrossCountrySkis.Models.Enums;

namespace CrossCountrySkis.Services
{
    public class SkiService : ISkiService
    {
        const int MaxClassicSkiLength = 207;
        const int MaxFreestyleSkiLength = 192;

        public SuggestedSkiLengthResult CalculateSkiLength(SkiLengthFormModel formModel)
        {
            return formModel.SkiType == SkiType.Classic ? CalculateClassicLength(formModel) : CalculateFreestyleLength(formModel);
        }

        private SuggestedSkiLengthResult CalculateClassicLength(SkiLengthFormModel formModel)
        {
            var (isChildren0To4, isChildren5To8) = IsWithinChildrenAgeGroup(formModel.Age);
            var suggestedSkiLength = formModel.Length + 20;

            if(isChildren0To4)
            {
                // Use +0cm because it is more strict than the 10-20cm normal span
                return new SuggestedSkiLengthResult { SkiLength = formModel.Length };
            }

            if (isChildren5To8)
            {
                var skiLengthSpan = new SkiLengthSpan(formModel.Length + 10, suggestedSkiLength);

                return new SuggestedSkiLengthResult { SkiLengthSpan = skiLengthSpan };
            }

            if (suggestedSkiLength > MaxClassicSkiLength)
            {
                suggestedSkiLength = MaxClassicSkiLength;
            }

            return new SuggestedSkiLengthResult { SkiLength = suggestedSkiLength };
        }

        private SuggestedSkiLengthResult CalculateFreestyleLength(SkiLengthFormModel formModel)
        {
            var (isChildren0To4, isChildren5To8) = IsWithinChildrenAgeGroup(formModel.Age);
            var skiLengthSpan = new SkiLengthSpan();

            if(isChildren0To4)
            {
                return new SuggestedSkiLengthResult { SkiLength = formModel.Length };
            }

            // Using more specific freestyle span (10-15) because it still fits in the children span (10-20)
            skiLengthSpan.LowerSpan = formModel.Length + 10;
            skiLengthSpan.UpperSpan = formModel.Length + 15;

            if (skiLengthSpan.LowerSpan > MaxFreestyleSkiLength)
            {
                skiLengthSpan.LowerSpan = MaxFreestyleSkiLength;
                // If lower span is exceeded, so is upper span
                skiLengthSpan.UpperSpan = MaxFreestyleSkiLength;
            }
            else if (skiLengthSpan.UpperSpan > MaxFreestyleSkiLength) 
            {
                skiLengthSpan.UpperSpan = MaxFreestyleSkiLength;
            }

            return new SuggestedSkiLengthResult { SkiLengthSpan = skiLengthSpan };
        }

        private (bool IsChildren0To4, bool IsChildren5To8) IsWithinChildrenAgeGroup(int age)
        {
            var isChildren0To4 = age >= 0 && age <= 4;
            var isChildren5To8 = age >= 5 && age <= 8;

            return (isChildren0To4, isChildren5To8);
        }
    }
}
