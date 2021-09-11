using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.Errors
{
    public class InUseException: Exception
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public InUseException(string messag): base(messag)
        {}

        public InUseException(string field, string value): base($"La valeur: {value} du champ: {field} est deja utilisée")
        {
            this.Field = field;
            this.Value = value;
        }
    }
}
