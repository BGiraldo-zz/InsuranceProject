using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.AggregatesModel.PolicyAggregate
{
    public class RiskTypeEnum
    {
        public const string Bajo = "Bajo";
        public const string Medio = "Medio";
        public const string MedioAlto = "Medio-Alto";
        public const string Alto = "Alto";
    }
}
