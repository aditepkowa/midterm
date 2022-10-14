public class Input
{
    public static void RecieveTitle(SomeCompany.Account acc)
    {
        Console.WriteLine("Enter your name title");
        string title = Console.ReadLine();

        ProgressionClass.CheckNameTitle(title, acc);

        acc.accTitle = title;
    }

    public static void RecieveName(SomeCompany.Account acc)
    {
        Console.WriteLine("Enter your name");
        string name = Console.ReadLine();

        RecieveSurname(name, acc);
    }

    public static void RecieveSurname(string name, SomeCompany.Account acc)
    {
        Console.WriteLine("Enter your surname ");
        string surname = Console.ReadLine();

        ProgressionClass.CheckParticipant(name, surname, acc);

        acc.accName = name;
        acc.accSurname = surname;
    }

    public static void RecieveAge(SomeCompany.Account acc)
    {
        Console.WriteLine("Enter your age");
        int age = int.Parse(Console.ReadLine());

        acc.accAge = age;
    }

    public static void RecieveEmail(SomeCompany.Account acc)
    {
        Console.WriteLine("Enter your email");
        string email = Console.ReadLine();

        ProgressionClass.CheckParticipantEmail(email, acc);

        acc.accEmail = email;

    }

    public static void RecieveStudentId(SomeCompany.Account acc)
    {
        Console.WriteLine("Enter your StudentId");
        string id = Console.ReadLine();

        acc.accStudentId = id;

    }

    public static void RecievePassword(SomeCompany.Account acc)
    {
        Console.WriteLine("Enter your password");
        string password = Console.ReadLine();

        Recieveconfirmpassword(password, acc);

    }

    public static void Recieveconfirmpassword(string password, SomeCompany.Account acc)
    {
        Console.WriteLine("Confirme your password");
        string confirmpassword = Console.ReadLine();

        ProgressionClass.CheckParticipantPassword(password, confirmpassword, acc);

        acc.accPassword = password;
        acc.accCfPassword = confirmpassword;

    }
}