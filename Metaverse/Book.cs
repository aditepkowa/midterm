public class Book
{
    public static SomeCompany.Account thisaccount = Menu.thisccount;
    public static List<string> prefredSeat = new List<string>();

    public static string PrefreSeat;

    public static void DisplayPreferedSeats()
    {
        Console.WriteLine("Prefer seats : " + PrefreSeat);
    }
    public static void OnResreveSeat()
    {
        Console.WriteLine("Reserve Seat");
        DisplayPreferedSeats();
        Console.WriteLine("Plaese enter your seat number (example A1 or B5) #Please type in Upper letter");
        string seat = Console.ReadLine();

        VerifySeat(seat);

        Console.Write("Please enter checkout to checkout");
        Console.ReadLine();
    }
    public static void OnSelecSeats()
    {
        DisplayPreferedSeats();
        Console.WriteLine("Plaese enter your seat number");
        string seat = Console.ReadLine();
        VerifySeat(seat);
    }
    public static void VerifySeat(string seatnumber)
    {
        if (seatnumber != "exit")
        {
            if (seatnumber != "checkout")
            {
                if (seatnumber.Contains("A"))
                {
                    if (thisaccount.participantType == "student")
                    {
                        Console.WriteLine("Cannot book. Please try again");
                        OnSelecSeats();
                    }
                    else
                    {
                        if (!SomeCompany.RegisteredData.ReservedSeats.Contains(seatnumber))
                        {
                            if (prefredSeat.Contains(seatnumber))
                            {
                                Console.WriteLine("Already book. Please try again");
                                OnSelecSeats();
                            }
                            else
                            {
                                PrefreSeat += " " + seatnumber;
                                prefredSeat.Add(seatnumber);
                                OnSelecSeats();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Already book. Please try again");
                            OnSelecSeats();
                        }
                    }
                }
                else
                {
                    PrefreSeat += " " + seatnumber;
                    prefredSeat.Add(seatnumber);
                    OnSelecSeats();
                }
            }
            else
            {
                CheckOuts.allSeat = prefredSeat;
                CheckOuts.DisPlayCheckOutMenu();
            }
        }
        else
        {
            prefredSeat.Clear();
            Menu.DisplayMainMenu();
        }
    }
}
public class ReserveResult
{
    public static SomeCompany.Account thisacc = Menu.thisccount;

    public static void DisplayReserveResult()
    {
        Console.Clear();

        if (thisacc.ReserveredSeats.Count <= 0)
            Console.WriteLine("Please book ypur seat first.");
        else
        {
            Console.WriteLine("Participant type : " + thisacc.participantType);
            Console.WriteLine("Reserved Seat TypeA : " + CheckOuts.preferedSeatA);
            Console.WriteLine("Reserved Seat TypeB : " + CheckOuts.preferedSeatB);
            Console.WriteLine(CheckOuts.allSeat.Count + " Seats" + "Total price : " + CheckOuts.CalculatePrice(CheckOuts.allSeat.Count, thisacc.participantType));


            if (thisacc.ispaybyBank)
            {
                Console.WriteLine("Pay by Bank");
                Console.WriteLine(" Bank holder Name : " + thisacc.mybank.bankHolder);
                Console.WriteLine(" Bank Account : " + thisacc.mybank.bankAcc);
            }
            else
            {
                Console.WriteLine("Pay by CreditCard");
                Console.WriteLine(" CreditCard holder Name : " + thisacc.mycreditcard.cardHolder);
                Console.WriteLine(" CreditCard Number : " + thisacc.mycreditcard.cardNO);
                Console.WriteLine(" CreditCard expire date : " + thisacc.mycreditcard.expDate);
                Console.WriteLine(" CreditCard CVV : " + thisacc.mycreditcard.CVV);
            }
        }


        Console.WriteLine("Please enter any to continue");
        Console.ReadLine();

        Menu.DisplayMainMenu();

    }
    public static void CheckOut()
    {
        Console.WriteLine("Please enter any to continue");
        string mode = Console.ReadLine();

        if (mode != "checkout")
        {
            CheckOut();

        }
    }
}