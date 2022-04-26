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

namespace Presentacion
{
    public partial class rrhh_nomina : UserControl
    {
        N_rrhh n_Rrhh = new N_rrhh();
        CineMatinee001Entities4 cineMatinee = new CineMatinee001Entities4();
        float sb, sn, ars, afp, td, isr;

        private void btnselect_Click(object sender, EventArgs e)
        {
            if (dgvemp.SelectedRows.Count > 0)
            {
                txtcodemp.Text = dgvemp.CurrentRow.Cells["Id_emp"].Value.ToString();
                txtnom.Text = dgvemp.CurrentRow.Cells["Nombre_emp"].Value.ToString();
                txtape.Text = dgvemp.CurrentRow.Cells["Apellidos_emp"].Value.ToString();
                

            }
            else
                MessageBox.Show("Debe seleccionar una fila");
        }

        private void btnreg_Click(object sender, EventArgs e)
        {
            using (CineMatinee001Entities4 bd = new CineMatinee001Entities4())
            {
                Nomina_rrhh tblnomina = new Nomina_rrhh();
                tblnomina.fecha_nomina = dtnomina.Value;
                tblnomina.Nombre_emp = txtnom.Text;
                tblnomina.Nombre_apellidos = txtape.Text;
                tblnomina.sueldo_bruto = Convert.ToDouble(txtsb.Text);
                tblnomina.afp = Convert.ToDouble(txtafp.Text);
                tblnomina.ars = Convert.ToDouble(txtars.Text);
                tblnomina.Impuesto = Convert.ToDouble(txtimp.Text);
                tblnomina.total_des = Convert.ToInt32(txttd.Text);
                tblnomina.sueldo_neto = Convert.ToDouble(txtsn.Text);

                bd.Nomina_rrhh.Add(tblnomina);
                bd.SaveChanges();
                MessageBox.Show("Se inserto correctamente.");
                dgvnomina.DataSource = cineMatinee.ShoweNom();
            }
        }

        public rrhh_nomina()
        {
            InitializeComponent();
        }

        private void rrhh_nomina_Load(object sender, EventArgs e)
        {
            dgvemp.DataSource = n_Rrhh.ShowEmp();
            dgvnomina.DataSource = cineMatinee.ShoweNom();
        }

        private void btncal_Click(object sender, EventArgs e)
        {
            if (txtsb.Text != "")
            {
              
                sb = float.Parse(txtsb.Text);

                afp = n_Rrhh.Afp(sb);
                txtafp.Text = afp.ToString();

                ars = n_Rrhh.Ars(sb);
                txtars.Text = ars.ToString();

                isr = n_Rrhh.Impuesto(sb);
                txtimp.Text = isr.ToString();

                td = n_Rrhh.Total_descuento(isr, afp, ars);
                txttd.Text = td.ToString();

                sn = n_Rrhh.Sueldo_neto(sb, td);
                txtsn.Text = sn.ToString();

            }
            else
            {
                MessageBox.Show("Por favor digite sueldo bruto");
            }
        }
    }
}
