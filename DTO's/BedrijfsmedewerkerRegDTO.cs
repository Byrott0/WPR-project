﻿using System.ComponentModel.DataAnnotations;

namespace WPR_project.DTO_s
{
    public class BedrijfsmedewerkerRegDTO
    {

        [Required(ErrorMessage = "Naam van medewerker is verplicht.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Medewerkernaam moet tussen 2 en 50 tekens zijn.")]
        public string medewerkerNaam { get; set; } // Correcte PascalCase voor consistentie

        [Required(ErrorMessage = "E-mailadres van medewerker is verplicht.")]
        [EmailAddress(ErrorMessage = "Ongeldig e-mailadres.")]
        public string medewerkerEmail { get; set; }

        [Required(ErrorMessage = "wachtwoord is verplicht.")]
        [MinLength(8, ErrorMessage = "wachtwoord moet minimaal 8 tekens bevatten.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[!@#$&*]).+$",
            ErrorMessage = "wachtwoord moet minstens één hoofdletter en één uniek teken bevatten.")]
        public string wachtwoord { get; set; }

        [Required(ErrorMessage = "Zakelijke huurder ID is verplicht.")]
        public Guid zakelijkeHuurderId { get; set; } 

        public Guid WagenparkBeheerderId { get; set; }


        [Required]
        public string AspNetUserId { get; set; }
    }
}
