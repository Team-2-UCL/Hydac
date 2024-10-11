using System;
namespace HydacFinalFR
{
	public class Postloginmedarbejder
	{
        // Variabler
        private bool postLoginMenu = true;
        private int valgAfMenu;
        private List<string> nuvMedarbejdere = new List<string> { };
        private List<string> nuvPause = new List<string> { };
        private bool clockedInd;
        private bool tilPause;
        private string clockIndEllerUd;
        private string humør;
        private int count;
        private int countPause;
        private string logBesked;

        // Initialiseringer
        Log medarbejderlog = new Log();

        public void Medarbejdermenu(string medarbejderNavn)
        {
            // Variabler
            postLoginMenu = true;

            while (postLoginMenu == true)
            {
                count = 0;
                clockedInd = false;
                foreach (var medarbejder in nuvMedarbejdere)
                {
                    if (medarbejder == medarbejderNavn)
                    {
                        clockedInd = true;
                        break;
                    }
                    count++;
                }
                countPause = 0;
                tilPause = false;
                foreach (var medarbejder in nuvPause)
                {
                    if (medarbejder == medarbejderNavn)
                    {
                        tilPause = true;
                        break;
                    }
                    countPause++;
                }
                Console.Clear();
                Console.WriteLine($"Velkommen: {medarbejderNavn} - Vælg hvad du vil\n\n1. Clock ind/ud\n2. Registrer pause\n3. Se loggen\n4. Log af");
                try
                {
                    valgAfMenu = int.Parse(Console.ReadLine());
                    switch (valgAfMenu)
                    {
                        case 1:
                            if (tilPause == false)
                            {
                                if (clockedInd == true)
                                {
                                    Console.Clear();
                                    Console.WriteLine("REGISTRER AFGANG\n\nBekræft med at taste y eller tryk enter for at afbryde");
                                    clockIndEllerUd = Console.ReadLine();
                                    switch (clockIndEllerUd)
                                    {
                                        case "y":
                                            Console.Clear();
                                            nuvMedarbejdere.RemoveAt(count);
                                            Console.WriteLine($"Afgangen for {medarbejderNavn} er blevet registreret.\n\n(Tryk enter for at gå tilbage)");
                                            logBesked = $"{medarbejderNavn} har meldt sin afgang.";
                                            medarbejderlog.Gemtillog(logBesked);
                                            Console.Read();
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("REGISTRER ANKOMST\n\nBekræft med at taste y eller tryk enter for at afbryde");
                                    clockIndEllerUd = Console.ReadLine();
                                    switch (clockIndEllerUd)
                                    {
                                        case "y":
                                            Console.Clear();
                                            Console.WriteLine("REGISTRER ANKOMST\n\nVælg dit humør: 1. :) 2. :| 3. :(");
                                            humør = Console.ReadLine();
                                            if (humør == "1" | humør == "2" | humør == "3")
                                            {
                                                Console.Clear();
                                                Console.WriteLine($"Ankomsten for {medarbejderNavn} er blevet registreret.\n\n(Tryk enter for at gå tilbage)");
                                                logBesked = $"{medarbejderNavn} er mødt ind. Humør: {humør}.";
                                                medarbejderlog.Gemtillog(logBesked);
                                                nuvMedarbejdere.Add(medarbejderNavn);
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
                            if (clockedInd == true)
                            {
                                switch (tilPause)
                                {
                                    case false:
                                        Console.Clear();
                                        Console.WriteLine("REGISTRER PAUSE\n\nBekræft med at taste y eller tryk enter for at afbryde");
                                        clockIndEllerUd = Console.ReadLine();
                                        switch (clockIndEllerUd)
                                        {
                                            case "y":
                                                Console.Clear();
                                                Console.WriteLine("Starttidspunktet på din pause er registreret, god pause!\n\n(Tryk enter for at gå tilbage)");
                                                logBesked = $"{medarbejderNavn} er gået til pause.";
                                                nuvPause.Add(medarbejderNavn);
                                                medarbejderlog.Gemtillog(logBesked);
                                                Console.Read();
                                                break;
                                            case "":
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
                                        Console.WriteLine("AFSLUT PAUSE\n\nBekræft med at taste y eller tryk enter for at afbryde");
                                        clockIndEllerUd = Console.ReadLine();
                                        switch (clockIndEllerUd)
                                        {
                                            case "y":
                                                Console.Clear();
                                                Console.WriteLine("Sluttidspunktet på din pause er registreret, god arbejdslyst!\n\n(Tryk enter for at gå tilbage)");
                                                logBesked = $"{medarbejderNavn} er vendt tilbage fra pause.";
                                                nuvPause.RemoveAt(countPause);
                                                medarbejderlog.Gemtillog(logBesked);
                                                Console.Read();
                                                break;
                                            case "":
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
                            logBesked = medarbejderlog.Hentloggen();
                            Console.WriteLine(logBesked);
                            Console.Read();
                            break;
                        case 4:
                            postLoginMenu = false;
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    if (ex is FormatException || ex is OverflowException)
                    {
                        Console.Clear();
                        Console.WriteLine("Vælg et korrekt tal.\n\n(Tryk enter for at gå tilbage)");
                        Console.Read();
                    }
                }
            }
        }
	}
}

