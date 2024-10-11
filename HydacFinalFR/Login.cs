using System;
namespace HydacFinalFR
{
	public class Login
	{
        private int medarbejderId;
		private bool loginMenu = true;
        private string medarbejderNavn = "";

		// Initialiseringer
		Postloginmedarbejder medarbejdermenu = new Postloginmedarbejder();

		public void Medarbejdermenulogin()
		{

            loginMenu = true;
			while (loginMenu == true)
			{
                Console.Clear();
                Console.WriteLine("MEDARBEJDERLOGIN\n\nIndtast dit medarbejderID...\n\n(Tast 0 for at gå tilbage)");
				try
				{
					medarbejderId = int.Parse(Console.ReadLine());
					if (medarbejderId == 0)
					{
						loginMenu = false;
					}
					else
					{
                        medarbejderNavn = Medarbejderlogin(medarbejderId);
                        if (medarbejderNavn == "")
                        {
                            Console.Clear();
                            Console.WriteLine("Ugyldigt ID, prøv igen...\n\n(Tryk enter for at gå tilbage)");
							Console.Read();
                        }
						else
						{
							medarbejdermenu.Medarbejdermenu(medarbejderNavn);
							loginMenu = false;
						}
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
		private string Medarbejderlogin(int medarbejderId)
		{
			switch (medarbejderId)
			{
				case 123:
					medarbejderNavn = "John Johnson";
					break;
				case 321:
					medarbejderNavn = "Peter Petersen";
					break;
				case 222:
					medarbejderNavn = "Lars Larsen";
					break;
				default:
					medarbejderNavn = "";
					break;
			}
			return medarbejderNavn;
		}
	}
}

