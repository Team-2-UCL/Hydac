namespace Hydac;

class Program
{
    private static void Main()
    {
        //Variabler
        string medarbejdernavn = " ";
        bool medarbejderlogin = false;
        string valg1 = " ";
        bool startmenu = true;
        bool medarbejdermenu = false;
        bool guestmenu = false;
        bool erclocketind = false;



        while (startmenu == true)
        {
            Console.Clear();
            Console.WriteLine("Vælg om du er en gæst eller medarbejder.\n\n1. Medarbejder \n2. Gæst\n\n(Tag et vælg eller indtast 0 for at slutte.");
            valg1 = Console.ReadLine();
            switch (valg1)
            {
                case "1": //Medarbejder login
                    Medarbejderlogin medarbejderlogininstans = new Medarbejderlogin();
                    Console.Clear();
                    Console.WriteLine("MEDARBEJDER LOGIN\n\nIndtast din adgangskode...");
                    medarbejdernavn = medarbejderlogininstans.login(Console.ReadLine());
                    if (medarbejdernavn == " ")
                    {
                        Console.Clear();
                        Console.WriteLine("Forkert adgangskode.\n\n(Tryk enter for at gå tilbage)");
                        Console.Read();
                        break;
                    }
                    else
                    {
                        medarbejderlogin = true;
                        startmenu = false;
                        break;
                    }
                case "2": //Gæste login
                    startmenu = false;
                    break;
                default: //Forkert input
                    break;
            }
        }
        if (medarbejderlogin == true)
        {
            medarbejdermenu = true;
            while (medarbejdermenu == true)
            {
                Console.Clear();
                Console.WriteLine($"Velkommen: {medarbejdernavn} - vælg hvad du vil.\n\n1. Clock ind/ud\n2. Se loggen\n3. Log ud");
                valg1 = Console.ReadLine();
                switch (valg1)
                {
                    case "1": //Clock ind/ud
                        Loggen medarbejderstatusinstans = new Loggen();
                        Console.Clear();
                        erclocketind = medarbejderstatusinstans.loggen(medarbejdernavn, 0);
                        if (erclocketind == true)
                        {
                            bool medarbejdermenu2 = true;
                            while (medarbejdermenu2 == true)
                            {
                                Console.WriteLine($"CLOCK UD for: {medarbejdernavn}\n\nVil du clocke ud? (y/n)");
                                valg1 = Console.ReadLine();
                                switch (valg1)
                                {
                                    case "y":
                                        medarbejdermenu2 = false;
                                        medarbejderstatusinstans.loggen(medarbejdernavn, 1);
                                        Main();
                                        break;
                                    case "n":
                                        medarbejdermenu2 = false;
                                        break;
                                    default:
                                        medarbejdermenu2 = false;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            bool medarbejdermenu2 = true;
                            while (medarbejdermenu2 == true)
                            {
                                Console.Clear();
                                Console.WriteLine($"CLOCK IND for: {medarbejdernavn}\n\nVil du clocke ind? (y/n)");
                                valg1 = Console.ReadLine();
                                switch (valg1)
                                {
                                    case "y":
                                        medarbejdermenu2 = false;
                                        medarbejderstatusinstans.loggen(medarbejdernavn, 1);
                                        Main();
                                        break;
                                    case "n":
                                        medarbejdermenu2 = false;
                                        break;
                                    default:
                                        medarbejdermenu2 = false;
                                        break;
                                }
                            }
                        }
                        break;
                    case "2": //Se loggen
                        break;
                    case "3": //Log ud
                        Main();
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            guestmenu = true;
            while (guestmenu == true)
            {

            }
        }
    }

}

