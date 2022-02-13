using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSdetagavos.capa_de_datos;

namespace WSdetagavos.capa_de_negocios
{
    public class cls_cultivo
    {
        public cls_conexion objconexion = new cls_conexion();
        public Boolean insertarcultivo(string nombre)
        {

            objconexion.conectar();
            int num = numeroderegistros() + 1;
            string consulta = "insert into cultivo values(" + num + ",'" + nombre + "','ACTIVO')";
            return objconexion.ejecutarquery(consulta);


        }
        public Boolean actualizarcultivo(string nombrenuevo, int id)
        {
            objconexion.conectar();
            string consulta = "update cultivo set nombre='" + nombrenuevo + "' where id=" + id;
            return objconexion.ejecutarquery(consulta);

        }
        public Boolean eliminarcultivo(int id)
        {
            objconexion.conectar();
            string consulta = "update cultivo set estado='DESACTIVADO' where id=" + id;
            return objconexion.ejecutarquery(consulta);

        }
        public System.Data.DataSet llenardatagrid(string nombre)
        {
            objconexion.conectar();
            string consulta = "select * from cultivo where estado='ACTIVO' and nombre like '%" + nombre + "%'";

            return objconexion.llenardg(consulta, "cultivo");
        }
        public int validarsiexiste(string nombre)
        {
            objconexion.conectar();
            string consulta = "select count(*) from cultivo where nombre='" + nombre + "'";
            return objconexion.contar(consulta);
        }
        public int numeroderegistros()
        {

            string consulta = "select count(*) from cultivo";
            return objconexion.contar(consulta);
        }


        public string[] llenarspinner()
        {
            objconexion.conectar();
            string consulta = "select nombre from cultivo where estado='ACTIVO'";
            System.Data.DataSet MiDataSet = objconexion.llenardg(consulta, "cultivo");
            string[] Matriz = new string[MiDataSet.Tables[0].Rows.Count];
            if (MiDataSet.Tables.Count > 0)
            {
                if (MiDataSet.Tables[0].Rows.Count > 0)
                {
                    
                    for (int fil = 0; fil <= MiDataSet.Tables[0].Rows.Count - 1; fil++)
                    {
                        
                            Matriz[fil] = System.Convert.ToString(MiDataSet.Tables[0].Rows[fil].ItemArray[0]);
                        
                    }

                }

            }
            return Matriz;
        }
    }
}