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
            var suggestChildrenLengthSpan = formModel.Age >= 5 && formModel.Age <= 8;
            var suggestedSkiLength = formModel.Length + 20;

            if (suggestChildrenLengthSpan)
            {
                // Use children 5-8 years span
                // TODO: Make sure span dont exceed maxlength
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
            var suggest0To4LengthSpan = formModel.Age >= 0 && formModel.Age <= 4;
            var suggest5To8LengthSpan = formModel.Age >= 5 && formModel.Age <= 8;
            var skiLengthSpan = new SkiLengthSpan();

            if(suggest0To4LengthSpan)
            {
                return new SuggestedSkiLengthResult { SkiLength = formModel.Length };
            }

            // Using more specific freestyle span (10-15) because it still fits in the children span (10-20)
            // TODO: If span is greater than maxlength, set maxlength instead
            skiLengthSpan.LowerSpan = formModel.Length + 10;
            skiLengthSpan.UpperSpan = formModel.Length + 15;

            return new SuggestedSkiLengthResult { SkiLengthSpan = skiLengthSpan };
        }
    }
}
