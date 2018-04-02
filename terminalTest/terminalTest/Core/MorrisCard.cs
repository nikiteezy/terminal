namespace terminalTest
{
    internal class MorrisCard : ICardInfo
    {
        public string CardholderName { get; }

        public int ExpriryDate { get; }

        public long PAN { get; }

        public int PIN { get; }

        public decimal Amount { get; }

        public MorrisCard()
        {
            CardholderName = "S.Morris";
            ExpriryDate = 1209;
            PAN = 5412751234123456;
            PIN = 2280;
            Amount = 11541.54M;
        }
    }
}