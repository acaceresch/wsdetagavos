using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSdetagavos.capa_de_negocios;

namespace WSdetagavos
{
    /// <summary>
    /// Descripción breve de detaservicio
    /// </summary>
    [WebService(Namespace = "http://detagavos.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class detaservicio : System.Web.Services.WebService
    {
        //cls_usuario objconsultarusuarios = new cls_usuario();
        
        [WebMethod]
        public int validarusuarios(string usuario, string password)
        {
            cls_usuario objconsultarusuarios = new cls_usuario();
             return objconsultarusuarios.validar(usuario, password);
        }
        [WebMethod]
        public int sabersiexisteusuarios(string dni, string usuario)
        {
            cls_usuario objconsultarusuarios = new cls_usuario();
            return objconsultarusuarios.validarsiexiste(dni, usuario);
        }
        [WebMethod]
        public Boolean insertarusuarios(string dni,string nombre,string apellidos,string usuario,string password)
        {
            cls_usuario objconsultarusuarios = new cls_usuario();
            return objconsultarusuarios .insertarusuario(dni ,nombre ,apellidos ,usuario ,password );
        }
        [WebMethod]
        public System.Data.DataSet llenardgusuarios(string nombre)
        {
            cls_usuario objconsultarusuarios = new cls_usuario();
            return objconsultarusuarios.llenardatagrid(nombre);
        }
        [WebMethod]
        public Boolean actualizarusuarios(string dni, string nombre, string apellidos, string usuario, string password)
        {
            cls_usuario objconsultarusuarios = new cls_usuario();
            return objconsultarusuarios.actualizarusuario(dni, nombre, apellidos, usuario, password);
        }
        [WebMethod]
        public Boolean eliminarusuarios(string dni,string usuario)
        {
            cls_usuario objconsultarusuarios = new cls_usuario();
            return objconsultarusuarios.eliminarusuario(dni,usuario);
        }
        [WebMethod]
        public Boolean insertarcultivo(string nombre)
        {
            cls_cultivo objcultivo = new cls_cultivo();
            return objcultivo.insertarcultivo(nombre);
        }
        [WebMethod]
        public Boolean actualizarcultivo(string nombrenuevo, string id)
        {
            cls_cultivo objcultivo = new cls_cultivo();
            return objcultivo.actualizarcultivo(nombrenuevo,Convert.ToInt32(id));
        }
        [WebMethod]
        public Boolean eleminarcultivo(string id)
        {
            cls_cultivo objcultivo = new cls_cultivo();
            return objcultivo.eliminarcultivo(Convert.ToInt32( id));
        }
        [WebMethod]
        public System.Data.DataSet llenardgcultivos(string nombre)
        {
            cls_cultivo objconsultarcultivos = new cls_cultivo();
            return objconsultarcultivos.llenardatagrid(nombre);
        }
        [WebMethod]
        public int sabersiexistecultivos(string nombre)
        {
            cls_cultivo objconsultarcultivos = new cls_cultivo();
            return objconsultarcultivos.validarsiexiste(nombre);
        }

        [WebMethod]
        public Boolean insertarplaga(string nombre,string cultivo,string cura)
        {
            cls_plaga objplaga = new cls_plaga();            
            return objplaga.insertarplaga(nombre,Convert.ToInt32( cultivo), cura);
        }
        [WebMethod]
        public Boolean actualizarplaga(string nombrenuevo, string id,string cultivo,string cura)
        {
            cls_plaga objplaga = new cls_plaga();
            return objplaga.actualizarplaga (nombrenuevo ,Convert.ToInt32( id) ,Convert.ToInt32( cultivo),cura);
        }
        [WebMethod]
        public Boolean eleminarplaga(string id)
        {
            cls_plaga objplaga = new cls_plaga();
            return objplaga.eliminarplaga(Convert.ToInt32( id)); 
        }
        [WebMethod]
        public System.Data.DataSet llenardgplaga(string nombre, string cultivo)
        {
            cls_plaga objplaga = new cls_plaga();
            return objplaga.llenardatagrid(nombre,Convert.ToInt32( cultivo));
        }
        [WebMethod]
        public int sabersiexisteplaga(string nombre, string cultivo)
        {
            cls_plaga objconsultarplaga = new cls_plaga();
            return objconsultarplaga.validarsiexiste(nombre,Convert.ToInt32( cultivo));
        }
        [WebMethod]
        public Boolean insertarsintoma(string nombre, Byte[] imagen, string plaga)
        {
            cls_sintoma objsintoma = new cls_sintoma();
            return objsintoma.insertarsintoma(nombre, imagen, Convert.ToInt32(plaga));
        }
        
        [WebMethod]
        public Boolean actualizarsintoma(string id, string nombre, string plaga)
        {
            cls_sintoma objsintoma = new cls_sintoma();
            return objsintoma.actualizarsintoma(Convert.ToInt32(id), nombre);
        }
        [WebMethod]
        public Boolean eliminarsintoma(string id)
        {
            cls_sintoma objsintoma = new cls_sintoma();
            return objsintoma.eliminarsintoma(Convert.ToInt32(id));
        }
        [WebMethod]
        public System.Data.DataSet llenardgsintomas(string nombre,  string plaga)
        {
            //cls_cultivo objconsultarcultivos = new cls_cultivo();
            cls_sintoma objsintomas = new cls_sintoma();
            return objsintomas.llenardatagrid(nombre,Convert.ToInt32( plaga));
        }
        [WebMethod]
        public string[] Llenarcultivos()
        {
            cls_cultivo objconsultarcultivos = new cls_cultivo();
            //System.Data.DataSet a=new System.Data.DataSet();


            return objconsultarcultivos.llenarspinner();
        }
        [WebMethod]
        public string algoritmodecomparacion(Byte[] imagen, String cultivo)
        {
            ////cls_cultivo objconsultarcultivos = new cls_cultivo();
            localhost.Service1 oj = new localhost.Service1();

            return oj.comparacion(imagen,cultivo);
        }
       
    }
}
