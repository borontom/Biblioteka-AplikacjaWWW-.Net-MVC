using System;
using System.Collections.Generic;

namespace biblioteka___nowy_projekt.Models
{
    public partial class Ksiazka
    {
        public Ksiazka()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdKsiazka { get; set; }
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public string Wydawnictwo { get; set; }
        public string RokWydania { get; set; }
        public int? KategorieId { get; set; }

        public virtual Kategoria Kategorie { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
