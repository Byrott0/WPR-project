﻿using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WPR_project.Data;
using WPR_project.DTO_s;
using WPR_project.Models;
using WPR_project.Repositories;
using WPR_project.Services.Email;

namespace WPR_project.Services
{
    public class WagenparkBeheerderService
    {
        private readonly IWagenparkBeheerderRepository _repository;
        private readonly IZakelijkeHuurderRepository _zakelijkeHuurderRepository;
        private readonly IAbonnementRepository _abonnementRepository;
        private readonly IHuurVerzoekRepository _huurVerzoekRepository;
        private readonly IEmailService _emailService;
        private readonly GegevensContext _context;

        public WagenparkBeheerderService(
            IWagenparkBeheerderRepository repository,
            IZakelijkeHuurderRepository zakelijkeHuurderRepository,
            IAbonnementRepository abonnementRepository,
            IHuurVerzoekRepository huurVerzoekRepository,
            GegevensContext context,
            IEmailService emailService)
        {
            _repository = repository;
            _zakelijkeHuurderRepository = zakelijkeHuurderRepository;
            _abonnementRepository = abonnementRepository;
            _huurVerzoekRepository = huurVerzoekRepository;
            _context = context;
            _emailService = emailService;
        }

        public IEnumerable<WagenparkBeheerder> GetWagenparkBeheerders()
        {
            return _repository.GetWagenparkBeheerders();
        }

        public WagenparkBeheerder GetBeheerderById(Guid id)
        {
            return _repository.GetBeheerderById(id);
        }

        public void AddWagenparkBeheerder(WagenparkBeheerder beheerder)
        {
            _repository.AddWagenparkBeheerder(beheerder);
            _repository.Save();
        }

        public void UpdateWagenParkBeheerderAbonnement(Guid id, Guid abonnementId)
        {
            var existingBeheerder = _repository.GetBeheerderById(id);
            if (existingBeheerder != null)
            {
                existingBeheerder.AbonnementId = abonnementId;
                

                _repository.UpdateWagenparkBeheerder(existingBeheerder);
                _repository.Save();
            }
            else
            {
                throw new KeyNotFoundException("Beheerder niet gevonden.");
            }
        }

        public void UpdateWagenparkBeheerder(Guid id, WagenparkBeheerder beheerder)
        {
            var existingBeheerder = _repository.GetBeheerderById(id);
            if (existingBeheerder != null)
            {
                existingBeheerder.beheerderNaam = beheerder.beheerderNaam;
                existingBeheerder.bedrijfsEmail = beheerder.bedrijfsEmail;
                existingBeheerder.telefoonNummer = beheerder.telefoonNummer;

                _repository.UpdateWagenparkBeheerder(existingBeheerder);
                _repository.Save();
            }
            else
            {
                throw new KeyNotFoundException("Beheerder niet gevonden.");
            }
        }

        public void updateWagenparkBeheerderGegevens(Guid id, WagenparkBeheerderWijzigDTO dto)
        {
            var huurder = _repository.GetBeheerderById(id);
            if (huurder == null) throw new KeyNotFoundException("Huurder niet gevonden.");

            huurder.beheerderNaam = dto.beheerderNaam;
            huurder.bedrijfsEmail = dto.bedrijfsEmail;

            _repository.updateWagenparkBeheerderGegevens(huurder);
            _repository.Save();
        }

        public WagenparkBeheerderWijzigDTO GetGegevensById(Guid id)
        {
            var huurder = _repository.GetBeheerderById(id);
            if (huurder == null) return null;

            return new WagenparkBeheerderWijzigDTO
            {
                bedrijfsEmail = huurder.bedrijfsEmail,
                beheerderNaam = huurder.beheerderNaam,
            };

        }

        public void DeleteWagenparkBeheerder(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("ID is verplicht.");
            }

            try
            {
                var wagenparkBeheerder = _repository.GetBeheerderById(id);
                if (wagenparkBeheerder == null)
                {
                    throw new KeyNotFoundException("Wagenparkbeheerder niet gevonden.");
                }

                _repository.SetWagenparkBeheerderInactive(id);

                string bericht = $"Beste {wagenparkBeheerder.beheerderNaam},\n\nUw account is verwijderd.\n\nVriendelijke Groet,\nCarAndAll";
                _emailService.SendEmail(wagenparkBeheerder.bedrijfsEmail, "Account verwijderd", bericht);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }


        public Guid GetZakelijkeId(Guid id)
        {
            var zakelijkeId = _repository.GetZakelijkeId(id);
            if (zakelijkeId == Guid.Empty)
            {
                throw new KeyNotFoundException("Zakelijke ID niet gevonden.");
            }

            return zakelijkeId;
        }

        public Guid GetAbonnementId(Guid id)
        {
            var AbonnementID = _repository.GetAbonnementId(id);
            if (AbonnementID == Guid.Empty)
            {
                throw new KeyNotFoundException("Abonnement ID niet gevonden.");
            }

            return AbonnementID;
        }


        // Voeg een medewerker toe 
        public void VoegMedewerkerToe(Guid zakelijkeId, string medewerkerNaam, string medewerkerEmail, string wachtwoord)
        {
            // Controleer of de huurder bestaat
            var huurder = _zakelijkeHuurderRepository.GetZakelijkHuurderById(zakelijkeId);
            if (huurder == null)
                throw new KeyNotFoundException("Zakelijke huurder niet gevonden.");

            // Controleer of de medewerker al bestaat
            if (huurder.Medewerkers.Any(m => m.medewerkerEmail.Equals(medewerkerEmail, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Deze medewerker bestaat al.");

            // Maak een nieuwe medewerker aan
            var medewerker = new BedrijfsMedewerkers
            {
                bedrijfsMedewerkerId = Guid.NewGuid(),
                medewerkerNaam = medewerkerNaam,
                medewerkerEmail = medewerkerEmail,
                wachtwoord = wachtwoord, // Sla dit veilig op (versleutel bijvoorbeeld)
                zakelijkeId = zakelijkeId
            };

            // Voeg de medewerker toe aan de huurder
            huurder.Medewerkers.Add(medewerker);

            // Update de huurder in de repository
            _zakelijkeHuurderRepository.UpdateZakelijkHuurder(huurder);
            _zakelijkeHuurderRepository.Save();

            // Verstuur een e-mail naar de nieuwe medewerker
            string bericht = $"Beste {medewerkerNaam},\n\nU bent toegevoegd aan het bedrijfsaccount van {huurder.bedrijfsNaam}.";
            _emailService.SendEmail(medewerkerEmail, "Welkom bij het bedrijfsaccount", bericht);
        }

        public void ZetVoertuigenLimiet(Guid beheerderId, int nieuwLimiet)
        {
            var beheerder = _repository.GetBeheerderById(beheerderId);
            if (beheerder == null)
            {
                throw new KeyNotFoundException("Beheerder niet gevonden.");
            }
            beheerder.voertuiglimiet = nieuwLimiet;
            _repository.UpdateWagenparkBeheerder(beheerder);
            _repository.Save();
        }

        public void VerhoogVoertuigenLimiet(Guid beheerderId, int verhoging)
        {
            var beheerder = _repository.GetBeheerderById(beheerderId);
            if (beheerder == null)
            {
                throw new KeyNotFoundException("Beheerder niet gevonden.");
            }
            beheerder.voertuiglimiet += verhoging;
            _repository.UpdateWagenparkBeheerder(beheerder);
            _repository.Save();
        }

        public void VerlaagVoertuigenLimiet(Guid beheerderId, int verlaging)
        {
            var beheerder = _repository.GetBeheerderById(beheerderId);
            if (beheerder == null)
            {
                throw new KeyNotFoundException("Beheerder niet gevonden.");
            }
            if (beheerder.voertuiglimiet - verlaging >= 0)
            {
                beheerder.voertuiglimiet -= verlaging;
                _repository.UpdateWagenparkBeheerder(beheerder);
                _repository.Save();
            }
            else
            {
                throw new InvalidOperationException("Limiet kan niet negatief zijn.");
            }
        }
    
        // Verwijder een medewerker van een zakelijke huurder
        public void VerwijderMedewerker(Guid zakelijkeId, Guid medewerkerId)
        {
            var huurder = _zakelijkeHuurderRepository.GetZakelijkHuurderById(zakelijkeId);
            if (huurder == null)
                throw new KeyNotFoundException("Zakelijke huurder niet gevonden.");

            var medewerker = huurder.Medewerkers.FirstOrDefault(m => m.bedrijfsMedewerkerId == medewerkerId);
            if (medewerker == null)
                throw new KeyNotFoundException("Medewerker niet gevonden.");

            huurder.Medewerkers.Remove(medewerker);
            _zakelijkeHuurderRepository.UpdateZakelijkHuurder(huurder);
            _zakelijkeHuurderRepository.Save();

            string bericht = $"Beste {medewerker.medewerkerNaam},\n\nU bent verwijderd uit het bedrijfsaccount van {huurder.bedrijfsNaam}.";
            _emailService.SendEmail(medewerker.medewerkerEmail, "Medewerker verwijderd", bericht);
        }

        public string GetBeheerderEmailById(Guid zakelijkeId)
        {
            var beheerder = _context.WagenparkBeheerders.FirstOrDefault(b => b.beheerderId == zakelijkeId);
            return beheerder?.bedrijfsEmail;
        }

        public BedrijfsMedewerkers? GetMedewerkerById(Guid medewerkerId)
        {
            return _context.BedrijfsMedewerkers.FirstOrDefault(m => m.bedrijfsMedewerkerId == medewerkerId);
        }

        // Haal alle medewerkers van een zakelijke huurder op
        public IEnumerable<BedrijfsMedewerkers> GetMedewerkers(Guid zakelijkeId)
        {
            var huurder = _zakelijkeHuurderRepository.GetZakelijkHuurderById(zakelijkeId);
            if (huurder == null)
                throw new KeyNotFoundException("Zakelijke huurder niet gevonden.");

            return huurder.Medewerkers;
        }

        // Haal alle abonnementen van een zakelijke huurder op
        public IEnumerable<Abonnement> GetAbonnementen(Guid beheerderId)
        {
            var beheerder = _repository.GetBeheerderById(beheerderId);
            if (beheerder == null)
                throw new KeyNotFoundException("Wagenparkbeheerder niet gevonden.");

            // Correct filteren van abonnementen die gekoppeld zijn aan de beheerder
            return _abonnementRepository.GetAllAbonnementen()
                .Where(a => a.zakelijkeId == beheerderId)
                .ToList(); // Returnt een lijst met gefilterde abonnementen
        }


        public List<Guid> GetMedewerkersIdsByWagenparkbeheerder(Guid wagenparkbeheerderId)
        {
            // Haal de medewerkers-ID's op via de repository
            return _repository.GetMedewerkersIdsByWagenparkbeheerder(wagenparkbeheerderId);
        }

        public List<BedrijfsMedewerkers> GetMedewerkersByWagenparkbeheerder(Guid wagenparkbeheerderId)
        {
            // Haal de medewerkers-ID's op via de repository
            return _repository.GetMedewerkersByWagenparkbeheerder(wagenparkbeheerderId);
        }

        public IEnumerable<Huurverzoek> GetVerhuurdeVoertuigen(Guid medewerkerId)
        {
            var medewerker = _context.BedrijfsMedewerkers.FirstOrDefault(m => m.bedrijfsMedewerkerId == medewerkerId);
            if (medewerker == null)
                throw new KeyNotFoundException("Medewerker niet gevonden.");
            return _huurVerzoekRepository.GetAllHuurVerzoeken().Where(a => a.HuurderID == medewerkerId);
        }
    }
}

