using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.Errors
{
    public class RessourceNotFoundException: Exception
    {
        public string Ressource { get; set; }
        public string Value { get; set; }

        public RessourceNotFoundException(string ressource, string value) : base($"La ressource {value} de type {ressource} n'est pas trouvée")
        {
            this.Ressource = ressource;
            this.Value = value;
        }
    }
}
