using CentralPesada.ColaImpresion.Aplicacion.Modelo;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPesada.ColaImpresion.Aplicacion.Servicio
{
    public class ColaImpresion
    {
        private RestClient _client;
        public void Abrir()
        {
            _client = new RestClient("https://medifarmadevqas-dev-cp-srv.cfapps.us10.hana.ondemand.com/browse/");

        }

        public ListaColaImpresion ObtenerColaImpresion()
        {
            var request = new RestRequest("/COLA_IMPRESION?$expand=oImpresora,oPlantilla,aVariables", Method.GET);
            var response = _client.Get<ListaColaImpresion>(request);

            return response.Data;
        }
        public void ActualizarColaImpresion(Modelo.Value colaImpresion) {
            var request = new RestRequest("/COLA_IMPRESION('" + colaImpresion.colaImpresionId + "')", Method.PUT);
            var obj = new Modelo.ColaImpresion();
            obj.colaImpresionId = colaImpresion.colaImpresionId;
            obj.oImpresora_impresoraId = colaImpresion.oImpresora_impresoraId;
            obj.oPlantilla_plantillaImpresionId = colaImpresion.oPlantilla_plantillaImpresionId;
            obj.enviado = true;
            obj.fechaActualiza = new DateTime();
            obj.usuarioActualiza = "SYS";

            request.AddJsonBody(obj);
            _client.Put(request);
        }

        public void Cerrar()
        {
            _client = null;
        }
    }
}
