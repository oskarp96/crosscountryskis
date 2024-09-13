using CrossCountrySkis.Models;

namespace CrossCountrySkis.Services.Interfaces
{
    public interface ISkiService
    {
        SuggestedSkiLengthResult CalculateSkiLength(SkiLengthFormModel formModel);
    }
}
