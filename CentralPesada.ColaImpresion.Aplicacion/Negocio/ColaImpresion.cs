using CentralPesada.ColaImpresion.Aplicacion.Servicio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CentralPesada.ColaImpresion.Aplicacion.Negocio
{
    public class ColaImpresion
    {
        public async void Iniciar() {

            //if (!EventLog.SourceExists("ColaImpresion")){
            //    EventLog.CreateEventSource("ColaImpresion", "Application");
            //}
            EventLog log = new EventLog();
            log.Source = "ColaImpresion";


            Servicio.ColaImpresion colaImpresion = new Servicio.ColaImpresion();

            colaImpresion.Abrir();

            var lista = colaImpresion.ObtenerColaImpresion();
            foreach (var cola in lista.value)
            {
                if (!cola.enviado)
                {
                    string plantilla = cola.oPlantilla.contenido;

                    foreach (var variable in cola.aVariables)
                    {
                        plantilla = plantilla.Replace(variable.codigo, variable.valor);
                    }

                    try
                    {

                        //log.WriteEntry("Enviando a Impresion " + cola.colaImpresionId, EventLogEntryType.Information);
                        if (RawPrinterHelper.SendStringToPrinter(cola.oImpresora.direccion, plantilla))
                        {
                            colaImpresion.ActualizarColaImpresion(cola);
                        }
                    }
                    catch (Exception ex)
                    {
                        log.WriteEntry(ex.ToString(), EventLogEntryType.Information);
                    }
                    Thread.Sleep(1000);
                }
            }

        }
    }
}
