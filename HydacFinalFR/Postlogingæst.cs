using System;
namespace HydacFinalFR
{
    public class Postlogingæst
    {
        // Variabler
        private bool postloginmenu = true;
        private int valgafmenu;
        private string ansvarlig;
        private string firma;
        private int antalgæster;
        private bool sikkerhedsfolder;
        private string sikkerhedsFolder;
        private List<string> nuværendegæster = new List<string> { };
        private int besøgtotal = 0;
        //Initialiseringer
        Log gæsttillog = new Log();

        public void Gæstemenu()
        {
            // Variabler
            postloginmenu = true;

            while (postloginmenu == true)
            {
                Console.Clear();
                Console.WriteLine($"GÆSTEMENU - Vælg hvad du vil\n\n1. Registrer ankosmt\n2. Registrer afgang\n\n(Tast 0 for at gå tilbage)");
                try
                {
                    valgafmenu = int.Parse(Console.ReadLine());
                    switch (valgafmenu)
                    {
                        case 1:
                            Console.Clear(); // Skal kunne hente medarbejdere der er på arbejde lige pt
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
                                Console.WriteLine("Ugyldigt firma, prøv igen...\n\n(Tryk enter for at gå tilbage)");
                                Console.Read();
                                break;
                            }
                            Console.Clear();
                            Console.Write("GÆSTEMENU\n\nIndtast antal gæster...");
                            try
                            {
                                antalgæster = int.Parse(Console.ReadLine());

                            }
                            catch (FormatException)
                            {
                                Console.Clear();
                                Console.WriteLine("Ugyldigt tal, prøv igen...\n\n(Tryk enter for at gå tilbage)");
                                Console.Read();
                                break;
                            }
                            Console.Clear();
                            Console.WriteLine("GÆSTEMENU\n\nHar du modtaget sikkerhedsfolderen? (y/n)");
                            sikkerhedsFolder = Console.ReadLine();
                            switch (sikkerhedsFolder)
                            {
                                case "y":
                                    sikkerhedsfolder = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Spørg efter folder i receptionen...\n\n(Tryk enter for at gå tilbage)");
                                    Console.Read();
                                    break;
                            }
                            if (sikkerhedsfolder == true)
                            {
                                Console.Clear();
                                Console.WriteLine("Din ankomst er registreret, tag plads i receptionen.\n\n(Tryk enter for at gå tilbage)");
                                nuværendegæster.Add($"{antalgæster} gæster fra {firma}. Ansvarlig for besøg er {ansvarlig}");
                                besøgtotal++;
                                string logbesked = $"Meldt ankomst: {antalgæster} gæster fra {firma}. Ansvarlig for besøg er {ansvarlig}. Sikkerhedsfolderen er udleveret til alle besøgende.";
                                gæsttillog.Gemtillog(logbesked);
                                Console.Read();
                            }
                            break;
                        case 2: // Meld afgang
                            Console.Clear();
                            Console.WriteLine("GÆSTEMENU - Meld afgang\n\n");
                            for (int i = 0; i < besøgtotal;)
                            {
                                Console.WriteLine($"{i + 1}. {nuværendegæster[i]}");
                                i++;
                            }
                            Console.WriteLine("\nHvilken afgang ønsker du at registrere? (Tast 0 for at gå tilbage)");
                            try
                            {
                                valgafmenu = int.Parse(Console.ReadLine());
                                if (valgafmenu < 0 | valgafmenu > besøgtotal)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Vælg et korrekt tal.\n\n(Tryk enter for at gå tilbage)");
                                    Console.Read();
                                }
                                if (valgafmenu == 0)
                                {
                                    continue;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Afgangen registret for: {nuværendegæster[valgafmenu - 1]}.\n\n(Tryk enter for at gå tilbage)");
                                    string logbesked = $"Meldt afgang: {nuværendegæster[valgafmenu - 1]}.";
                                    nuværendegæster.RemoveAt(valgafmenu - 1);
                                    besøgtotal = besøgtotal - 1;
                                    gæsttillog.Gemtillog(logbesked);
                                    Console.Read();
                                }
                            }
                            catch (FormatException)
                            {
                                break;
                            }
                            break;
                        case 0:
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