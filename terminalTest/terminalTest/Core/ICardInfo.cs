namespace terminalTest
{
    internal interface ICardInfo
    {
        long PAN { get; }                // Номер карты
        string CardholderName { get; }   // Имя держателя карты
        int ExpriryDate { get; }        // Срок действия
        int PIN { get; }                // PIN карты
        decimal Amount { get; }
    }
}