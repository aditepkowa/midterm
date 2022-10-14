public class ProgressionClass
{
    public static void CheckParticipant(string name, string surname, SomeCompany.Account acc)
    {
        string dictionaryKeys = name + surname;

        if (SomeCompany.RegisteredData.ParticipantDictionary.ContainsKey(dictionaryKeys))
        {
            Console.WriteLine("User is already registered. Please try again.");

            Input.RecieveName(acc);
        }
    }
    public static void CheckParticipantEmail(string email, SomeCompany.Account acc)
    {
        foreach (var item in SomeCompany.RegisteredData.ParticipantDictionary)
        {
            if (item.Value.accEmail == email || email == "exit")
            {
                Console.WriteLine("Invalid email. Please try again.");

                Input.RecieveEmail(acc);
            }


            break;
        }
    }
    public static void CheckParticipantPassword(string password, string confirmpassword, SomeCompany.Account acc)
    {
        if (password == confirmpassword) return;
        else
        {
            Console.WriteLine("Mismatched password. Please try again.");
            Input.RecievePassword(acc);
        }

    }
    public static void CheckNameTitle(string title, SomeCompany.Account acc)
    {
        if (title == "Mr." || title == "Miss." || title == "Mrs.") return;

        else
        {
            Console.WriteLine("Please input only  Mr. / Miss. / Mrs.");
            Input.RecieveTitle(acc);
        }
    }
    public static void VerifyEmailandPassword(string email, string password)
    {
        if (email != "exit")
        {
            if (!SomeCompany.RegisteredData.RegisteredDictionary.ContainsKey(email))
            {
                Console.WriteLine("Incorrect Email or Password. Please try again");
                Menu.DisplayLogin();
            }
            else
            {
                string pss = SomeCompany.RegisteredData.RegisteredDictionary[email].accCfPassword;

                if (password != pss)
                {
                    Console.WriteLine("Incorrect Email or Password. Please try again");
                    Menu.DisplayLogin();
                }
            }
        }
        else
        {
            Menu.DisplayMainMenu();
        }
    }
}
public class CheckOuts
{
    public static SomeCompany.Account thisacc = Menu.thisccount;
    public static List<string> allSeat;
    public static string preferedSeatA;
    public static string preferedSeatB;

    public static float CalculatePrice(int seatQty, string participantType)
    {
        float value = 0;

        float studentprice = 1200.5f;
        float generalprice = 5235.25f;

        if (participantType == "student")
        {
            value = seatQty * studentprice;
        }
        else
        {
            value = seatQty * generalprice;
        }

        return value;
    }

    public static void SplitSeat(List<string> seats)
    {
        foreach (var item in seats)
        {
            if (item.Contains("A"))
            {
                preferedSeatA += " " + item;

            }
            else
            {
                preferedSeatB += " " + item;
            }
        }
    }

    public static void DisPlayCheckOutMenu()
    {
        Console.Clear();

        SplitSeat(allSeat);

        Console.WriteLine("CheckOut Menu");
        Console.WriteLine("Prefre Seats type A : " + preferedSeatA);
        Console.WriteLine("Prefre Seats type B : " + preferedSeatB);
        Console.WriteLine(allSeat.Count + " Seats" + "Total price : " + CalculatePrice(allSeat.Count, thisacc.participantType));

        DisplayCheckOutMenu();
    }

    public static void DisplayCheckOutMenu()
    {
        string mode;

        Console.WriteLine("Pay by Bank. Please type 1");
        Console.WriteLine("Pay by Credit card. Please type 2");
        Console.WriteLine("Cancle. Please type 0");

        mode = Console.ReadLine();
        CheckOutMenuMode(mode);

    }
    public static void CheckOutMenuMode(string mode)
    {
        switch (mode)
        {
            default:
                Console.WriteLine("Invalid type. Please try again.");
                DisPlayCheckOutMenu();

                break;

            case "1":
                thisacc.ispaybyBank = true;
                DisplayPayByBank();
                ConfirmedReserve();
                ReserveResult.DisplayReserveResult();
                break;

            case "2":
                DisplayPayByCreditCard();
                ConfirmedReserve();
                ReserveResult.DisplayReserveResult();
                break;

            case "0":

                Console.Clear();
                allSeat.Clear();
                Menu.DisplayMainMenu();

                break;
        }
    }
    public static void DisplayPayByBank()
    {
        Console.WriteLine("Please enter Bank holder name");
        string bankHolder = Console.ReadLine();
        Console.WriteLine("Please enter Bank account");
        string bankAcc = Console.ReadLine();

        Menu.thisccount.mybank.bankHolder = bankHolder;
        Menu.thisccount.mybank.bankAcc = bankAcc;
    }
    public static void DisplayPayByCreditCard()
    {
        Console.WriteLine("Please enter Card holder name");
        string cardHolder = Console.ReadLine();
        Console.WriteLine("Please enter Card number");
        string cardNO = Console.ReadLine();
        Console.WriteLine("Please enter Card expire date");
        string expDate = Console.ReadLine();
        Console.WriteLine("Please enter CVV");
        string CVV = Console.ReadLine();

        Menu.thisccount.mycreditcard.cardHolder = cardHolder;
        Menu.thisccount.mycreditcard.cardNO = cardNO;
        Menu.thisccount.mycreditcard.expDate = expDate;
        Menu.thisccount.mycreditcard.CVV = CVV;
    }
    public static void ConfirmedReserve()
    {
        foreach (var item in allSeat)
        {
            SomeCompany.RegisteredData.ReservedSeats.Add(item);
            thisacc.ReserveredSeats.Add(item);

        }
    }
}