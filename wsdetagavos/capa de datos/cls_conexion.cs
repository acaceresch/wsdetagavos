using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WSdetagavos.capa_de_datos
{
    public class cls_conexion
    {
        public string strCon = "";
        public SqlConnection xcon;
        public SqlCommand xcmd;
        public void conectar()
        {
            try
            {
                strCon = "Data Source=ANTHONY-PC;";
                strCon += "Initial Catalog=basedetagavos;User ID=anthonycontrol;Password=shania";
                xcon = new SqlConnection(strCon);
                xcon.Open();
            }
            catch (Exception ex)
            { }
        }
        public int contar(string consulta)
        {
            try
            {
                xcmd = new SqlCommand();
                xcmd.Connection = xcon;
                xcmd.CommandText = consulta;
                int rpta =Convert .ToInt32 ( xcmd.ExecuteScalar());

                return rpta; }
            catch (Exception ex)
            { return 0; }

        }
        public Boolean ejecutarquery(string consulta)
        {
            try
            {
                xcmd = new SqlCommand();
                xcmd.Connection = xcon;
                xcmd.CommandText = consulta;
                xcmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            { return false; }

        }
        public System .Data.DataSet  llenardg(string consulta,string tabla)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(consulta, xcon);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds,tabla);
                return ds;
            }
            catch (Exception ex)
            { return null; }

        }
    }
}