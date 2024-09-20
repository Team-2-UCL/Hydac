using System;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hydac
{
    public class Loggen
    {
        public bool loggen(string input, int valg)
		{
            bool erankommet = false;
            DateTime dateAndTime = DateTime.Now;
            string dato = dateAndTime.ToString("dd.MM.yyyy");
            FileInfo fileInfo = new FileInfo($"{Environment.CurrentDirectory}/" + dato + ".txt");
            string fileName = $"{Environment.CurrentDirectory}/" + dato + ".txt";
            bool exists = fileInfo.Exists;
            if (exists == false)
                using (FileStream fs = File.Create(fileName)) ;
            string ankommede = "";
            string afgang = "";
            string ankommedarbejd = "";
            var ankommedarbejdliste = new List<string>();
            var ankommedeliste = new List<string>();
            var afgangliste = new List<string>();
            string pattern = @"Navn: \s*([^:]+?)\s*fra firma";
            string pattern2 = @"Medarbejder: ([A-Za-z]+ [A-Za-z]+) er";
            string pattern3 = @" \s*([^:]+?)\s*har meldt";
            foreach (var line in File.ReadLines(fileName))
            {
                Match match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    ankommede = match.Groups[1].Value.Trim();
                    ankommedeliste.Add(ankommede.ToString());
                }
                Match match2 = Regex.Match(line, pattern2);
                if (match2.Success)
                {
                    ankommedarbejd = match2.Groups[1].Value.Trim();
                    ankommedarbejdliste.Add(ankommedarbejd.ToString());
                }
                Match match3 = Regex.Match(line, pattern3);
                if (match3.Success)
                {
                    afgang = match3.Groups[1].Value.Trim();
                    afgangliste.Add(afgang.ToString());
                }
            }
            var gæsteliste = ankommedeliste.Except(afgangliste).ToList();
            var medarbejderliste = ankommedarbejdliste.Except(afgangliste).ToList();

            if (valg == 0)
            {
                foreach (string line in medarbejderliste)
                {
                    if (line == input)
                    {
                        erankommet = true;
                        return erankommet;
                    }
                }
                foreach (string line in gæsteliste)
                {
                    if (line == input)
                    {
                        erankommet = true;
                        return erankommet;
                    }
                }
                return erankommet;
            }
            else if (valg == 1)
            {
                bool ankommet = false;
                foreach (string line in medarbejderliste)
                {
                    if (line == input)
                    {
                        erankommet = false;
                        File.AppendAllText(fileName, DateTime.Now.ToString("HH:mm:ss ") + input + " har meldt sin afgang." + Environment.NewLine);
                        ankommet = true;
                        return erankommet;
                    }
                }
                if (ankommet == false)
                {
                    erankommet = true;
                    File.AppendAllText(fileName, DateTime.Now.ToString("HH:mm:ss ") + "Medarbejder: " + input + " er mødt ind." + Environment.NewLine);
                }
                return erankommet;
            }
            return erankommet;
        }
	}
}

