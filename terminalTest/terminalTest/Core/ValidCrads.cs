namespace terminalTest.Core
{
    internal class ValidCrads : ICardInfo
    {
        public decimal Amount { get; set; }

        public string CardholderName { get; set; }

        public int ExpriryDate { get; set; }

        public long PAN { get; set; }

        public int PIN { get; set; }

        public void set(long _PAN, string _CardholderName, int _PIN, int _ExprityDate, decimal _Amount)
        {
            Amount = _Amount;
            CardholderName = _CardholderName;
            PAN = _PAN;
            PIN = _PIN;
            ExpriryDate = _ExprityDate;
        }
    }
}