using System;
namespace MenuSystem
{
	public class Menu
	{
		public int testing = 1;
		public string Title { get; set; }
		public MenuItem[] menuItems { get; set; }
		public int ItemCount { get; set; }

		public int Show(int hvilkenmenu)
		{
			int valgafmenu = 0;
			if (hvilkenmenu == 1)
			{
				bool quit = false;
				while (quit == false)
				{
					Console.Clear();
					Console.WriteLine($"{Title}\n\n");
					for (int i = 0; i < ItemCount; i++)
					{
						if (menuItems[i] != null)
						{
							Console.WriteLine($"{menuItems[i].Title}");
						}
					}
					Console.WriteLine("\n(Tryk menupunkt eller 0 for at afslutte)");
					string menuvalg = Console.ReadLine();
					switch (menuvalg)
					{
						case "1":
							valgafmenu = 1;
							quit = true;
							break;
						case "2":
							valgafmenu = 2;
							quit = true;
							break;
						case "0":
							valgafmenu = 0;
							quit = true;
							Console.Clear();
							Console.WriteLine("Programmet lukker...");
							Thread.Sleep(1500);
							break;
						default:
							break;

					}
				}
			}
			return valgafmenu;
		}
	}
}
