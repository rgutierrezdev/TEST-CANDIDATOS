using System;

namespace ConsoleApp.Problema07.Fakes
{
    public class ConceptoCuota
    {
        public Cuota Cuota { get; set; }
        public Seguro Seguro { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal Importe { get; set; }
        public DateTime PeriodoDesde { get; set; }
        public DateTime PeriodoHasta { get; set; }

        public ConceptoCuota Clone()
        {
            return new ConceptoCuota();
        }
    }
}
