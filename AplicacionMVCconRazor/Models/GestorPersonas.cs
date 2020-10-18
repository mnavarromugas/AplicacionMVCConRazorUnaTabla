using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml;

namespace AplicacionMVCconRazor.Models
{
    public class GestorPersonas
    {
        private const string StrConn = "Server=LAPTOP-0CRE86U4\\SQLEXPRESS;Database=Personas;User Id=sa;Password=123456;"; 

        public void AgregarPersona(Persona nueva)
        {
            SqlConnection conn = new SqlConnection(StrConn);
            conn.Open();

            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO Personas(nombre, apellido) VALUES (@Nombre, @Apellido)";
            comm.Parameters.Add(new SqlParameter("@Nombre", nueva.Nombre));
            comm.Parameters.Add(new SqlParameter("@Apellido", nueva.Apellido));

            comm.ExecuteNonQuery();

            conn.Close();
        }

        public List<Persona> ObtenerPersonas()
        {
            List<Persona> lista = new List<Persona>();

            SqlConnection conn = new SqlConnection(StrConn);
            conn.Open();

            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "SELECT * FROM Personas";

            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                int id = dr.GetInt32(0);
                string nombre = dr.GetString(1);
                string apellido = dr.GetString(2);

                Persona p = new Persona(id, nombre, apellido);
                lista.Add(p);
            }

            dr.Close();
            conn.Close();

            return lista;
        }

        public void Eliminar(int id)
        {
            SqlConnection conn = new SqlConnection(StrConn);
            conn.Open();

            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "DELETE FROM Personas WHERE id=@Id";
            comm.Parameters.Add(new SqlParameter("@Id", id));

            comm.ExecuteNonQuery();

            conn.Close();

        }

        public Persona ObtenerPorId(int id)
        {
            Persona p = null;

            SqlConnection conn = new SqlConnection(StrConn);
            conn.Open();

            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "SELECT * FROM Personas WHERE id=@Id";
            comm.Parameters.Add(new SqlParameter("@Id", id));

            SqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                string nombre = dr.GetString(1);
                string apellido = dr.GetString(2);

                p = new Persona(id, nombre, apellido);
            }

            dr.Close();
            conn.Close();

            return p;

        }

        public void ModificarPersona(Persona p)
        {
            SqlConnection conn = new SqlConnection(StrConn);
            conn.Open();

            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "UPDATE Personas SET nombre=@Nombre, apellido=@Apellido WHERE id=@Id";
            comm.Parameters.Add(new SqlParameter("@Nombre", p.Nombre));
            comm.Parameters.Add(new SqlParameter("@Apellido", p.Apellido));
            comm.Parameters.Add(new SqlParameter("@Id", p.Id));

            comm.ExecuteNonQuery();

            conn.Close();
        }
    }
}