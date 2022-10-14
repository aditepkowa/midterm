public class Menu
{
    public static SomeCompany.Account thisccount;
    public static void DisplayMainMenu()
    {
        string programMode;

        Console.Clear();

        Console.WriteLine("Menu");
        Console.WriteLine("******************************************************************");
        Console.WriteLine("Please number 1 to Register for the event or  number 2 to Login");
        programMode = Console.ReadLine();

        OnSelectedMenu(programMode);

    }
    public static void DisplayLogin()
    {
        Console.WriteLine("Please enter your Email.");
        string email = Console.ReadLine();
        Console.WriteLine("Please enter your Password.");
        string password = Console.ReadLine();

        ProgressionClass.VerifyEmailandPassword(email, password);
        thisccount = SomeCompany.RegisteredData.GetAccByEmail(email);
        OnloginSuccess();

    }
    public static void OnSelectedMenu(string programMode)
    {
        switch (programMode)
        {
            default:
                break;

            case "1":

                Console.Clear();
                Console.WriteLine("Register Menu");
                Console.WriteLine("***************************************************************");
                Console.WriteLine("Please number 1 to general or number 2 to student");

                SomeCompany.Account newAccount = new SomeCompany.Account();

                programMode = Console.ReadLine();

                if (programMode == "1")
                {
                    Input.RecieveTitle(newAccount);
                    Input.RecieveName(newAccount);

                    Input.RecieveAge(newAccount);
                    Input.RecieveEmail(newAccount);
                    Input.RecievePassword(newAccount);

                    newAccount.participantType = "general";

                }
                if (programMode == "2")
                {
                    Input.RecieveTitle(newAccount);
                    Input.RecieveName(newAccount);

                    Input.RecieveAge(newAccount);
                    Input.RecieveEmail(newAccount);
                    Input.RecieveStudentId(newAccount);
                    Input.RecievePassword(newAccount);

                    newAccount.participantType = "student";

                }

                SomeCompany.RegisteredData.ParticipantDictionary.Add(newAccount.accName + newAccount.accSurname, newAccount);
                SomeCompany.RegisteredData.RegisteredDictionary.Add(newAccount.accEmail, newAccount);

                Console.Clear();

                DisplayMainMenu();

                break;

            case "2":

                DisplayLogin();

                break;
        }

    }
    public static void OnloginSuccess()
    {
        string mode;

        Console.Clear();
        Console.WriteLine("**************************************");
        Console.WriteLine("Reserve Seat number 1");
        Console.WriteLine("Check reserve status number 2");
        Console.WriteLine("Logout number 3");
        Console.WriteLine("**************************************");
        mode = Console.ReadLine();

        switch (mode)
        {
            default:
                break;

            case "1":
                Book.OnResreveSeat();
                break;
            case "2":
                ReserveResult.DisplayReserveResult();
                break;
            case "3":
                Menu.DisplayMainMenu();
                break;
        }
    }
}