using System;
using System.Collections.Generic;

namespace biblioteka___nowy_projekt.Models
{
    public partial class Zamowienie
    {
        public int IdZamowienie { get; set; }
        public int? CzytelnikId { get; set; }
        public int? KsiazkaId { get; set; }
        public DateTime? DataZamowienia { get; set; }

        public virtual Czytelnik Czytelnik { get; set; }
        public virtual Ksiazka Ksiazka { get; set; }
    }
}
