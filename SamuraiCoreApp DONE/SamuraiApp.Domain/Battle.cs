using System;
using System.Collections.Generic;

namespace SamuraiApp.Domain
{
    public class Battle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual List<Samurai> Samurais { get; set; }
        public virtual List<SamuraiBattle> SamuraiBattles { get; set; }
    }
}
