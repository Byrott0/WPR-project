﻿using WPR_project.Models;
using WPR_project.Repositories;
using WPR_project.Services.Email;

public class HuurVerzoekService
{
    private readonly IHuurVerzoekRepository _repository;
    private readonly IBedrijfsMedewerkersRepository _zakelijkRepository;
    private readonly IHuurderRegistratieRepository _particulierRepository;
    private readonly IEmailService _emailService;

    // Voeg de standaard ophaallocatie toe
    private const string OphaalLocatie = "Johanna Westerdijkplein 75, 2521 EP Den Haag";

    public HuurVerzoekService(
        IHuurVerzoekRepository repository,
        IBedrijfsMedewerkersRepository zakelijkRepository,
        IHuurderRegistratieRepository particulierRepository,
        IEmailService emailService)
    {
        _repository = repository;
        _zakelijkRepository = zakelijkRepository;
        _particulierRepository = particulierRepository;
        _emailService = emailService;
    }

    public bool HasActiveHuurverzoek(Guid huurderId)
    {
        return _repository.GetActiveHuurverzoekenByHuurderId(huurderId).Any();
    }

    public string GetEmailByHuurderId(Guid huurderId)
    {
        var particulier = _particulierRepository.GetById(huurderId);
        if (particulier != null)
        {
            return particulier.particulierEmail;
        }

        var zakelijk = _zakelijkRepository.GetMedewerkerById(huurderId);
        if (zakelijk != null)
        {
            return zakelijk.medewerkerEmail;
        }

        throw new Exception("Geen gebruiker gevonden met het opgegeven ID.");
    }

    private string GenerateEmailBody(DateTime beginDate, string emailType)
    {
        var typeTekst = emailType == "herinnering"
            ? "Dit is een herinnering dat uw huurperiode morgen begint op:"
            : "Uw huurverzoek is succesvol geregistreerd. Startdatum:";

        return $@"Beste gebruiker,<br/><br/>
                  {typeTekst} {beginDate}<br/>
                  Ophaallocatie: {OphaalLocatie}<br/><br/>
                  <strong>Veiligheidsinstructies:</strong><br/>
                  - Zorg ervoor dat u het voertuig controleert op schade vóór gebruik.<br/>
                  - Rijd altijd met een geldig rijbewijs en houd u aan de verkeersregels.<br/>
                  - In geval van problemen, neem contact op met onze klantenservice.<br/><br/>
                  <strong>Praktische informatie:</strong><br/>
                  - De sleutel kan worden opgehaald bij de receptie op de bovengenoemde locatie.<br/>
                  - Breng het voertuig op tijd terug om extra kosten te voorkomen.<br/><br/>
                  Met vriendelijke groet,<br/>Het Team";
    }

    public void Add(Huurverzoek huurverzoek)
    {
        if (huurverzoek.beginDate >= huurverzoek.endDate)
        {
            throw new ArgumentException("De begindatum kan niet na de einddatum liggen.");
        }

        var actieveHuurverzoeken = _repository.GetActiveHuurverzoekenByHuurderId(huurverzoek.HuurderID);
        if (actieveHuurverzoeken.Any())
        {
            throw new ArgumentException("De huurder heeft al een actief huurverzoek.");
        }

        _repository.Add(huurverzoek);

        var email = GetEmailByHuurderId(huurverzoek.HuurderID);
        var subject = "Bevestiging van uw huurverzoek";
        var body = GenerateEmailBody(huurverzoek.beginDate, "bevestiging");

        _emailService.SendEmail(email, subject, body);
    }

    public void SendReminders()
    {
        var reminderTime = DateTime.Now.AddHours(24);
        var huurverzoeken = _repository.GetHuurverzoekenForReminder(reminderTime);

        foreach (var verzoek in huurverzoeken)
        {
            try
            {
                var email = GetEmailByHuurderId(verzoek.HuurderID);
                var subject = "Herinnering: Uw huurperiode begint binnenkort";
                var body = GenerateEmailBody(verzoek.beginDate, "herinnering");

                _emailService.SendEmail(email, subject, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij het versturen van een herinneringsmail: {ex.Message}");
            }
        }
    }
}
