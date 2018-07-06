using Datos.Sicafi;
using Datos.Sicafi.Listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FichaPredialSicafi
    {
        EntitySicafi entitySicafi;
        public FichaPredialSicafi(string strServidor, string strBaseDatos, string strUsuario, string strClave)
        {
            entitySicafi = new EntitySicafi(strServidor, strBaseDatos, strUsuario, strClave);
        }
        public List<Consultar_Predio_Result> consultarFichaPredial(string strMunicipio
                                    , string strSector
                                    , string strCorregimiento
                                    , string strBarrio
                                    , string strManzna
                                    , string strPredio
                                    , string strEdificio
                                    , string strUnidadPredial
                                    , string strFichasPrediales)
        {
            return entitySicafi.Consultar_Predio(strMunicipio
                , strSector
                , strCorregimiento
                , strBarrio
                , strManzna
                , strPredio
                , strEdificio
                , strUnidadPredial
                , strFichasPrediales);
        }
         
    public List<Consultar_Propietario_Result> consultarPropietario(int nufi)
        {
            List<Consultar_Propietario_Result> lstPropietario = entitySicafi.Consultar_Propietario(nufi);
            return lstPropietario;
        }
    }
}
