using System;
namespace HydacFinalFR
{
	public class Postloginmedarbejder
	{
        // Variabler
        private bool postloginmenu = true;
        private int valgafmenu;
        private List<string> nuvmedarbejdere = new List<string> { };
        private List<string> nuvpause = new List<string> { };
        private bool clockedind;
        private bool tilpause;
        private string clockindellerud;
        private string humør;
        private int count;
        private int countpause;
        private string logbesked;

        // Initialiseringer
        Log medarbejderlog = new Log();

        public void Medarbejdermenu(string medarbejdernavn)
        {
            // Variabler
            postloginmenu = true;

            while (postloginmenu == true)
            {
                count = 0;
                clockedind = false;
                foreach (var medarbejder in nuvmedarbejdere)
                {
                    if (medarbejder == medarbejdernavn)
                    {
                        clockedind = true;
                        break;
                    }
                    count++;
                }
                countpause = 0;
                tilpause = false;
                foreach (var medarbejder in nuvpause)
                {
                    if (medarbejder == medarbejdernavn)
                    {
                        tilpause = true;
                        break;
                    }
                    countpause++;
                }
                Console.Clear();
                Console.WriteLine($"Velkommen: {medarbejdernavn} - Vælg hvad du vil\n\n1. Clock ind/ud\n2. Registrer pause\n3. Se loggen\n4. Log af");
                try
                {
                    valgafmenu = int.Parse(Console.ReadLine());
                    switch (valgafmenu)
                    {
                        case 1:
                            if (tilpause == false)
                            {
                                if (clockedind == true)
                                {
                                    Console.Clear();
                                    Console.WriteLine("REGISTRER AFGANG\n\nBekræft med at taste y eller tryk enter for at afbrude");
                                    clockindellerud = Console.ReadLine();
                                    switch (clockindellerud)
                                    {
                                        case "y":
                                            Console.Clear();
                                            nuvmedarbejdere.RemoveAt(count);
                                            Console.WriteLine($"Afgangen for {medarbejdernavn} er blevet registreret.\n\n(Tryk enter for at gå tilbage)");
                                            logbesked = $"{medarbejdernavn} har meldt sin afgang.";
                                            medarbejderlog.Gemtillog(logbesked);
                                            Console.Read();
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("REGISTRER ANKOMST\n\nBekræft med at taste y eller tryk enter for at afbrude");
                                    clockindellerud = Console.ReadLine();
                                    switch (clockindellerud)
                                    {
                                        case "y":
                                            Console.Clear();
                                            Console.WriteLine("REGISTER ANKOMST\n\nVælg dit humør: 1. :) 2. :| 3. :(");
                                            humør = Console.ReadLine();
                                            if (humør == "1" | humør == "2" | humør == "3")
                                            {
                                                Console.Clear();
                                                Console.WriteLine($"Ankomsten for {medarbejdernavn} er blevet registreret.\n\n(Tryk enter for at gå tilbage)");
                                                logbesked = $"{medarbejdernavn} er mødt ind. Humør: {humør}.";
                                                medarbejderlog.Gemtillog(logbesked);
                                                nuvmedarbejdere.Add(medarbejdernavn);
                                                Console.Read();
                                                break;
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Ugyldigt input, vælg et korrekt tal.\n\n(Tryk enter for at gå tilbage)");
                                                Console.Read();
                                                break;
                                            }
                                        default:
                                            break;
                                    }
                                }
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Fejl, du kan ikke clocke ud når du er til pause.\n\n(Tryk enter for at gå tilbage)");
                                Console.Read();
                                break;
                            }
                        case 2:
                            if (clockedind == true)
                            {
                                switch (tilpause)
                                {
                                    case false:
                                        Console.Clear();
                                        Console.WriteLine("REGISTRER PAUSE\n\nBekræft med at taste y eller tryk enter for at afbrude");
                                        clockindellerud = Console.ReadLine();
                                        switch (clockindellerud)
                                        {
                                            case "y":
                                                Console.Clear();
                                                Console.WriteLine("Starttidspunktet på din pause er registreret, god pause!\n\n(Tryk enter for at gå tilbage)");
                                                logbesked = $"{medarbejdernavn} er gået til pause.";
                                                nuvpause.Add(medarbejdernavn);
                                                medarbejderlog.Gemtillog(logbesked);
                                                Console.Read();
                                                break;
                                            default:
                                                Console.Clear();
                                                Console.WriteLine("Ugyldigt input, prøv igen. \n\n(Tryk enter for at gå tilbage)");
                                                Console.Read();
                                                break;
                                        }
                                        break;
                                    case true:
                                        Console.Clear();
                                        Console.WriteLine("AFSLUT PAUSE\n\nBekræft med at taste y eller tryk enter for at afbrude");
                                        clockindellerud = Console.ReadLine();
                                        switch (clockindellerud)
                                        {
                                            case "y":
                                                Console.Clear();
                                                Console.WriteLine("Sluttidspunktet på din pause er registreret, god arbejdslyst!\n\n(Tryk enter for at gå tilbage)");
                                                logbesked = $"{medarbejdernavn} er vendt tilbage fra pause.";
                                                nuvpause.RemoveAt(countpause);
                                                medarbejderlog.Gemtillog(logbesked);
                                                Console.Read();
                                                break;
                                            default:
                                                Console.Clear();
                                                Console.WriteLine("Ugyldigt input, prøv igen. \n\n(Tryk enter for at gå tilbage)");
                                                Console.Read();
                                                break;
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Fejl, du kan ikke gå til pause før du er clocket ind.\n\n(Tryk enter for at gå tilbage)");
                                Console.Read();
                                break;
                            }
                            break;

                        case 3:
                            Console.Clear();
                            logbesked = medarbejderlog.Hentloggen();
                            Console.WriteLine(logbesked);
                            Console.Read();
                            break;
                        case 4:
                            postloginmenu = false;
                            break;
                        default:
                            break;
                    }
                }
                catch (FormatException)
                {
                }
            }
        }
	}
}

