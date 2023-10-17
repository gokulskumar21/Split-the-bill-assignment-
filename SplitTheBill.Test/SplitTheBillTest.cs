namespace SplitTheBill.Test
{
    public class SplitTheBillTest
    {
        [Fact]
        public void GetSplitAmount_ValidInput_ReturnsSplitAmount()
        {
            // Arrange
            var amount = 100.0;
            var count = 5;

            // Act
            var result = SplitTheBill.GetSplitAmount(amount, count);

            // Assert
            Assert.Equal(20.0, result);
        }

        [Fact]
        public void GetSplitAmount_InvalidAmount_ThrowsArgumentException()
        {
            // Arrange
            var amount = 0.0;
            var count = 5;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => SplitTheBill.GetSplitAmount(amount, count));
        }

        [Fact]
        public void GetSplitAmount_InvalidCount_ThrowsArgumentException()
        {
            // Arrange
            var amount = 100.0;
            var count = 0;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => SplitTheBill.GetSplitAmount(amount, count));
        }

        [Fact]
        public void GetTipAmount_ValidInput_ReturnsCorrectTipAmounts()
        {
            // Arrange
            var amountDict = new Dictionary<string, double>
        {
            {"Item1", 100.0 },
            {"Item2", 50.0 }
        };
            double tipPercent = 10.0;

            // Act
            var result = SplitTheBill.GetTipAmount(amountDict, tipPercent);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(10.0, result["Item1"]);
            Assert.Equal(5.0, result["Item2"]);
        }

        [Fact]
        public void GetTipAmount_NegativeTipPercent_ThrowsArgumentException()
        {
            // Arrange
            var amountDict = new Dictionary<string, double>
        {
            {"Item1", 100.0 }
        };
            double tipPercent = -10.0;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => SplitTheBill.GetTipAmount(amountDict, tipPercent));
        }

        [Fact]
        public void GetTipAmount_ZeroAmount_ThrowsArgumentException()
        {
            // Arrange
            var amountDict = new Dictionary<string, double>
        {
            {"Item1", 0.0 }
        };
            double tipPercent = 10.0;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => SplitTheBill.GetTipAmount(amountDict, tipPercent));
        }

        [Fact]
        public void CalculateTipPerPerson_ValidInput_ReturnsCorrectTipPerPerson()
        {
            // Arrange
            decimal price = 100.0M;
            int numberOfPatrons = 5;
            decimal tipPercent = 10.0M;

            // Act
            decimal result = SplitTheBill.CalculateTipPerPerson(price, numberOfPatrons, tipPercent);

            // Assert
            decimal expectedTipPerPerson = 2.0M;
            Assert.Equal(expectedTipPerPerson, result);
        }

        [Fact]
        public void CalculateTipPerPerson_ZeroPatrons_ThrowsArgumentException()
        {
            // Arrange
            decimal price = 100.0M;
            int numberOfPatrons = 0;
            decimal tipPercent = 10.0M;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => SplitTheBill.CalculateTipPerPerson(price, numberOfPatrons, tipPercent));
        }

        [Fact]
        public void CalculateTipPerPerson_NegativeTipPercent_ThrowsArgumentException()
        {
            // Arrange
            decimal price = 100.0M;
            int numberOfPatrons = 5;
            decimal tipPercent = -10.0M;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => SplitTheBill.CalculateTipPerPerson(price, numberOfPatrons, tipPercent));
        }
    }
}