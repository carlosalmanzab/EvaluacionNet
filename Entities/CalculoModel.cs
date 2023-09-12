using System;

namespace EvaluacionNet.Entities
{
    public class CalculoModel
    {
        public int? Id { get; set; }
        public String Usuario { get; set; }
        public int? limite { get; set; }
        public int? Valor { get; set; }
        public DateTime? Fecha { get; set; }

    }
}
