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
    public partial class control_rrhh : UserControl
    {
        N_rrhh rrhh = new N_rrhh();
        CineMatinee001Entities4 cineMatinee = new CineMatinee001Entities4();
        private string Id_emp = null;
        //private bool Edit = false;

        public control_rrhh()
        {
            InitializeComponent();
            rrhh_nomina1.Hide();
            
        }

        private void control_rrhh_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = rrhh.ShowEmp();
        }

        private void btnnomina_Click(object sender, EventArgs e)
        {
            panel1.Location = new Point(315, 73);
            rrhh_nomina1.Show();
            rrhh_nomina1.BringToFront();
        }

        private void btnemp_Click(object sender, EventArgs e)
        {
            panel1.Location = new Point(33, 73); 
            rrhh_nomina1.Hide();
        }

        private void rrhh_nomina1_Load(object sender, EventArgs e)
        {

        }

        private void btnreg_Click(object sender, EventArgs e)
        {
            Empleado_ tblempleado = new Empleado_();
            tblempleado.Nombre_emp = txtnom.Text;
            tblempleado.Apellidos_emp = txtape.Text;
            tblempleado.fecha_nac = dtfechanac.Value;
            tblempleado.Sexo = txtsexo.Text;
            tblempleado.Telefono = txttel.Text;
            

            cineMatinee.Empleado_.Add(tblempleado);
            cineMatinee.SaveChanges();
            MessageBox.Show("Nuevo empleado registrado.");
            dataGridView1.DataSource = cineMatinee.Showempleado();
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //Edit = true;
                txtnom.Text = dataGridView1.CurrentRow.Cells["Nombre_emp"].Value.ToString();
                txtape.Text = dataGridView1.CurrentRow.Cells["Apellidos_emp"].Value.ToString();
                txtsexo.Text = dataGridView1.CurrentRow.Cells["sexo"].Value.ToString();
                dtfechanac.Text = dataGridView1.CurrentRow.Cells["fecha_nac"].Value.ToString();
                txttel.Text = dataGridView1.CurrentRow.Cells["Telefono"].Value.ToString();
                Id_emp = dataGridView1.CurrentRow.Cells["Id_emp"].Value.ToString();

            }
            else
                MessageBox.Show("Debe seleccionar una fila");

        }
        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
            
        }
    }
}
