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
    public partial class Arco : Form
    {
        public bool control; // variable de control
        public string dato; // el dato que almacenará el arco

        public Arco()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string valor = txtArco.Text.Trim();
            if ((valor == "") || (valor == " ") )
            {
                MessageBox.Show("Es necesario ingresar un valor", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else if (int.Parse(valor) <= 0)
            {
                MessageBox.Show("Valor ingresado Invalido", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txtArco.Text = "";
            }
            else
            {
                control = true;
               this.Hide();
            }
        }

        private void Arco_Load(object sender, EventArgs e)
        {
            txtArco.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            control = false;
            this.Hide();
        }

        private void Arco_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void Arco_Shown(object sender, EventArgs e)
        {
            txtArco.Clear();
            txtArco.Focus();
        }

        private void txtArco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(null, null);
            }
        }

        private void txtArco_KeyPress(object sender, KeyPressEventArgs e)
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
