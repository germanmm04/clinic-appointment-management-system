using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica
{
    public class Gestion
    {
        public static int AgregarCliente(Cliente cliente) //Metodo para agregar clientes
        {
            int retorna = 0;

            try
            {
                using (SqlConnection conexion = BaseDatos.ObtenerConexion()) //Usamos la conexion a la BD
                {   //Consulta para insertar todos los campos
                    string query = @"INSERT INTO Clientes (DNI, Nombre, Apellidos, Direccion, Telefono, CP, Localidad, Provincia, CorreoE, Observaciones)
                             VALUES (@DNI, @Nombre, @Apellidos, @Direccion, @Telefono, @CP, @Localidad, @Provincia, @CorreoE, @Observaciones)";

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        //Agregar los valores que hemos añadido del cliente a la consulta
                        command.Parameters.AddWithValue("@DNI", cliente.Dni);
                        command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                        command.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                        command.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                        command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                        command.Parameters.AddWithValue("@CP", cliente.CodigoPostal);
                        command.Parameters.AddWithValue("@Localidad", cliente.Localidad);
                        command.Parameters.AddWithValue("@Provincia", cliente.Provincia);
                        command.Parameters.AddWithValue("@CorreoE", cliente.CorreoElec);
                        command.Parameters.AddWithValue("@Observaciones", cliente.Observaciones);

                        retorna = command.ExecuteNonQuery(); //Ejecuta el comando
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) //Manejar la excepcion si itentamos añadir un cliente con DNI ya existente
                {
                    MessageBox.Show("Ya existe un cliente con ese DNI");
                }
                else
                {
                    MessageBox.Show("Error al guardar el cliente");
                }
            }

            return retorna;
        }

        public static int AgregarMascota(Mascota mascota) //Metodo para agregar mascotas
        {
            int retorna = 0;

            try
            {
                using (SqlConnection conexion = BaseDatos.ObtenerConexion()) //Usamos la conexion a la BD
                {   //Consulta para insertar todos los campos
                    string query = @"INSERT INTO Mascotas (Nombre, Especie, Raza, Nacimiento, Notas, DNICliente)
                    VALUES (@Nombre, @Especie, @Raza, @Nacimiento, @Notas, @DNIClientes)";

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        //Agregar todos los valores que hemos añadido de la mascota a la consulta
                        command.Parameters.AddWithValue("@Nombre", mascota.Nombre);
                        command.Parameters.AddWithValue("@Especie", mascota.Especie);
                        command.Parameters.AddWithValue("@Raza", mascota.Raza);
                        command.Parameters.AddWithValue("@Nacimiento", Convert.ToDateTime(mascota.FechaNac));
                        command.Parameters.AddWithValue("@Notas", mascota.Notas);
                        command.Parameters.AddWithValue("@DNIClientes", mascota.DNICliente);

                        retorna = command.ExecuteNonQuery(); //Ejecutamos el comando
                    }
                }

            }catch (SqlException ex) //Manejo de excepciones
            {
                MessageBox.Show($"Error al agregar la mascota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retorna;
        }

        public static int AgregarCita(Citas citas) //Metodo para añadir citas
        {
            int retorna = 0;

            try
            {
                using (SqlConnection conexion = BaseDatos.ObtenerConexion()) //Utilizamos la conexion a la BD
                {   //Consulta para insertar todos los campos
                    string query = @"INSERT INTO Citas (Fecha, Motivo, Observaciones, DNICliente, MascotasID)
                    VALUES (@Fecha, @Motivo, @Observaciones, @DNICliente, @MascotasID)";

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        //Añadir todos los valores que hemos añadido de la cita a la consulta
                        command.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(citas.FechaHora));
                        command.Parameters.AddWithValue("@Motivo", citas.Motivo);
                        command.Parameters.AddWithValue("@Observaciones", citas.Observaciones);
                        command.Parameters.AddWithValue("@DNICliente", citas.DNICliente);
                        command.Parameters.AddWithValue("@MascotasID", citas.MascotasID);

                        retorna = command.ExecuteNonQuery(); //Ejecutar el comando
                    }
                }

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) //Manejo de excepcion si se intenta añadir una cita con fecha y hora duplicada
                {
                    MessageBox.Show("Ya existe una cita con esa fecha y hora");
                }
                else
                {
                    MessageBox.Show("Error al guardar la cita");
                }
            }
            return retorna;
        }

        public static List<Citas> MostrarCitas() //Metodo para mostrar todas las citas
        {
            List<Citas > citas = new List<Citas>(); //Declaracion de nueva List para almacenar las citas

            using(SqlConnection conexion = BaseDatos.ObtenerConexion()) //Usamos la conexion a la BD
            {   //Consulta para mostrar todas las citas con todos sus campos
                string query = "SELECT ID, Fecha, Motivo, Observaciones, DNICliente, MascotasID FROM Citas";

                SqlCommand command = new SqlCommand(query, conexion);
                SqlDataReader reader = command.ExecuteReader(); //Declaracion de un reader para leer todos los campos almacenados de cada cita

                while (reader.Read())
                {   //Añadir todos los valores que ha leido el reader a un nuevo objeto citas
                    Citas cita = new Citas();
                    cita.ID = reader.GetInt32(0);
                    cita.FechaHora = reader.GetDateTime(1);
                    cita.Motivo = reader.GetString(2);
                    cita.Observaciones = reader.GetString(3);
                    cita.DNICliente = reader.GetString(4);
                    cita.MascotasID = reader.GetInt32(5);
                    citas.Add(cita);
                }
                return citas;
            }
        }

        public static List<Cliente> MostrarClientes() //Mismo funcionamiento que MostrarCitas()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            {
                string query = "SELECT DNI, Nombre, Apellidos, Direccion, Telefono, CP, Localidad, Provincia, CorreoE, Observaciones FROM Clientes";

                SqlCommand command = new SqlCommand(query, conexion);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Dni=reader.GetString(0);
                    cliente.Nombre = reader.GetString(1);
                    cliente.Apellidos = reader.GetString(2);
                    cliente.Direccion=reader.GetString(3);
                    cliente.Telefono=reader.GetString(4);
                    cliente.CodigoPostal = reader.GetString(5);
                    cliente.Localidad = reader.GetString(6);
                    cliente.Provincia = reader.GetString(7);
                    cliente.CorreoElec=reader.GetString(8);
                    cliente.Observaciones = reader.GetString(9);
                    clientes.Add(cliente);
                }
                return clientes;
            }
        }

        public static List<Mascota> MostrarMascotas() //Mismo funcionamiento que MostrarCitas()
        {
            List<Mascota> mascotas = new List<Mascota>();

            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            {
                string query = "SELECT ID, Nombre, Especie, Raza, Nacimiento, Notas, DNICliente FROM Mascotas";

                SqlCommand command = new SqlCommand(query, conexion);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Mascota mascota = new Mascota();
                    mascota.ID = reader.GetInt32(0);
                    mascota.Nombre = reader.GetString(1);
                    mascota.Especie = reader.GetString(2);
                    mascota.Raza = reader.GetString(3);
                    mascota.FechaNac=reader.GetDateTime(4);
                    mascota.Notas = reader.GetString(5);
                    mascota.DNICliente = reader.GetString(6);
                    mascotas.Add(mascota);
                }
                return mascotas;
            }
        }

        public static int editarCliente(Cliente cliente) //Metodo para editar clientes
        {
            int result = 0;

            try
            {
                using (SqlConnection conexion = BaseDatos.ObtenerConexion()) //Utilizamos la conexion a la BD
                {   //Consulta para actualizar todos los campos de la cita que seleccionemos mediante el DNI del cliente
                    string query = @"UPDATE Clientes SET Nombre = @Nombre, Apellidos = @Apellidos, Direccion = @Direccion, Telefono = @Telefono, CP = @CP, Localidad = @Localidad,
                                Provincia = @Provincia, CorreoE = @CorreoE, Observaciones = @Observaciones WHERE DNI = @DNI";
                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        //Añadimos todos los nuevos valores a la consulta
                        command.Parameters.AddWithValue("@DNI", cliente.Dni);
                        command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                        command.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                        command.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                        command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                        command.Parameters.AddWithValue("@CP", cliente.CodigoPostal);
                        command.Parameters.AddWithValue("@Localidad", cliente.Localidad);
                        command.Parameters.AddWithValue("@Provincia", cliente.Provincia);
                        command.Parameters.AddWithValue("@CorreoE", cliente.CorreoElec);
                        command.Parameters.AddWithValue("@Observaciones", cliente.Observaciones);

                        result = command.ExecuteNonQuery(); //Ejecutar el comando
                    }
                }
                
            }
            catch(SqlException ex)
            {
                if (ex.Number == 2627) //Manejo de la excepcion si intentamos modificar el DNI a uno ya existente
                {
                    MessageBox.Show("Ya existe un cliente con ese DNI");
                }
                else
                {
                    MessageBox.Show("Error al guardar el cliente");
                }
            }
            return result;
        }

        public static int editMascota(Mascota mascota) //Mismo funcionamiento que editCliente()
        {
            int result = 0;

            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            {
                string query = @"UPDATE Mascotas SET Nombre = @Nombre, Especie = @Especie, Raza = @Raza, Nacimiento = @Nacimiento,
                                Notas = @Notas, DNICliente = @DNICliente WHERE ID = @ID";
                using (SqlCommand  command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@ID", mascota.ID);
                    command.Parameters.AddWithValue("@Nombre", mascota.Nombre);
                    command.Parameters.AddWithValue("@Especie", mascota.Especie);
                    command.Parameters.AddWithValue("@Raza", mascota.Raza);
                    command.Parameters.AddWithValue("@Nacimiento", mascota.FechaNac);
                    command.Parameters.AddWithValue("@Notas", mascota.Notas);
                    command.Parameters.AddWithValue("@DNICliente", mascota.DNICliente);
                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }

        public static int editCita(Citas cita) //Mismo funcionamiento que editCliente()
        {
            int result = 0;

            try
            {
                using (SqlConnection conexion = BaseDatos.ObtenerConexion())
                {
                    string query = @"UPDATE Citas SET Fecha = @Fecha, Motivo = @Motivo, Observaciones = @Observaciones,
                                DNICliente = @DNICliente WHERE ID = @ID";
                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@ID",cita.ID);
                        command.Parameters.AddWithValue("@Fecha", cita.FechaHora);
                        command.Parameters.AddWithValue("@Motivo", cita.Motivo);
                        command.Parameters.AddWithValue("@Raza", cita.Observaciones);
                        command.Parameters.AddWithValue("@DNICliente", cita.DNICliente);
                        command.Parameters.AddWithValue("@Observaciones", cita.Observaciones);
                        result = command.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Ya existe una cita con esa fecha y hora");
                }
                else
                {
                    MessageBox.Show("Error al guardar la cita");
                }
            }
            
            return result;
        }
    }
}
