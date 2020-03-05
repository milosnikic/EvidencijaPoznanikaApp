using System;
using System.Collections.Generic;

namespace EvidencijaPoznanika.API.Models
{
    public partial class Punoletni
    {
        public long Id { get; set; }
        public string MaticniBroj { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public short? Visina { get; set; }
        public short? Tezina { get; set; }
        public string BojaOciju { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public DateTime Rodjendan { get; set; }
        public string Adresa { get; set; }
        public string Prebivaliste { get; set; }
    }
}
