using System;
using System.Collections.Generic;

namespace biblioteka___nowy_projekt.Models
{
    public partial class Kategoria
    {
        public Kategoria()
        {
            Ksiazka = new HashSet<Ksiazka>();
        }

        public int IdKategoria { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Ksiazka> Ksiazka { get; set; }
    }
}
