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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }


        void Recargar()
        {
            if (txtBuscar.Text.Trim().Length > 0)
            {
                DatosPopulares(Productos.Records()
                    .Where(Productos.COLUMNS.nombre,"LIKE","%"+txtBuscar.Text+"%")
                    .Get());
            }
            else
            {
                DatosPopulares(Productos.Records().Get());

            }
        }

        void DatosPopulares(IEnumerable<Producto>productos)
        {
            tabla.Rows.Clear();
            foreach (var p in productos)
            {
                tabla.Rows.Add(new object[]{
                    p.Id_producto,
                    p.Nombre,
                    p.Precio,
                    "Editar",
                    "Eliminar"

                    });
                tabla.Rows[tabla.RowCount - 1].Tag = p;
            }

        }

        private void frmProductos_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            Recargar();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AgregarEditar().ShowDialog();
            Recargar();
        }

        private void tabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmProductos_Shown(object sender, EventArgs e)
        {
            Recargar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Recargar();
        }

        private void tabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)//Editar
            {
                new AgregarEditar((Producto)tabla.CurrentRow.Tag).ShowDialog();
                Recargar();
            }
            if (e.ColumnIndex == 4)//Eliminar
            {
                Producto producto = (Producto)tabla.CurrentRow.Tag;
                if (MessageBox.Show("¿Eliminar "+ producto.Nombre +" ?","Confirmar",MessageBoxButtons.YesNoCancel)==DialogResult.Yes) {
                    producto.Delete();
                    Recargar();
                
                }

            }
        }
    }
}
