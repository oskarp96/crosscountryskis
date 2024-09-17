namespace CrossCountrySkis.Models
{
    public class SuggestedSkiLengthResult
    {
        private SkiLengthSpan? _skiLengthSpan;
        public int SkiLength { get; set; }
        public SkiLengthSpan? SkiLengthSpan
        {
            get => _skiLengthSpan;
            set
            {
                if (value is not null && value.LowerSpan == value.UpperSpan)
                {
                    SkiLength = value.LowerSpan;
                    _skiLengthSpan = null;
                }
                else
                {
                    _skiLengthSpan = value;
                }
            }
        }
    }
}
