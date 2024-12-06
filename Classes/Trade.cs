using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRQCS.Interfaces;

namespace BRQCS.Classes
{
    class Trade : ITrade
    {
        public double Value { get; }
        public string ClientSector { get; }
        public DateTime NextPaymentDate { get; }

        public Trade(double value, string clientSector, DateTime nextPaymentDate)
        {
            Value = value;
            ClientSector = clientSector;
            NextPaymentDate = nextPaymentDate;
        }

        public string Calculate(DateTime refDate)
        {
            if ((refDate.Date - NextPaymentDate.Date).Days > 30)
                return "EXPIRED";

            if (ClientSector != "Public" && ClientSector != "Private")
                return "ERROR";

            if (Value > 1000000 && ClientSector == "Private")
                return "HIGHRISK";

            if (Value > 1000000 && ClientSector == "Public")
                return "MEDIUMRISK";

            return "-";
        }
    }
}
