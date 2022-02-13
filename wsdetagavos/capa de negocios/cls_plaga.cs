using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSdetagavos.capa_de_datos;

namespace WSdetagavos.capa_de_negocios
{
    public class cls_plaga
    {
        public cls_conexion objconexion = new cls_conexion();
        public Boolean insertarplaga(string nombre,int cultivo,string cura)
        {
            objconexion.conectar();
            int num = numeroderegistros()+1;
            string consulta = "insert into plaga values("+num+",'" + nombre + "',"+cultivo+",'"+cura+"','ACTIVO')";
            return objconexion.ejecutarquery(consulta);
        }
        public Boolean actualizarplaga(string nombrenuevo, int id ,int cultivo,string cura)
        {
            objconexion.conectar();
            string consulta = "update plaga set nombre='" + nombrenuevo + "', id_cultivo="+cultivo+", curar='"+cura+"'  where id=" + id + "";
            return objconexion.ejecutarquery(consulta);

        }
        public Boolean eliminarplaga(int id)
        {
            objconexion.conectar();
            string consulta = "update plaga set estado='DESACTIVADO' where id=" + id ;
            return objconexion.ejecutarquery(consulta);
        }
        public System.Data.DataSet llenardatagrid(string nombre,int cultivo)
        {
            objconexion.conectar();
            string consulta = "select * from plaga where nombre like '%" + nombre + "%' and id_cultivo="+cultivo +" and estado='ACTIVO'";

            return objconexion.llenardg(consulta, "plaga");
        }
        public int validarsiexiste(string nombre,int cultivo)
        {
            objconexion.conectar();
            string consulta = "select count(*) from plaga where nombre='" + nombre + "'and id_cultivo="+cultivo;
            return objconexion.contar(consulta);
        }
        public int numeroderegistros()
        {

            string consulta = "select count(*) from plaga";
            return objconexion.contar(consulta);
        }
    }
}