using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FinancijskiVoditelj.Models
{
    /// <summary>
    /// Cost and cost data stored in the database.
    /// </summary>
    public class Cost
    {
        public int Id { get; set; }

        [DisplayName("Šifra kategorije troška")]
        public int CategoryCost { get; set; }

        [DisplayName("Šifra vrste troška")]
        public int TypeCost { get; set; }

        [DisplayName("Opis")]
        public string Description { get; set; }

        [DisplayName("Cijena")]
        public int Price { get; set; }

        [DisplayName("Datum")]
        public DateTime Date { get; set; }

        [DisplayName("Kategorija troška")]
        public string CategoryName { get; set; }

        [DisplayName("Vrsta troška")]
        public string TypeName { get; set; }

    }

}
