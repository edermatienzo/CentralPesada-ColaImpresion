using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralPesada.ColaImpresion.Aplicacion.Modelo
{
    public class Impresora
    {
        public string terminal { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string usuarioRegistro { get; set; }
        public DateTime fechaActualiza { get; set; }
        public string usuarioActualiza { get; set; }
        public bool activo { get; set; }
        public string impresoraId { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public bool estadoImpresora { get; set; }
        public string serie { get; set; }
        public bool indicadorCp { get; set; }
        public bool indicadorPicking { get; set; }
        public bool indicadorEtiqueta { get; set; }
        public int oPlanta_iMaestraId { get; set; }
    }

    public class Plantilla
    {
        public object terminal { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string usuarioRegistro { get; set; }
        public DateTime? fechaActualiza { get; set; }
        public object usuarioActualiza { get; set; }
        public bool activo { get; set; }
        public string plantillaImpresionId { get; set; }
        public string descripcion { get; set; }
        public object nombre { get; set; }
        public string contenido { get; set; }
    }
    public class ColaImpresion
    {

        public object fechaActualiza { get; set; }
        public object usuarioActualiza { get; set; }

        public string colaImpresionId { get; set; }

        public bool enviado { get; set; }
        public string oImpresora_impresoraId { get; set; }
        public string oPlantilla_plantillaImpresionId { get; set; }
    }

    public class Variable
    {
        public string terminal { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string usuarioRegistro { get; set; }
        public object fechaActualiza { get; set; }
        public object usuarioActualiza { get; set; }
        public bool activo { get; set; }
        public string colaImpresionVariableId { get; set; }
        public string oColaImpresion_colaImpresionId { get; set; }
        public string codigo { get; set; }
        public string valor { get; set; }
    }

    public class Value
    {
        public string terminal { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string usuarioRegistro { get; set; }
        public object fechaActualiza { get; set; }
        public object usuarioActualiza { get; set; }
        public bool activo { get; set; }
        public string colaImpresionId { get; set; }
        public string descripcion { get; set; }
        public bool enviado { get; set; }
        public string oImpresora_impresoraId { get; set; }
        public string oPlantilla_plantillaImpresionId { get; set; }
        public Impresora oImpresora { get; set; }
        public Plantilla oPlantilla { get; set; }
        public List<Variable> aVariables { get; set; }
    }

    public class ListaColaImpresion
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }
        public List<Value> value { get; set; }
    }
}
