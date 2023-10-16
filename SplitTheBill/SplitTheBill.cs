namespace SplitTheBill
{
    public class SplitTheBill
    {
        public static double GetSplitAmount(double amount, int count)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("The amount must be greater than zero.");
            }

            if (count <= 0)
            {
                throw new ArgumentException("Count of individuals to split must be greater than zero");
            }
            return amount / count;
        }


        public static Dictionary<string, double> GetTipAmount(Dictionary<string, double> amountDict, double tipPercent)
        {
            if (tipPercent < 0)
            {
                throw new ArgumentException("Tip percentage cannot be negative.");
            }
            Dictionary<string, double> returnDict = new();

            foreach (var item in amountDict)
            {
                if (item.Value <= 0)
                {
                    throw new ArgumentException("Amount must not be zero");
                }
                returnDict.Add(item.Key, (item.Value * tipPercent) / 100);
            }
            return returnDict;
        }

        public static decimal CalculateTipPerPerson(decimal price, int numberOfPatrons, decimal tipPercent)
        {
            if (numberOfPatrons <= 0)
            {
                throw new ArgumentException("Number of patrons must be greater than zero.");
            }

            if (tipPercent < 0)
            {
                throw new ArgumentException("Tip percentage cannot be negative.");
            }

            decimal totalTip = price * (tipPercent / 100);

            decimal tipPerPerson = totalTip / numberOfPatrons;

            return tipPerPerson;
        }
    }
}