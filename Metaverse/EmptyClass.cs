using System;

namespace SomeCompany
{
    public class EmptyClass
    {
        public EmptyClass()
        {
            int participant = 0;

            Console.WriteLine("Menu");
            Console.WriteLine("Register");
            Console.WriteLine("Participant :" + participant);
            Console.WriteLine("Login");
        }
    }
    public static class RegisteredData
    {
        public static Dictionary<string, Account> ParticipantDictionary = new Dictionary<string, Account>();
        public static Dictionary<string, Account> RegisteredDictionary = new Dictionary<string, Account>();

        public static List<string> ReservedSeats = new List<string>();

        public static Account GetAccByEmail(string email)
        {
            Account account = null;

            foreach (var item in RegisteredDictionary)
            {
                if (email == item.Value.accEmail)
                {
                    account = item.Value;
                }
            }

            return account;
        }
    }
    public class Account
    {
        public int accAge;
        public string accTitle, accName, accSurname, accEmail, accPassword, accStudentId, accCfPassword, participantType;

        public List<string> ReserveredSeats = new List<string>();
        public BankAccData mybank = new BankAccData();
        public CreditCardData mycreditcard = new CreditCardData();

        public bool ispaybyBank;

    }
    public class BankAccData
    {
        public string bankHolder, bankAcc;
    }

    public class CreditCardData
    {
        public string cardHolder, cardNO, expDate, CVV;
    }
}