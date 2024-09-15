using CrossCountrySkis.Models.Enums;
using CrossCountrySkis.Models;
using CrossCountrySkis.Services;

namespace CrossCountrySkis.Tests.Services
{
    public class SkiServiceTests
    {
        private readonly SkiService _skiService;

        public SkiServiceTests()
        {
            _skiService = new SkiService();
        }

        // Classic type tests

        [Fact]
        public void CalculateSkiLength_ForAdultClassicSkiType_ReturnsCorrectLength()
        {
            // Arrange
            var formModel = new SkiLengthFormModel
            {
                Length = 170,
                Age = 35,
                SkiType = SkiType.Classic
            };

            // Act
            var result = _skiService.CalculateSkiLength(formModel);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.SkiLengthSpan);
            Assert.Equal(190, result.SkiLength);
        }

        [Fact]
        public void CalculateSkiLength_ForChildren5To8ClassicSkiType_ReturnsCorrectLengthSpan()
        {
            // Arrange
            var formModel = new SkiLengthFormModel
            {
                Length = 110,
                Age = 6,
                SkiType = SkiType.Classic
            };

            // Act
            var result = _skiService.CalculateSkiLength(formModel);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.SkiLengthSpan);
            Assert.Equal(0, result.SkiLength);
            Assert.Equal(120, result.SkiLengthSpan.LowerSpan);
            Assert.Equal(130, result.SkiLengthSpan.UpperSpan);
        }

        [Fact]
        public void CalculateSkiLength_ForChildren0To4ClassicSkiType_ReturnsCorrectLength()
        {
            // Arrange
            var formModel = new SkiLengthFormModel
            {
                Length = 70,
                Age = 2,
                SkiType = SkiType.Classic
            };

            // Act
            var result = _skiService.CalculateSkiLength(formModel);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.SkiLengthSpan);
            Assert.Equal(70, result.SkiLength);
        }

        [Fact]
        public void CalculateSkiLength_ForAdultClassicSkiType_ReturnsMaxLength()
        {
            // Arrange
            var formModel = new SkiLengthFormModel
            {
                Length = 195,
                Age = 31,
                SkiType = SkiType.Classic
            };

            // Act
            var result = _skiService.CalculateSkiLength(formModel);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.SkiLengthSpan);
            Assert.Equal(207, result.SkiLength);
        }

        // Freestyle type tests

        [Fact]
        public void CalculateSkiLength_ForAdultFreestyleSkiType_ReturnsCorrectLength()
        {
            // Arrange
            var formModel = new SkiLengthFormModel
            {
                Length = 170,
                Age = 30,
                SkiType = SkiType.Freestyle
            };

            // Act
            var result = _skiService.CalculateSkiLength(formModel);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.SkiLengthSpan);
            Assert.Equal(0, result.SkiLength);
            Assert.Equal(180, result.SkiLengthSpan.LowerSpan);
            Assert.Equal(185, result.SkiLengthSpan.UpperSpan);
        }

        [Fact]
        public void CalculateSkiLength_ForFreestyleSkiType_ReturnsMaxLengthSpan()
        {
            // Arrange
            var formModel = new SkiLengthFormModel
            {
                Length = 185,
                Age = 30,
                SkiType = SkiType.Freestyle
            };

            // Act
            var result = _skiService.CalculateSkiLength(formModel);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.SkiLengthSpan);
            Assert.Equal(0, result.SkiLength);
            Assert.Equal(192, result.SkiLengthSpan.LowerSpan);
            Assert.Equal(192, result.SkiLengthSpan.UpperSpan);
        }

        [Fact]
        public void CalculateSkiLength_ForChildren0To4FreestyleSkiType_ReturnsCorrectLength()
        {
            // Arrange
            var formModel = new SkiLengthFormModel
            {
                Length = 90,
                Age = 4,
                SkiType = SkiType.Freestyle
            };

            // Act
            var result = _skiService.CalculateSkiLength(formModel);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.SkiLengthSpan);
            Assert.Equal(90, result.SkiLength);
        }

        [Fact]
        public void CalculateSkiLength_ForChildren5To8FreestyleSkiType_ReturnsCorrectLength()
        {
            // Arrange
            var formModel = new SkiLengthFormModel
            {
                Length = 125,
                Age = 8,
                SkiType = SkiType.Freestyle
            };

            // Act
            var result = _skiService.CalculateSkiLength(formModel);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.SkiLengthSpan);
            Assert.Equal(0, result.SkiLength);
            Assert.Equal(135, result.SkiLengthSpan.LowerSpan);
            Assert.Equal(140, result.SkiLengthSpan.UpperSpan);
        }
    }
}
