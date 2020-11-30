using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ManejoExcepciones;

namespace Entidades
{
    public static class BaseDeDatos
    {
        #region Atributos
        private static SqlConnection conexion;
        private static SqlCommand comando;
        #endregion

        #region Constructor
        static BaseDeDatos(){

            conexion = new SqlConnection("data source=DESKTOP-3J3IBDL\\SQLEXPRESS01;initial catalog=Inventario;integrated security=true ");
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }
        #endregion

        #region Metodos
        /// <summary>
        ///  Lee los datos desde una tabla Productos.
        /// </summary>
        public static void GetProductos()
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "Select * From Productos";

                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                SqlDataReader datosDevueltos = comando.ExecuteReader();

                while (datosDevueltos.Read())
                {
                    string tipo = datosDevueltos["Tipo"].ToString();

                    if (tipo == "limpieza" || tipo == "perfume")
                    {
                        Inventario.ListaProductos.Add(new ProductoPerecedero(datosDevueltos["Descripcion"].ToString(),
                                        int.Parse(datosDevueltos["Codigo"].ToString()),
                                        int.Parse(datosDevueltos["Precio"].ToString()),
                                        int.Parse(datosDevueltos["Stock"].ToString()),
                                        (Producto.ETipo)Enum.Parse(typeof(Producto.ETipo), datosDevueltos["Tipo"].ToString())));
                    }
                    else
                    {
                        Inventario.ListaProductos.Add(new ProductoNoPerecedero(datosDevueltos["Descripcion"].ToString(),
                                        int.Parse(datosDevueltos["Codigo"].ToString()),
                                        double.Parse(datosDevueltos["Precio"].ToString()),
                                        int.Parse(datosDevueltos["Stock"].ToString()),
                                        (Producto.ETipo)Enum.Parse(typeof(Producto.ETipo), datosDevueltos["Tipo"].ToString())));
                    }

                }
                datosDevueltos.Close();
            }
            catch(Exception e)
            {
                throw new BaseDeDatoException("ERROR al cargar Leer dato :" + e.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Agrega un objeto producto ala tabla productos.
        /// </summary>
        /// <param name="p"></param>
        /// <returns>true si agrego correctamen, si no false.</returns>
        public static bool InsertaProducto(Producto p)
        {
            string sql = "Insert into Productos(codigo, descripcion, tipo, stock, precio) " +
                         "values(@auxcodigo, @auxdecripcion, @auxtipo, @auxstock, @auxprecio)";

            comando.Parameters.Add(new SqlParameter("@auxcodigo", p.Codigo));
            comando.Parameters.Add(new SqlParameter("@auxdecripcion", p.Descripcion));
            comando.Parameters.Add(new SqlParameter("@auxtipo", p.Tipo.ToString()));
            comando.Parameters.Add(new SqlParameter("@auxstock", p.Stock));
            comando.Parameters.Add(new SqlParameter("@auxprecio", p.Precio));

            return EjecutarNonQuery(sql);

        }
        /// <summary>
        /// Actualiza un producto en la tabla productos.
        /// </summary>
        /// <param name="p"></param>
        /// <returns>true si modifico correctamen, si no false.</returns>
        public static bool ActualizarProducto(Producto p)
        {
            string sql = "Update Productos Set codigo = @auxcodigo, descripcion = @auxDescripcion," +
                "tipo = @auxTipo, stock = @auxCantidad, precio = @auxPrecio where codigo = auxcodigo";

            comando.Parameters.Add(new SqlParameter("@auxcodigo", p.Codigo));
            comando.Parameters.Add(new SqlParameter("@auxDescripcion", p.Descripcion));
            comando.Parameters.Add(new SqlParameter("@auxPrecio", p.Precio));
            comando.Parameters.Add(new SqlParameter("@auxCantidad", p.Stock));
            comando.Parameters.Add(new SqlParameter("@auxTipo", p.Tipo.ToString()));

            return EjecutarNonQuery(sql);
        }
        /// <summary>
        /// Eliminia un producto en la tabla productos.
        /// </summary>
        /// <param name="p"></param>
        /// <returns>true si elimino correctamen, si no false.</returns>
        public static bool EliminarProductos(Producto p)
        {
            string sql = "Delete Productos where codigo = @auxcodigo";

            comando.Parameters.Add(new SqlParameter("@auxcodigo", p.Codigo));

            return EjecutarNonQuery(sql);
        }

        /// <summary>
        /// Ejecuta ExecuteNonQuery() en una conexion SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>True si se ejecuto, false caso contrario</returns>
        private static bool EjecutarNonQuery(string sql)
       {
            bool todoOk = false;
            try
            {
                BaseDeDatos.comando.CommandText = sql;

                BaseDeDatos.conexion.Open();

                BaseDeDatos.comando.ExecuteNonQuery();

                todoOk = true;
            }
            catch (Exception e)
            {
                todoOk = false;
            }
            finally
            {
                BaseDeDatos.conexion.Close();
            }
            return todoOk;
       }

        #endregion
    }
}
