using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using TiendaElectronica_Entidades;


namespace TiendaElectronica_Datos
{
    public class DatosProfesionales : DatosConexionBD
    {

        // Método para obtener todos los productos
        public List<Producto> ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (OleDbConnection connection = new OleDbConnection(cadenaConexion))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM Productos", connection);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    productos.Add(new Producto
                    {
                        Id = (int)reader["Id"],
                        Nombre = (string)reader["Nombre"],
                        Marca = (string)reader["Marca"],
                        Categoria = (string)reader["Categoria"],
                        Precio = (decimal)reader["Precio"],
                        Stock = (int)reader["CantidadEnStock"]
                    });
                }
            }

            return productos;
        }

        // Método para buscar productos por categoría
        public List<Producto> BuscarPorCategoria(string categoria)
        {
            List<Producto> productos = new List<Producto>();

            using (OleDbConnection connection = new OleDbConnection(cadenaConexion))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM Productos WHERE Categoria = @Categoria", connection);
                command.Parameters.AddWithValue("@Categoria", categoria);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    productos.Add(new Producto
                    {
                        Id = (int)reader["Id"],
                        Nombre = (string)reader["Nombre"],
                        Marca = (string)reader["Marca"],
                        Categoria = (string)reader["Categoria"],
                        Precio = (decimal)reader["Precio"],
                        Stock = (int)reader["CantidadEnStock"]
                    });
                }
            }

            return productos;
        }

        // Método para insertar un nuevo producto
        public void InsertarProducto(Producto producto)
        {
            using (OleDbConnection connection = new OleDbConnection(cadenaConexion))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("Insert into Productos (Nombre, Marca, Categoria, Precio, CantidadEnStock) Values (@Nombre, @Marca, @Categoria, @Precio, @CantidadEnStock)", connection);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Marca", producto.Marca);
                command.Parameters.AddWithValue("@Categoria", producto.Categoria);
                command.Parameters.AddWithValue("@Precio", producto.Precio);
                command.Parameters.AddWithValue("@CantidadEnStock", producto.Stock);

                command.ExecuteNonQuery();
            }
        }

        // Método para actualizar un producto existente
        public void ActualizarProducto(Producto producto)
        {
            using (OleDbConnection connection = new OleDbConnection(cadenaConexion))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(
                    "UPDATE Productos " +
                    "SET Nombre = @Nombre," +
                    " Marca = @Marca, Categoria = @Categoria, " +
                    "Precio = @Precio, CantidadEnStock = " +
                    "@Stock WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Marca", producto.Marca);
                command.Parameters.AddWithValue("@Categoria", producto.Categoria);
                command.Parameters.AddWithValue("@Precio", producto.Precio);
                command.Parameters.AddWithValue("@CantidadEnStock", producto.Stock);
                command.Parameters.AddWithValue("@Id", producto.Id);

                command.ExecuteNonQuery();
            }
        }

        // Método para eliminar un producto por su Id
        public void EliminarProducto(int id)
        {
            using (OleDbConnection connection = new OleDbConnection(cadenaConexion))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("DELETE FROM Productos WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}

