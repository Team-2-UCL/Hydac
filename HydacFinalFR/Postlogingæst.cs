using System;
namespace HydacFinalFR
{
    public class Postlogingæst
    {
        // Variabler
        private bool postLoginMenu = true;
        private int valgAfMenu;
        private string ansvarlig;
        private string firma;
        private int antalGæster;
        private bool sikkerhedsfolderUdleveret;
        private string sikkerhedsfolder;
        private List<string> nuvGæster = new List<string> { };
        private int besøgTotal = 0;
        //Initialiseringer
        Log gæsttillog = new Log();

        public void Gæstemenu()
        {
            // Variabler
            postLoginMenu = true;

            while (postLoginMenu == true)
            {
                Console.Clear();
                Console.WriteLine($"GÆSTEMENU - Vælg hvad du vil\n\n1. Registrer ankomst\n2. Registrer afgang\n\n(Tast 0 for at gå tilbage)");
                try
                {
                    valgAfMenu = int.Parse(Console.ReadLine());
                    switch (valgAfMenu)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("GÆSTEMENU - Meld ankomst\n\nIndtast medarbejderen ansvarlig for gruppen... \n\n(Tast 0 for at gå tilbage)");
                            ansvarlig = Console.ReadLine();
                            if (ansvarlig == "")
                            {
                                Console.Clear();
                                Console.WriteLine("Ugyldigt navn, prøv igen...\n\n(Tryk enter for at gå tilbage)");
                                Console.Read();
                                break;
                            }
                            Console.Clear();
                            Console.Write("GÆSTEMENU\n\nIndtast firma...");
                            firma = Console.ReadLine();
                            if (firma == "")
                            {
                                Console.Clear();
                                Console.WriteLine("Ugyldigt input, prøv igen...\n\n(Tryk enter for at gå tilbage)");
                                Console.Read();
                                break;
                            }
                            Console.Clear();
                            Console.Write("GÆSTEMENU\n\nIndtast antal gæster...");
                            try
                            {
                                antalGæster = int.Parse(Console.ReadLine());

                            }
                            catch (Exception ex)
                            {
                                if (ex is FormatException || ex is OverflowException)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Vælg et korrekt tal.\n\n(Tryk enter for at gå tilbage)");
                                    Console.Read();
                                    break;
                                }
                            }
                            Console.Clear();
                            Console.WriteLine("GÆSTEMENU\n\nHar alle gæster modtaget sikkerhedsfolderen? (y/n)");
                            sikkerhedsfolder = Console.ReadLine();
                            switch (sikkerhedsfolder)
                            {
                                case "y":
                                    sikkerhedsfolderUdleveret = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Spørg efter folder i receptionen...\n\n(Tryk enter for at gå tilbage)");
                                    Console.Read();
                                    break;
                            }
                            if (sikkerhedsfolderUdleveret == true)
                            {
                                Console.Clear();
                                Console.WriteLine("Ankomst registreret, tag plads i receptionen.\n\n(Tryk enter for at gå tilbage)");
                                nuvGæster.Add($"{antalGæster} gæster fra {firma}. Ansvarlig for besøg er {ansvarlig}");
                                besøgTotal++;
                                string logbesked = $"Meldt ankomst: {antalGæster} gæster fra {firma}. Ansvarlig for besøg er {ansvarlig}. Sikkerhedsfolderen er udleveret til alle besøgende.";
                                gæsttillog.Gemtillog(logbesked);
                                Console.Read();
                            }
                            break;
                        case 2: // Meld afgang
                            Console.Clear();
                            Console.WriteLine("GÆSTEMENU - Meld afgang\n\n");
                            if (besøgTotal < 1)
                            {
                                Console.Clear();
                                Console.WriteLine("Der er ingen gæster registreret på nuværende tidspunkt.\n\n(Tryk enter for at gå tilbage)");
                                Console.Read();
                                break;
                            }
                            for (int i = 0; i < besøgTotal;)
                            {
                                Console.WriteLine($"{i + 1}. {nuvGæster[i]}");
                                i++;
                            }
                            Console.WriteLine("\nHvilken afgang ønsker du at registrere? (Tast 0 for at gå tilbage)");
                            try
                            {
                                valgAfMenu = int.Parse(Console.ReadLine());
                                if (valgAfMenu < 0 | valgAfMenu > besøgTotal)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Vælg et korrekt tal.\n\n(Tryk enter for at gå tilbage)");
                                    Console.Read();
                                    break;
                                }
                                if (valgAfMenu == 0)
                                {
                                    continue;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Afgang registreret for: {nuvGæster[valgAfMenu - 1]}.\n\n(Tryk enter for at gå tilbage)");
                                    string logbesked = $"Meldt afgang: {nuvGæster[valgAfMenu - 1]}.";
                                    nuvGæster.RemoveAt(valgAfMenu - 1);
                                    besøgTotal = besøgTotal - 1;
                                    gæsttillog.Gemtillog(logbesked);
                                    Console.Read();
                                }
                            }
                            catch (Exception ex)
                            {
                                if (ex is FormatException || ex is OverflowException)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Vælg et korrekt tal.\n\n(Tryk enter for at gå tilbage)");
                                    Console.Read();
                                    break;
                                }
                            }
                            break;
                        case 0:
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