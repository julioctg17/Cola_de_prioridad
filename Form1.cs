using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cola_de_prioridad
{
    public partial class Form1 : Form
    {
        private List<int> colaPrioridad = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEncolar_Click(object sender, EventArgs e)
        {
            // Validar entrada
            if (int.TryParse(txtNumero.Text, out int valor))
            {
                colaPrioridad.Add(valor);
                ActualizarLista();
                txtNumero.Clear();
                txtNumero.Focus();
            }
            else
            {
                MessageBox.Show("Ingrese un número válido.");
            }

        }

        private void btnDesencolar_Click(object sender, EventArgs e)
        {
            if (colaPrioridad.Count == 0)
            {
                MessageBox.Show("La cola está vacía.");
                return;
            }

            // Buscar el número mayor (mayor prioridad)
            int mayor = colaPrioridad.Max();
            colaPrioridad.Remove(mayor);

            MessageBox.Show($"Se atendió el elemento con prioridad: {mayor}");
            ActualizarLista();

        }
        private void ActualizarLista()
        {
            // Mostrar cola ordenada (de mayor a menor)
            lstCola.Items.Clear();
            foreach (int n in colaPrioridad.OrderByDescending(x => x))
            {
                lstCola.Items.Add(n);
            }
        }
    }
}
