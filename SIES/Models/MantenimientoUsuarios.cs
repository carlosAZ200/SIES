using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SIES.Models
{
    public class MantenimientoUsuarios
    {
        private SqlConnection con; 

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(Usuarios usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into es_usuarios (USU_documento ,USU_tipodoc,USU_nombre,USU_celular,USU_email,USU_genero,USU_aprendiz,USU_egresado,USU_areaformacion,USU_fechaegresado,USU_direccion,USU_barrio,USU_ciudad,USU_departamento,USU_fecharegistro) values (@documento, @tipodoc, @nombre, @celular, @email, @genero, @aprendiz, @egresado, @areaformacion, @fechaegresado, @direccion, @barrio, @ciudad, @departamento, @fecharegistro)", con);

            comando.Parameters.Add("@documento", SqlDbType.VarChar);
            comando.Parameters.Add("@tipodoc", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@celular", SqlDbType.VarChar);
            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters.Add("@aprendiz", SqlDbType.Bit);
            comando.Parameters.Add("@egresado", SqlDbType.Bit);
            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters.Add("@fechaegresado", SqlDbType.Date);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@barrio", SqlDbType.VarChar);
            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters.Add("@departamento", SqlDbType.VarChar);
            comando.Parameters.Add("@fecharegistro", SqlDbType.Date);


            comando.Parameters["@documento"].Value = usu.Documento;
            comando.Parameters["@tipodoc"].Value = usu.TipoDocumento;
            comando.Parameters["@nombre"].Value = usu.Nombre;
            comando.Parameters["@celular"].Value = usu.Celular;
            comando.Parameters["@email"].Value = usu.Email;
            comando.Parameters["@genero"].Value = usu.Genero;
            comando.Parameters["@aprendiz"].Value = usu.Aprendiz;
            comando.Parameters["@egresado"].Value = usu.Egresado;
            comando.Parameters["@areaformacion"].Value = usu.AreaFormacion;
            comando.Parameters["@fechaegresado"].Value = usu.FechaEgresado;
            comando.Parameters["@direccion"].Value = usu.Direccion;
            comando.Parameters["@barrio"].Value = usu.Barrio;
            comando.Parameters["@ciudad"].Value = usu.Ciudad;
            comando.Parameters["@departamento"].Value = usu.Departamento;
            comando.Parameters["@fecharegistro"].Value = usu.FechaEgresado;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        
        public List<Usuarios> RecuperarTodos()
        {
            Conectar();
            List<Usuarios> usuarios = new List<Usuarios>();

            SqlCommand com = new SqlCommand("select USU_id,USU_documento,USU_tipodoc,USU_nombre,USU_celular,USU_email,USU_genero,USU_aprendiz,USU_egresado,USU_areaformacion,USU_fechaegresado,USU_direccion,USU_barrio,USU_ciudad,USU_departamento,USU_fecharegistro from es_usuarios", con);

            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Usuarios usu = new Usuarios
                {
                    Id = Convert.ToInt32(registros["USU_id"]),
                    Documento = registros["USU_documento"].ToString(),
                    TipoDocumento = registros["USU_tipodoc"].ToString(),
                    Nombre = registros["USU_nombre"].ToString(),
                    Celular = registros["USU_celular"].ToString(),
                    Email = registros["USU_email"].ToString(),
                    Genero = registros["USU_genero"].ToString(),
                    Aprendiz = Convert.ToInt32(registros["USU_aprendiz"]),
                    Egresado = Convert.ToInt32(registros["USU_egresado"]),
                    AreaFormacion = registros["USU_areaformacion"].ToString(),
                    FechaEgresado = DateTime.Parse(registros["USU_fechaegresado"].ToString()),
                    Direccion = registros["USU_direccion"].ToString(),
                    Barrio = registros["USU_barrio"].ToString(),
                    Ciudad = registros["USU_ciudad"].ToString(),
                    Departamento = registros["USU_departamento"].ToString(),
                    FechaRegistro = DateTime.Parse(registros["USU_fecharegistro"].ToString())
                };
                usuarios.Add(usu);
            }
            con.Close();
            return usuarios;
        }

        public Usuarios Recuperar(int documento)
        {
            Conectar();
            
            SqlCommand comando = new SqlCommand("select USU_id,USU_documento,USU_tipodoc,USU_nombre,USU_celular,USU_email,USU_genero,USU_aprendiz,USU_egresado,USU_areaformacion,USU_fechaegresado,USU_direccion,USU_barrio,USU_ciudad,USU_departamento,USU_fecharegistro from es_usuarios where USU_documento = @documento", con);
            comando.Parameters.Add("@documento", SqlDbType.VarChar);
            comando.Parameters["@documento"].Value = documento;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();

            Usuarios usuarios = new Usuarios();
            if (registros.Read())
            {
                usuarios.Id = Convert.ToInt32(registros["USU_id"]);
                usuarios.Documento = registros["USU_documento"].ToString();
                usuarios.TipoDocumento = registros["USU_tipodoc"].ToString();
                usuarios.Nombre = registros["USU_nombre"].ToString();
                usuarios.Celular = registros["USU_celular"].ToString();
                usuarios.Email = registros["USU_email"].ToString();
                usuarios.Genero = registros["USU_genero"].ToString();
                usuarios.Aprendiz = Convert.ToInt32(registros["USU_aprendiz"]);
                usuarios.Egresado = Convert.ToInt32(registros["USU_egresado"]);
                usuarios.AreaFormacion = registros["USU_areaformacion"].ToString();
                usuarios.FechaEgresado = DateTime.Parse(registros["USU_fechaegresado"].ToString());
                usuarios.Direccion = registros["USU_direccion"].ToString();
                usuarios.Barrio = registros["USU_barrio"].ToString();
                usuarios.Ciudad = registros["USU_ciudad"].ToString();
                usuarios.Departamento = registros["USU_departamento"].ToString();
                usuarios.FechaRegistro = DateTime.Parse(registros["USU_fecharegistro"].ToString());
            }
            con.Close();
            return usuarios;
        }

        public int Modificar(Usuarios usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update es_usuarios set USU_tipodoc=@tipodoc, USU_nombre=@nombre, USU_celular=@celular, USU_email=@email, USU_genero=@genero, USU_aprendiz=@aprendiz, USU_egresado=@egresado, USU_areaformacion=@areaformacion, USU_fechaegresado=@fechaegresado, USU_direccion=@direccion, USU_barrio=@barrio, USU_ciudad=@ciudad, USU_departamento=@departamento, USU_fecharegistro=@fecharegistro where USU_documento=@documento", con);


            comando.Parameters.Add("@tipodoc", SqlDbType.VarChar);
            comando.Parameters["@tipodoc"].Value = usu.TipoDocumento;

            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = usu.Nombre;

            comando.Parameters.Add("@celular", SqlDbType.VarChar);
            comando.Parameters["@celular"].Value = usu.Celular;

            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters["@email"].Value = usu.Email;

            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters["@genero"].Value = usu.Genero;

            comando.Parameters.Add("@aprendiz", SqlDbType.Bit);
            comando.Parameters["@aprendiz"].Value = usu.Aprendiz;
            
            comando.Parameters.Add("@egresado", SqlDbType.Bit);
            comando.Parameters["@egresado"].Value = usu.Egresado;
            
            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters["@areaformacion"].Value = usu.AreaFormacion;
            
            comando.Parameters.Add("@fechaegresado", SqlDbType.Date);
            comando.Parameters["@fechaegresado"].Value = usu.FechaEgresado;
            
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters["@direccion"].Value = usu.Direccion;
            
            comando.Parameters.Add("@barrio", SqlDbType.VarChar);
            comando.Parameters["@barrio"].Value = usu.Barrio;

            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters["@ciudad"].Value = usu.Ciudad;

            comando.Parameters.Add("@departamento", SqlDbType.VarChar);
            comando.Parameters["@departamento"].Value = usu.Departamento;

            comando.Parameters.Add("@fecharegistro", SqlDbType.Date);
            comando.Parameters["@fecharegistro"].Value = usu.FechaEgresado;

            comando.Parameters.Add("@documento", SqlDbType.VarChar);
            comando.Parameters["@documento"].Value = usu.Documento;

            
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;

        }

        public int Borrar(int documento)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from es_usuarios where USU_documento=@documento",con);
            comando.Parameters.Add("@documento", SqlDbType.VarChar);
            comando.Parameters["@documento"].Value = documento;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

    }
}