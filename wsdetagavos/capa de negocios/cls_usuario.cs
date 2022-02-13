using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSdetagavos.capa_de_datos;

namespace WSdetagavos.capa_de_negocios
{
    public class cls_usuario
    {
        public cls_conexion   objconexion = new cls_conexion();
          
        public int validar(string usuario,string password)
        {
            objconexion.conectar();
            string consulta="select count(*) from usuario where usuario='"+usuario +"' and password='"+password+"'";
            return objconexion.contar(consulta );
        }
        public int validarsiexiste(string dni, string usuario)
        {
            objconexion.conectar();
            string consulta = "select count(*) from usuario where dni='" + dni + "' or usuario='" + usuario + "'";
            return objconexion.contar(consulta);
        }
        public Boolean insertarusuario(string dni, string nombre, string apellido, string usuario, string password)
        {
            objconexion.conectar();
            string consulta = "insert into usuario values('" + dni + "','" + nombre + "','" + apellido + "','" + usuario + "','" + password + "')";
            return objconexion.ejecutarquery(consulta);

        }
        public Boolean actualizarusuario(string dni, string nombre, string apellido, string usuario, string password)
        {
            objconexion.conectar();
            string consulta = "update usuario set nombre='" + nombre + "',apellidos='" + apellido + "',password='" + password + "' where dni='"+dni+"' and usuario='"+usuario+"'";
            return objconexion.ejecutarquery(consulta);

        }
        public Boolean eliminarusuario(string dni,string usuario)
        {
            objconexion.conectar();
            string consulta = "delete from usuario where dni='" + dni + "' and usuario='" + usuario + "'";
            return objconexion.ejecutarquery(consulta);

        }
        public System .Data.DataSet llenardatagrid(string nombre)
        {
            objconexion.conectar();
            string consulta = "select * from usuario where nombre like '%"+nombre+"%'";

            return objconexion .llenardg(consulta,"usuario");
        }
    }
}