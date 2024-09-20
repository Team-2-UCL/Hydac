using System;
namespace Hydac;

	public class Medarbejderlogin
	{
		public bool login(string adgangskode)
		{
        bool login = false;
        if (adgangskode == "123")
        {
            login = true;
            return login;
        }
        List<string> ansatte = new List<string>()
        {
        "John Madsen",
        "Poul Larsen",
        "Jens Jensen",
        };
        return login;

		}
	}

