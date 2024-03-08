using Dating.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dating.Data.Services
{
    // Definerer en klasse til at håndtere autentificeringsservice.
    public class SimpleAuthService
    {
        // En egenskab, der angiver, om brugeren er logget ind eller ej.
        // Standardværdien er sat til false, hvilket betyder, at brugeren ikke er logget ind ved start.
        public bool IsLoggedIn { get; set; } = false;

        // En egenskab til at holde information om den nuværende bruger.
        // Typen 'AccountProfile' formodes at være en brugerdefineret klasse, der indeholder brugerens detaljer.
        public AccountProfile CurrentUser { get; set; }

        public ProfilDetail CurrentProfile { get; set; }                    
        public void Logout()
        {
            // Logik for at logge brugeren ud
            CurrentUser = null;
            IsLoggedIn = false;
        }
    }
}



