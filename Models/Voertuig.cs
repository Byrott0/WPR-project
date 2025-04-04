﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace WPR_project.Models
{
    public class Voertuig
    {

        [Key]
        public Guid voertuigId { get; set; }

        [Required]
        public string merk { get; set; }

        [Required]
        public string model { get; set; }

        [Required]
        public string kleur { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal prijsPerDag { get; set; }

        [Required]
        public string voertuigType { get; set; }

        [Required]
        public int bouwjaar { get; set; }

        [Required]
        public string kenteken { get; set; }


        public DateTime? startDatum { get; set; }


        public DateTime? eindDatum { get; set; }

        [Required]
        public bool voertuigBeschikbaar { get; set; }

        public string? notitie { get; set; }

        [JsonIgnore]
        public ICollection<Schademelding> Schademeldingen { get; set; }

        public int? AantalDeuren { get; set; }

        public int? AantalSlaapplekken { get; set; }

        public byte[]? Afbeelding { get; set; }

        public bool IsActive { get; set; } = true;

    }
}