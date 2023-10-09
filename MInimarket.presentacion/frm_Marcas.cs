using Minimarket.Negocio;
using MInimarket.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MInimarket.presentacion
{
    public partial class frm_Marcas : Form
    {
        public frm_Marcas()
        {
            InitializeComponent();
        }

        #region Variables
        int codigo_marca;
        int estadoInicial=0;
        int EstadoGuarda = 0;
        string rpta = "";
        #endregion

        #region Instancias
        N_Marcas marcas = new N_Marcas();
        #endregion
        private void frm_Marcas_Load(object sender, EventArgs e)
        {
            Listado();
        }

        #region Presentacion
        private void EstadoInicialData()
        {
            dgvMarcas.Columns[0].Width = 100;
            dgvMarcas.Columns[0].HeaderText = "CÓDIGO";
            dgvMarcas.Columns[1].Width = 300;
            dgvMarcas.Columns[1].HeaderText = "MARCA";
        }
        private void EstadoBotones_Principales(bool lEstado)
        {
            this.btnNuevo.Enabled = lEstado;
            this.btnactualizar.Enabled = lEstado;
            this.btnEliminar.Enabled = lEstado;
            this.btnReporte.Enabled = lEstado;
        }

        private void EstadoBotones(bool lEstado)
        {
            this.btnCancelar.Visible = lEstado;
            this.btnGuardar.Visible = lEstado;
            this.btnRetomar.Visible = lEstado;
        }

        private void Selecciona_Item()
        {
            //valida si el datagrid tiene informacion
            if (string.IsNullOrEmpty(Convert.ToString(dgvMarcas.CurrentRow.Cells["cod_marcas"].Value)))
            //el nombre de la columna a travez del data source adquiere el nombre del campo, cod_categ
            {
                MessageBox.Show("No se tiene informaciòn para visualizar", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.codigo_marca = Convert.ToInt32(dgvMarcas.CurrentRow.Cells["cod_marcas"].Value);
                txtDescripcion.Text = Convert.ToString(dgvMarcas.CurrentRow.Cells["descripcion_ma"].Value);
            }

        }
        #endregion

        private void Listado()
        {
            try
            {
                dgvMarcas.DataSource = N_Marcas.ListadoMarcas();
                this.EstadoInicialData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estadoInicial = 1;
            this.EstadoBotones_Principales(false);
            this.EstadoBotones(true);
            txtDescripcion.Text = "";
            txtDescripcion.ReadOnly = false;
            tbListado.SelectedIndex = 1;
            txtDescripcion.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == string.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                E_Marca eMarca = new E_Marca();
                string rpta = "";
                eMarca.Codigo_Marca = this.codigo_marca;
                eMarca.Descripcion_Marca = txtDescripcion.Text.Trim();
                rpta = N_Marcas.Guardar_Marcas(estadoInicial,eMarca);
                if (rpta =="OK")
                {
                    Listado();
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRetomar_Click(object sender, EventArgs e)
        {

        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            EstadoGuarda = 2;//actualiza registro
            this.EstadoBotones_Principales(false);
            //this.Estado_Botonesprocesos(true);
            this.Selecciona_Item();
            //tbp_principal.SelectedIndex = 1;
            //txt_Descripcion.ReadOnly = false;
            //txt_Descripcion.Focus();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_principal.CurrentRow.Cells["cod_marcas"].Value)))
            //el nombre de la columna a travez del data source adquiere el nombre del campo, cod_categ
            {
                MessageBox.Show("No se tiene informaciòn para visualizar", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Estas seguro de eliminar el registro seleccionado", "Aviso del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.Yes)
                {
                    string rpta = "";
                    this.Codigo_ca = Convert.ToInt32(dgv_principal.CurrentRow.Cells["cod_categ"].Value);
                    rpta = N_Categorias.Eliminar_ca(this.Codigo_ca);
                    if (rpta.Equals("OK"))
                    {
                        this.Listado_ca("%");
                        this.Codigo_ca = 0;
                        MessageBox.Show("Registro eliminado", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }

        }
    }
}
