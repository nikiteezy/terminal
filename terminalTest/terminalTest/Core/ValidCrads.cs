namespace terminalTest.Core
{
    internal class ValidCrads : ICardInfo
    {
        public decimal Amount { get; set; }

        public string CardholderName { get; set; }

        public int ExpriryDate { get; set; }

        public long PAN { get; set; }

        public int PIN { get; set; }

        public void set()
        {
            decimal _Amount;
            string _CardholderName;
            long _PAN;
            int _PIN, _ExprityDate;

            /*
             * Считывание данных из файла
             */

           // Amount = _Amount;
        }
    }
}