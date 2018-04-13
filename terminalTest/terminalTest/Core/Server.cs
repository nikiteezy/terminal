using System;
using System.IO;
using System.Text;

namespace terminalTest.Core
{
    internal class Server
    {
        private ValidTerminals[] validTerminals = new ValidTerminals[50];
        private int countTerminals = 0;
        private ValidCrads[] validCards = new ValidCrads[100];
        private int countCards = 0;

        public void readTerms()
        {
            string[] arStr = File.ReadAllLines("../../database/terminals.txt");

            for (int i = 0; i < arStr.Length; i++)
            {
                validTerminals[countTerminals] = new ValidTerminals();
                validTerminals[countTerminals].TerminalsId = long.Parse(arStr[i]);
                countTerminals++;
            }
        }

        public void readCards()
        {
            string[] arStr = File.ReadAllLines("../../database/cards.txt");
            for (int i = 0; i < arStr.Length; i += 5)
            {
                string amount = arStr[i + 4];
                decimal damount = 0;
                decimal.TryParse(amount, out damount);
                validCards[countCards] = new ValidCrads();
                validCards[countCards].set(long.Parse(arStr[i]),
                    arStr[i + 1], Convert.ToInt32(arStr[i + 2]),
                   Convert.ToInt32(arStr[i + 3]), decimal.Parse(arStr[i+4].Replace('.', ',')));
                countCards++;
            }
        }

        public string getRequest(long _PAN, string _CardholderName, int _PIN, int _ExprityDate, decimal _Amount, string date, long _termId)
        {
            if (date != string.Format("{0:M d h m}", DateTime.Now))
                return "Ошибка: Время не совпадает";
            bool existTerm = false;
            for (int j = 0; j < countTerminals; j++)
            {
                if (validTerminals[j].TerminalsId == _termId)
                {
                    existTerm = true;
                }
            }

            if (!existTerm)
                return "Ошибка: не верный id терминала";

            int i;
            bool existCard = false;
            for (i = 0; i < countCards; i++)
            {
                if (validCards[i].PAN == _PAN)
                {
                    existCard = true;
                    break;
                }
            }
            if (!existCard)
                return "Ошибка: Неверный номер карты";

            if (validCards[i].CardholderName != _CardholderName)
                return "Ошибка: Неверное имя владельца";

            if (validCards[i].ExpriryDate != _ExprityDate)
                return "Ошибка: срок действия карты не действителен";

            if (validCards[i].PIN != _PIN)
                return "Ошибка: Неверный пин-код";

            if (validCards[i].Amount < _Amount)
                return "Ошибка: Недостаточно стредств";

            payment(i, _Amount);
            addTransactionInDB(_termId, i, _Amount);
            return "Операция прошла успешно";
        }

        private void payment(int cardId, decimal _Amount)
        {
            validCards[cardId].Amount -= _Amount;
        }

        private void addTransactionInDB(long terminalId, int cartID, decimal amount)
        {
            using (StreamWriter sw = new StreamWriter("../../database/transaction.txt", true, Encoding.GetEncoding("windows-1251")))
            {
                sw.WriteLine(string.Format("Терминал номер:{0} PAN:{1} Cart Holder Name:{2} Exprity Date{3} Amount:{4} Дата:{5}" ,
                    terminalId, validCards[cartID].PAN, validCards[cartID].CardholderName, 
                    validCards[cartID].ExpriryDate, amount, DateTime.Now));
            }
        }
    }
}