using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TooSharp.Models;

namespace EjercicioKury
{
    public partial class AgregarEditar : Form
    {
        Producto _Producto = null;

        public AgregarEditar()
        {
            InitializeComponent();
        }
        public AgregarEditar(Producto producto)
        {
            InitializeComponent();
            btn1.Text = "Update";
            btn2.Visible = true;
            _Producto = producto;
            //Validacion
            _Producto.onValidationError += Producto_onValidationError;
            txtNombre.Text = _Producto.Nombre;
            txtPrecio.Text = _Producto.Precio;
        }
        void MostrarError(String Text)
        {
            lblError.Text = Text;
            pnlError.Visible = true;
            tmrError.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AgregarEditar_Load(object sender, EventArgs e)
        {

        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tmrError_Tick(object sender, EventArgs e)
        {
            tmrError.Stop();
            pnlError.Visible = false;
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            if (_Producto == null)
            {
                //Nuevo contacto
                Producto producto = new Producto()
                {
                    Nombre = txtNombre.Text,
                    Precio = txtPrecio.Text
                };
                
                //Validacion
                producto.onValidationError += Producto_onValidationError;

                //Guardado
                if (producto.Save() > 0)
                {
                    MessageBox.Show("Producto Guardado");
                 this.Close();
                }
            }
            else
            {
                //Actualizar Contacto

                _Producto.Nombre = txtNombre.Text;
                _Producto.Precio = txtPrecio.Text;

                if (_Producto.Save() > 0)
                {
                    MessageBox.Show("Producto Actualizado");
                 this.Close();
                }


            }
        }

        private void Producto_onValidationError(object sender, TooSharp.Core.TsExeptionArgs e)
        {
            MostrarError(e.exception.Message);
        }
    }
}
