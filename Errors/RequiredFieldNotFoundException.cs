using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.Errors
{
    public class RequiredFieldNotFoundException: Exception
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public RequiredFieldNotFoundException(string messag) : base(messag)
        { }

        public RequiredFieldNotFoundException(string field, string value) : base($"La valeur: {value} du champ requis: {field} n'existe pas")
        {
            this.Field = field;
            this.Value = value;
        }
    }
}
