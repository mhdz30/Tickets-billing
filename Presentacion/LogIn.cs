using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Negocio;
using System.Net.NetworkInformation;

namespace Presentacion
{
    public partial class LogIn : Form
    {
        ConqBD conqBD = new ConqBD();
        N_fact n_Fact = new N_fact();
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text != "")
            {
                if (txtcontra.Text != "")
                {
                    var validarLogIn = n_Fact.LogInuser(txtusuario.Text, txtcontra.Text);


                    if (LBLMAC.Text != "")
                    {
                        var validarMac = conqBD.Mac(LBLMAC.Text);

                        if (validarLogIn == true)
                        {


                            if (validarMac == true)
                            {
                                Main main = new Main();
                                main.Show();
                                this.Hide();
                            }
                            else MessageBox.Show("Acceso Denegado!");

                        }
                        else
                        {
                            MessageBox.Show("Usuario o contrasena incorrecta. Por favor intentelo de nuevo.");
                            txtcontra.Clear();
                            txtusuario.Clear();
                            txtusuario.Focus();
                        }
                    }
                    else MessageBox.Show("Por favor introduzca su contrasena.");
                }
                else MessageBox.Show("Por favor introduzca su usuario.");

            }

        }

        private void GetMac()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }

            }
            LBLMAC.Text = sMacAddress;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            
        }

        private void LogIn_Load_1(object sender, EventArgs e)
        {
            GetMac();
        }
    }
}
