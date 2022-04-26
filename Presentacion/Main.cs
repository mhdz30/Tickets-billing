using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Negocio;
using Data;
using Comun;



namespace Presentacion
{
    public partial class Main : Form
    {
        N_fact n_Fact = new N_fact();
        
        
       

        public Main()
        {
            InitializeComponent();
            MovePanel(btnTaq);
            taquilleria2.Hide();
            adm_op1.Hide();
            control_rrhh1.Hide();
           
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            MovePanel(btnTaq);
            adm_op1.Hide();

        }
        private void MovePanel(Control c)
        {
            panel2.Height = c.Height;
            panel2.Top = c.Top;
            taquilleria2.Show();
            taquilleria2.BringToFront();
               
        }

        private void btntcomida_Click(object sender, EventArgs e)
        {
            MovePanel(btntcomida);
        }

        private void btnadminO_Click(object sender, EventArgs e)
        {
            MovePanel(btnadminO);
            taquilleria2.Hide();
            adm_op1.Show();
            adm_op1.BringToFront();
        }

        private void btnrrhh_Click(object sender, EventArgs e)
        {
            MovePanel(btnrrhh);
            adm_op1.Hide();
            taquilleria2.Hide();
            control_rrhh1.Show();
            control_rrhh1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
 
            taquilleria2.Hide();
            adm_op1.Hide();
        }
        private void LoadUserData()
        {
            lbltipousu.Text = CacheUser.Tipo_usuario;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void control_rrhh1_Load(object sender, EventArgs e)
        {

        }
    }
}
   
