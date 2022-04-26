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
    public partial class Adm_op : UserControl
    {
        N_admCartelera n_AdmCartelera = new N_admCartelera();
        CineMatinee001Entities4 cineMatinee = new CineMatinee001Entities4();
        private string Id_Noregcar = null;
        private bool Edit = false;


        public Adm_op()
        {
            InitializeComponent();
            panel1.Location = new Point(35, 83);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void Hidecontrols()
        {
            label1.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label3.Visible = false;
            label9.Visible = false;
            label8.Visible = false;
            label7.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            label4.Visible = false;

            cmb1fun.Visible = false;
            cmbA.Visible = false;
            cmbB.Visible = false;
            cmbC.Visible = false;

            btnedit.Visible = false;
            btnsave.Visible = false;

            dtdesdeA.Visible = false;
            dtdesdeB.Visible = false;
            dtdesdeC.Visible = false;
            dthastaA.Visible = false;
            dthastaB.Visible = false;
            dthastaC.Visible = false;
            dtRegPeli.Visible = false;

            txtpeliA.Visible = false;
            txtpeliB.Visible = false;
            txtpeliC.Visible = false;
            txtpuA.Visible = false;
            txtpuB.Visible = false;
            txtpuC.Visible = false;

            dataGridView1.Visible = false;
        }
        private void Showcontrols()
        {
            label1.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label3.Visible = true;
            label9.Visible = true;
            label8.Visible = true;
            label7.Visible = true;
            label6.Visible = true;
            label5.Visible = true;
            label4.Visible = true;

            cmb1fun.Visible = true;
            cmbA.Visible = true;
            cmbB.Visible = true;
            cmbC.Visible = true;

            btnedit.Visible = true;
            btnsave.Visible = true;

            dtdesdeA.Visible = true;
            dtdesdeB.Visible = true;
            dtdesdeC.Visible = true;
            dthastaA.Visible = true;
            dthastaB.Visible = true;
            dthastaC.Visible = true;
            dtRegPeli.Visible = true;

            txtpeliA.Visible = true;
            txtpeliB.Visible = true;
            txtpeliC.Visible = true;
            txtpuA.Visible = true;
            txtpuB.Visible = true;
            txtpuC.Visible = true;

            dataGridView1.Visible = true;
        }
        private void ListFunc()
        {

            cmb1fun.DataSource = cineMatinee.ShowFun();
            cmb1fun.DisplayMember = "descrip_fun";
            cmb1fun.ValueMember = "Id_funcion";
            
        }
        private void ListSalas()
        {

            cmbA.DataSource = cineMatinee.ShowSala();
            cmbA.DisplayMember = "Descripcion_sala";
            cmbA.ValueMember = "Id_sala";


            cmbB.DataSource = cineMatinee.ShowSala();
            cmbB.DisplayMember = "Descripcion_sala";
            cmbB.ValueMember = "Id_sala";

            cmbC.DataSource = cineMatinee.ShowSala();
            cmbC.DisplayMember = "Descripcion_sala";
            cmbC.ValueMember = "Id_sala";

        }
    
        private void LoadCartelera()
        {
            N_admCartelera admCartelera = new N_admCartelera();
            dataGridView1.DataSource = admCartelera.ShowCartelera();
        }
        private void Adm_op_Load(object sender, EventArgs e)
        {
            LoadCartelera();
            ListFunc();
            ListSalas();

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            using (CineMatinee001Entities4 bd = new CineMatinee001Entities4())
            {
                if (Edit == false)
                    if (txtpeliA.Text != "")
                    {
                        try
                        {
                            //INSERTA SALA A
                               Cartelera tblcartelera = new Cartelera();
                            tblcartelera.Fechareg = dtRegPeli.Value;
                            tblcartelera.Id_funcion = Convert.ToInt32(cmb1fun.SelectedValue.ToString());
                            tblcartelera.Id_sala = Convert.ToInt32(cmbA.SelectedValue.ToString());
                            tblcartelera.descripcion_pelicula = txtpeliA.Text;
                            tblcartelera.FechaDispIni = dtdesdeA.Value;
                            tblcartelera.FechaDispFin = dthastaA.Value;
                            tblcartelera.precio_unit = Convert.ToDouble(txtpuA.Text);

                            bd.Cartelera.Add(tblcartelera);
                            bd.SaveChanges();


                            //INSERTA SALA B
                            Cartelera tblcarteler = new Cartelera();
                            tblcarteler.Fechareg = dtRegPeli.Value;
                            tblcarteler.Id_funcion = Convert.ToInt32(cmb1fun.SelectedValue.ToString());
                            tblcarteler.Id_sala = Convert.ToInt32(cmbB.SelectedValue.ToString());
                            tblcarteler.descripcion_pelicula = txtpeliB.Text;
                            tblcarteler.FechaDispIni = dtdesdeB.Value;
                            tblcarteler.FechaDispFin = dthastaB.Value;
                            tblcarteler.precio_unit = Convert.ToDouble(txtpuB.Text);
                            bd.Cartelera.Add(tblcarteler);
                            bd.SaveChanges();

                            //INSERTA SALA C
                            Cartelera tblcarteleraC = new Cartelera();
                            tblcarteleraC.Fechareg = dtRegPeli.Value;
                            tblcarteleraC.Id_funcion = Convert.ToInt32(cmb1fun.SelectedValue.ToString());
                            tblcarteleraC.Id_sala = Convert.ToInt32(cmbC.SelectedValue.ToString());
                            tblcarteleraC.descripcion_pelicula = txtpeliC.Text;
                            tblcarteleraC.FechaDispIni = dtdesdeC.Value;
                            tblcarteleraC.FechaDispFin = dthastaC.Value;
                            tblcarteleraC.precio_unit = Convert.ToDouble(txtpuC.Text);
                            bd.Cartelera.Add(tblcarteleraC);
                            bd.SaveChanges();


                            MessageBox.Show("Peliculas registradas");
                              LoadCartelera();



                          
                        } 
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo insertar los datos por:" + ex);
                        }

                    }
                    else MessageBox.Show("No ha introducido datos aun.");
                txtpeliA.Focus();


                if (Edit == true)
                {
                    try
                    {
                        n_AdmCartelera.EditCartelera(dtRegPeli.Value.ToString(), cmb1fun.SelectedValue.ToString(), cmbB.SelectedValue.ToString(),
                        txtpeliB.Text, dtdesdeB.Value.ToString(), dthastaB.Value.ToString(), txtpuB.Text, Id_Noregcar);
                        MessageBox.Show("Se edito correctamente.");
                    
                        LoadCartelera();
                       
                        Edit = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se puede Editar los datos por: " + ex);
                    }

                }



            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Edit = true;
                dtRegPeli.Text = dataGridView1.CurrentRow.Cells["FechaReg"].Value.ToString();
                cmb1fun.Text = dataGridView1.CurrentRow.Cells["Funcion"].Value.ToString();
                cmbB.Text = dataGridView1.CurrentRow.Cells["Sala"].Value.ToString();
                txtpeliB.Text = dataGridView1.CurrentRow.Cells["Pelicula"].Value.ToString();
                dtdesdeB.Text = dataGridView1.CurrentRow.Cells["Desde"].Value.ToString();
                dthastaB.Text = dataGridView1.CurrentRow.Cells["Hasta"].Value.ToString();
                txtpuB.Text = dataGridView1.CurrentRow.Cells["PrecioUnitario"].Value.ToString();
                Id_Noregcar = dataGridView1.CurrentRow.Cells["Numero"].Value.ToString();

            }
            else
                MessageBox.Show("Debe seleccionar una fila");
        }

        private void btncuadre_Click(object sender, EventArgs e)
        {
            panel1.Location = new Point(317, 83);
            Hidecontrols();


        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            panel1.Location = new Point(35, 83);
            Showcontrols();
         
        }
    }
}
