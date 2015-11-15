using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphSimulation
{
    public partial class AgregarArcos : Form
    {
        public bool control;

        public AgregarArcos()
        {
            InitializeComponent();
            control = false;
        }

        public void Refresh(List<string> C)
        {
            cmbNodoInicial.Items.Clear();
            cmbNodoFinal.Items.Clear();

            foreach (string miItem in C)
            {
                cmbNodoInicial.Items.Add(miItem);
                cmbNodoFinal.Items.Add(miItem);
            }
            cmbNodoInicial.SelectedIndex = 0;
            cmbNodoFinal.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbNodoInicial.SelectedIndex == cmbNodoFinal.SelectedIndex)
            {
                MessageBox.Show("Debe seleccionar dos nodos diferentes.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            control = true;
            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            control = false;
            this.Hide();
        }

        private void AgregarArcos_Shown(object sender, EventArgs e)
        {
            txtValor.Clear();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
