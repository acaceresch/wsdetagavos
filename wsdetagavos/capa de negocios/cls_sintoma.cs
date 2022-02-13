using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using WSdetagavos.capa_de_datos;

namespace WSdetagavos.capa_de_negocios
{
    public class cls_sintoma
    {
        public cls_conexion objconexion = new cls_conexion();


        public Boolean insertarsintoma(string nombre, Byte[] imagen, int plaga)
        {
            //try
            //{
                
                SqlConnection con = new SqlConnection("Data Source=ANTHONY-PC;Initial Catalog=basedetagavos;User ID=anthonycontrol;Password=shania");
                SqlCommand com = new SqlCommand("insert into sintoma(nombre,imagen,id_plaga,estado) values(@nom,@Pic,@pla,'ACTIVO')", con);

                
                com.Parameters.AddWithValue("@Pic", imagen);
                com.Parameters.AddWithValue("@nom", nombre);
                com.Parameters.AddWithValue("@pla", plaga);
                con.Open();
                //Ejecuta una instrucción SQL en la conexión y devuelve el número de filas afectadas.
                com.ExecuteNonQuery();
                con.Close();
                return true;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
            
        }
        //public Boolean insertarsintoma(string nombre, Byte[] imagen, int plaga)
        //{

        //    objconexion.conectar();
        //    int num = numeroderegistros() + 1;
        //    string consulta = "insert into sintoma values(" + num + ",'" + nombre + "','"+imagen+"',"+plaga+",'ACTIVO')";
        //    return objconexion.ejecutarquery(consulta);


        //}
        public Boolean actualizarsintoma(int id,string nombre)
        {

            objconexion.conectar();
            string consulta = "update sintoma set nombre='" + nombre + "' where id=" + id;
            return objconexion.ejecutarquery(consulta);


        }
        public Boolean eliminarsintoma(int id)
        {
            objconexion.conectar();
            string consulta = "update sintoma set estado='DESACTIVADO' where id=" + id;
            return objconexion.ejecutarquery(consulta);
        }
        public int numeroderegistros()
        {

            string consulta = "select count(*) from sintoma";
            return objconexion.contar(consulta);
        }
        public System.Data.DataSet llenardatagrid(string nombre, int plaga)
        {
            objconexion.conectar();
            string consulta = "select id,nombre,id_plaga,estado from sintoma where estado='ACTIVO' and nombre like '%" + nombre + "%' and id_plaga="+plaga;

            return objconexion.llenardg(consulta, "sintoma");
        }
    }
}