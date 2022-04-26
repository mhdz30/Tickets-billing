using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace Presentacion
{
    public partial class Taquilleria : UserControl
    {

        N_fact n_Fact = new N_fact();
        CineMatinee001Entities4 cineMatinee = new CineMatinee001Entities4();
        D_fact d_Fact = new D_fact();

        public Taquilleria()
        {
            InitializeComponent();
            panel1.Location = new Point(40, 54);
        }
        private void LoadTickets()
        {
            N_fact n_ = new N_fact();
            dataGridView1.DataSource = n_.ShowTickets();
        }

        private void btnTaq_Click(object sender, EventArgs e)
        {
            panel1.Location = new Point(25, 66);
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;

            txtsala.Visible = true;
            txtcant.Visible = true;
            txtpu.Visible = true;
          
            txttotal.Visible = true;

            dataGridView1.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Location = new Point(267, 66);
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;

            txtsala.Visible = false;
            txtcant.Visible = false;
            txtpu.Visible = false;
           
            txttotal.Visible = false;

            btnprint.Visible = false;
            btnfact.Visible = false;

            dataGridView1.Visible = false;

        }
 
        private void Taquilleria_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cineMatinee.ShowCarteleraxFun();
            
        }
    

        private void btnfact_Click_1(object sender, EventArgs e)
        {
            
            float total;
            total = n_Fact.CALTotal(Convert.ToInt32(txtcant.Text), Convert.ToInt32(txtpu.Text));
            txttotal.Text = total.ToString();
           

        }
 

        private void btnprint_Click_1(object sender, EventArgs e)
        {
     
            using (CineMatinee001Entities4 bd = new CineMatinee001Entities4())
            {
                Facturacion tblfact = new Facturacion();
                tblfact.fecha_fact = dtimefact.Value;
                tblfact.fecha_valida = dtfechaval.Value;
                tblfact.Fun = txtfun.Text;
                tblfact.Descripcion_pelicula = txtpeli.Text;
                tblfact.Sala = txtsala.Text;
                tblfact.precio_unit = Convert.ToDouble(txtpu.Text);
                tblfact.cantidad_taq = Convert.ToInt32(txtcant.Text);
                tblfact.total = Convert.ToDouble(txttotal.Text);

                bd.Facturacion.Add(tblfact);
                bd.SaveChanges();
                MessageBox.Show("Facturado");
            }




        }

        private void txtcant_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtfun.Text = dataGridView1.CurrentRow.Cells["Funcion"].Value.ToString();
                txtsala.Text = dataGridView1.CurrentRow.Cells["Sala"].Value.ToString();
                txtpeli.Text = dataGridView1.CurrentRow.Cells["Pelicula"].Value.ToString();
                txtpu.Text = dataGridView1.CurrentRow.Cells["PrecioUnitario"].Value.ToString();

            }
            else
                MessageBox.Show("Debe seleccionar una fila");
        }

        private void bbtnbuscar_Click(object sender, EventArgs e)
        {
            ShowRegCartelera(txtpeli.Text, dtfechaval.Value);
        }
        private void ShowRegCartelera(string busquedaNomPeli, DateTime fechavalida)
        {
            dataGridView1.DataSource = d_Fact.ShowRegCartelera(busquedaNomPeli, fechavalida);
        }
    }
}
