using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManejoExcepciones;

using Entidades;

namespace CapaPresentacion
{
    public delegate void MiDelegado();
    public partial class FrmProducto : Form
    {
        Producto auxProducto;
        public event MiDelegado miEvento;

        public FrmProducto()
        {
            InitializeComponent();

            miEvento += CargaDgv;
            miEvento += Cargarcombo;
            miEvento += CargaLisbox;
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            //Inventario.Iniciar();
            miEvento.Invoke();
        }
        private void btnAgregarFila_Click(object sender, EventArgs e)
        {
            double precio;
            int stock;
            int codigo;
            string descrip;
            try
            {
                precio = ValidacionesDeDatos.ValidarPrecio(this.TxtPrecio.Text);
                stock = ValidacionesDeDatos.ValidarEntero(this.TxtStock.Text);
                codigo = ValidacionesDeDatos.ValidarEntero(this.TxtCodigo.Text);
                descrip = ValidacionesDeDatos.ValidarDescripcion(this.TxtDescripcion.Text);

                switch ((Producto.ETipo)this.cmbTipos.SelectedValue)
                {
                    case Producto.ETipo.lacteo:
                        auxProducto = new ProductoPerecedero(descrip, codigo, precio, stock, (Producto.ETipo)this.cmbTipos.SelectedValue);
                        break;
                    case Producto.ETipo.bebidas:
                        auxProducto = new ProductoPerecedero(descrip, codigo, precio, stock, (Producto.ETipo)this.cmbTipos.SelectedValue);
                        break;
                    case Producto.ETipo.limpieza:
                        auxProducto = new ProductoNoPerecedero(descrip, codigo, precio, stock, (Producto.ETipo)this.cmbTipos.SelectedValue);
                        break;
                    case Producto.ETipo.perfumeria:
                        auxProducto = new ProductoNoPerecedero(descrip, codigo, precio, stock, (Producto.ETipo)this.cmbTipos.SelectedValue);
                        break;
                }

                if (Inventario.ListaProductos + auxProducto )
                {
                  
                     MessageBox.Show("Producto cargado con exitos", Inventario.NombreComercio);
                     MessageBox.Show(auxProducto.Mostrar(), Inventario.NombreComercio);
                  
                }
                else
                {
                    MessageBox.Show("Producto previamente cargados", Inventario.NombreComercio);
                    MessageBox.Show("Solo se modifico el stock disponibles", Inventario.NombreComercio);
                }
            }
            catch(BaseDeDatoException ex)
            {
                MessageBox.Show(ex.Message, Inventario.NombreComercio);
            }
            catch (Exception miErrorDatos)
            {
                MessageBox.Show(miErrorDatos.Message, Inventario.NombreComercio);
            }
            finally
            {
                miEvento.Invoke();
                this.Limpiar();
                
            }
        }
      
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Producto auxProducto;
            try
            {
                auxProducto = (Producto)this.LisEliminar.SelectedItem;

                if (MessageBox.Show("Seguro que quieres eliminar?", Inventario.NombreComercio, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (Inventario.ListaProductos - auxProducto)
                    {
                         MessageBox.Show("Se elimino correctamente", Inventario.NombreComercio);
                    }
                    else
                    {
                        MessageBox.Show("Error en la base de datos", Inventario.NombreComercio);
                    }
                }
            }
            catch(BaseDeDatoException bd)
            {
                MessageBox.Show(bd.Message);
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                miEvento.Invoke();
            } 
        }




        private void Limpiar()
        {
            this.TxtCodigo.Clear();
            this.TxtDescripcion.Clear();
            this.TxtPrecio.Clear();
            this.TxtStock.Clear();
        }

        public void Cargarcombo()
        {
            this.cmbTipos.DataSource = Enum.GetValues(typeof(Producto.ETipo));
        }

        public void CargaDgv()
        {
            this.DgvProductos.DataSource = null;
            this.DgvProductos.DataSource = Inventario.ListaProductos;
        }

        public void CargaLisbox()
        {
            this.LisEliminar.DataSource = null;
            this.LisEliminar.DataSource = Inventario.ListaProductos;
            this.LisEliminar.DisplayMember = "Descripcion";
        }
       
    }
}
