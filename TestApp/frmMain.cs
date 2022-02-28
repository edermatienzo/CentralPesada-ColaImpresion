using CentralPesada.ColaImpresion.Aplicacion.Negocio;
using CentralPesada.ColaImpresion.Aplicacion.Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            //RawPrinterHelper.SendStringToPrinter(cboPrinter.Text, txtData.Text);
            CentralPesada.ColaImpresion.Aplicacion.Negocio.ColaImpresion colaImpresion = new CentralPesada.ColaImpresion.Aplicacion.Negocio.ColaImpresion();
            colaImpresion.Iniciar();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var printers = PrinterSettings.InstalledPrinters;

            foreach (var printer in printers) {
                cboPrinter.Items.Add(printer);
            }
        }
    }
}
