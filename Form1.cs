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
        class Paciente
        {
            public string Nombre { get; set; }
            public int Prioridad { get; set; }

            public override string ToString()
            {
                string tipo;

                switch (Prioridad)
                {
                    case 3:
                        tipo = "Alta";
                        break;
                    case 2:
                        tipo = "Media";
                        break;
                    case 1:
                        tipo = "Baja";
                        break;
                    default:
                        tipo = "Desconocida";
                        break;
                }

                return $"{Nombre} (Prioridad: {tipo})";
            }
        }

        private List<Paciente> cola = new List<Paciente>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEncolar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || cmbPrioridad.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese un nombre y seleccione una prioridad.");
                return;
            }

            Paciente nuevo = new Paciente()
            {
                Nombre = txtNombre.Text,
                Prioridad = int.Parse(cmbPrioridad.SelectedItem.ToString())
            };

            cola.Add(nuevo);
            ActualizarLista();
            txtNombre.Clear();
            cmbPrioridad.SelectedIndex = -1;

        }

        private void btnDesencolar_Click(object sender, EventArgs e)
        {
            if (cola.Count == 0)
            {
                MessageBox.Show("No hay pacientes en espera.");
                return;
            }

            // Busca el paciente con mayor prioridad
            int maxPrioridad = cola.Max(p => p.Prioridad);
            Paciente siguiente = cola.First(p => p.Prioridad == maxPrioridad);

            cola.Remove(siguiente);
            MessageBox.Show($"Atendiendo a: {siguiente.Nombre} (Prioridad: {siguiente.Prioridad})");
            ActualizarLista();

        }
        private void ActualizarLista()
        {
            lstCola.Items.Clear();
            foreach (Paciente p in cola.OrderByDescending(p => p.Prioridad))
            {
                lstCola.Items.Add(p);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
