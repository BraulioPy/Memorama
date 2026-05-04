using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memorama.Controls.Components
{
    public partial class HistoricsComponent : UserControl
    {
        //Evento para visarle al MenuPrincipal que el usuario quiere regresar
        public event EventHandler OnRegresar;
        public HistoricsComponent()
        {
            InitializeComponent();
            CargarDatosPrueba();
        }
        //Funcion del click en buttonRegresar
        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            OnRegresar?.Invoke(this, EventArgs.Empty);
        }
        //datos de prueba para ver como se ve la tabla
        private void CargarDatosPrueba()
        {
            dgvHistoricos.Columns.Clear();

            dgvHistoricos.Columns.Add("Fecha","Fecha");
            dgvHistoricos.Columns.Add("Dificultad","Dificultad");
            dgvHistoricos.Columns.Add("Tiempo", "Tiempo");
            dgvHistoricos.Columns.Add("Intentos", "Intentos");

            dgvHistoricos.Rows.Add("03/05/2026", "Facil", "45s", "12");
            dgvHistoricos.Rows.Add("02/05/2026", "Intermedio", "89s", "24");
            dgvHistoricos.Rows.Add("03/05/2026", "Dificil", "75s", "30");
        }
    }
}
