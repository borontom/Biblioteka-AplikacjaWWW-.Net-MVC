using System;
using System.Collections.Generic;

namespace biblioteka___nowy_projekt.Models
{
    public partial class Czytelnik
    {
        public Czytelnik()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdCzytelnik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Miasto { get; set; }
        public string Telefon { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }

        public string ImieNazwisko
        {
            get
            {
                return Imie + " " + Nazwisko;
            }
        }

    }
}
