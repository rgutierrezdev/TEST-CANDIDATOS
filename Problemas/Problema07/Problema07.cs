using System;
using System.Linq;
using ConsoleApp.Problema07.Fakes;

namespace ConsoleApp.Problema07
{
    public class Problema07
    {
        public void RecuperarCuotasPorCancelacion(Seguro seguro, DateTime fechaCancelacion, DAOFactory daof)
        {
            var conceptosARecuperar = daof.GetDAO<ConceptoCuotaDAO>().BuscarPorAutomovilConFechaMayorIgualA(fechaCancelacion, seguro.Automovil);
            var conceptosDebitos = conceptosARecuperar.Where(concepto => concepto.TipoMovimiento == TipoMovimientoList.Debito).ToList();

            var conceptosCreditosYaRecuperados = conceptosARecuperar.Where(cc => cc.TipoMovimiento == TipoMovimientoList.Credito).ToList();
            conceptosARecuperar.Clear();

            foreach (var ccDeb in conceptosDebitos)
            {
                bool tieneRecuperoPrevio = false;

                foreach (var ccCred in conceptosCreditosYaRecuperados)
                {
                    if (ccDeb.PeriodoDesde == ccCred.PeriodoDesde && ccDeb.PeriodoHasta == ccCred.PeriodoHasta && ccDeb.Seguro.Id == ccCred.Seguro.Id)
                    {
                        tieneRecuperoPrevio = true;
                        break;
                    }
                }

                if (!tieneRecuperoPrevio)
                {
                    conceptosARecuperar.Add(ccDeb);
                }
            }

            foreach (var concepto in conceptosARecuperar)
            {
                var conceptoCredito = concepto.Clone();
                conceptoCredito.TipoMovimiento = TipoMovimientoList.Credito;

                concepto.Cuota.AddConcepto(conceptoCredito);
                concepto.Cuota.Monto = concepto.Cuota.Monto - conceptoCredito.Importe;

                daof.GetDAO<ConceptoCuotaDAO>().Save(conceptoCredito);
            }
        }
    }
}
