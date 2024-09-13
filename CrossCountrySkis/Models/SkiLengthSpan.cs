namespace CrossCountrySkis.Models
{
    public class SkiLengthSpan
    {
        public SkiLengthSpan()
        {
            
        }
        public SkiLengthSpan(int lowerSpan, int upperSpan)
        {
            LowerSpan = lowerSpan;
            UpperSpan = upperSpan;
        }

        public int LowerSpan { get; set; }
        public int UpperSpan { get; set; }
    }
}
