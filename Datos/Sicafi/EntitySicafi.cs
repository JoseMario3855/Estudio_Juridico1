using Datos.Sicafi.Listas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos.Sicafi
{
    public class EntitySicafi : Conexion
    {
        public EntitySicafi(string strServidor, string strBaseDatos, string strUsuario, string strClave)
            : base(strServidor, strBaseDatos, strUsuario, strClave)
        {

        }
        #region CONSULTAR CONSRUCCION
        public List<Listas.Consultar_Construcciones_Result> Consultar_Construcciones(int? nufi
                                                                                    , string pkPredioGrafico
                                                                                    , string pkPredioAlfanumerico
                                                                                    , string strMunicipio
                                                                                    , string strSector)
        {
            List<Listas.Consultar_Construcciones_Result> ls = new List<Listas.Consultar_Construcciones_Result>();
            try
            {
                string sql = "";
                sql += "  declare @nufi int=" + (nufi == null ? "null" : Convert.ToString(nufi)) + "  \n";
                sql += " declare @pkPredioGRafico varchar(50)=" + (pkPredioAlfanumerico == null ? "null" : "'" + pkPredioAlfanumerico + "'") + "  \n";
                sql += " declare @pkCOnstruccionGeografica varchar(50)=" + (pkPredioGrafico == null ? "null" : "'" + pkPredioGrafico + "'") + "  \n";
                sql += " declare @Municipio varchar(50)=" + (strMunicipio == null ? "null" : "'" + strMunicipio + "'") + "  \n";
                sql += " declare @Sector int=" + (strSector == null ? "null" : Convert.ToString(strSector)) + "  \n";
                sql += " select     \n";
                sql += " Convert(varchar(50),(select TOP 1 MT.TICOTIPO      \n";
                sql += " from [dbo].[MANT_TIPOCONS] MT          \n";
                sql += " where MT.TICOCODI=C.FPCOTICO          \n";
                sql += " ) )TipoConst          \n";
                sql += " ,Convert(varchar(50),C.FPCOUNID)  Unidad     \n";
                sql += " ,Convert(varchar(50),C.FPCOACUE)  Acueducto       \n";
                sql += " ,Convert(varchar(50),C.FPCOALCA)  Alcantarillado       \n";
                sql += " ,Convert(varchar(50),C.FPCOENER)  Energia        \n";
                sql += " ,Convert(varchar(50),C.FPCOTELE)  Telefono        \n";
                sql += " ,Convert(varchar(50),C.FPCOGAS)  Gas        \n";
                sql += " ,Convert(varchar(50),C.FPCOPISO)  Pisos        \n";
                sql += " ,Convert(varchar(50),C.FPCOEDCO)  Edad        \n";
                sql += " ,Convert(varchar(50),C.FPCOPOCO)  Porcentaje       \n";
                sql += " , isnull(convert(varchar(2),(select sum(CAL.[FPCCPUNT])       \n";
                sql += "     from [dbo].[FIPRCACO] CAL       \n";
                sql += " where CAL.FPCCNUFI=C.FPCONUFI       \n";
                sql += " and CAL.FPCCUNID=C.FPCOUNID       \n";
                sql += " and CAL.FPCCCODI<200)),' ') Puntos100       \n";
                sql += " , isnull(convert(varchar(2),(select sum(CAL.[FPCCPUNT])      \n";
                sql += " from [dbo].[FIPRCACO] CAL       \n";
                sql += " where CAL.FPCCNUFI=C.FPCONUFI       \n";
                sql += " and CAL.FPCCUNID=C.FPCOUNID       \n";
                sql += " and (CAL.FPCCCODI<300 and CAL.FPCCCODI>=200))),' ') Puntos200      \n";
                sql += " , isnull(convert(varchar(2),(select sum(CAL.[FPCCPUNT])       \n";
                sql += " from [dbo].[FIPRCACO] CAL       \n";
                sql += " where CAL.FPCCNUFI=C.FPCONUFI       \n";
                sql += " and CAL.FPCCUNID=C.FPCOUNID       \n";
                sql += " and (CAL.FPCCCODI<400 and CAL.FPCCCODI>=300))),' ') Puntos300      \n";
                sql += " , isnull(convert(varchar(2),(select sum(CAL.[FPCCPUNT])       \n";
                sql += " from [dbo].[FIPRCACO] CAL       \n";
                sql += " where CAL.FPCCNUFI=C.FPCONUFI       \n";
                sql += " and CAL.FPCCUNID=C.FPCOUNID       \n";
                sql += " and (CAL.FPCCCODI<500 and CAL.FPCCCODI>400))),' ') Puntos400       \n";
                sql += " , isnull(convert(varchar(2),(select sum(CAL.[FPCCPUNT])       \n";
                sql += " from [dbo].[FIPRCACO] CAL       \n";
                sql += " where CAL.FPCCNUFI=C.FPCONUFI       \n";
                sql += " and CAL.FPCCUNID=C.FPCOUNID       \n";
                sql += " and(CAL.FPCCCODI<600 and CAL.FPCCCODI>=500))),' ') Puntos500       \n";
                sql += " , isnull(convert(varchar(2),(select sum(CAL.[FPCCPUNT])            \n";
                sql += " from [dbo].[FIPRCACO] CAL            \n";
                sql += " where CAL.FPCCNUFI=C.FPCONUFI            \n";
                sql += " and CAL.FPCCUNID=C.FPCOUNID))     \n";
                sql += " ,(select top 1  MT.TICOPUNT     \n";
                sql += " from [MANT_TIPOCONS] MT     \n";
                sql += " where MT.[TICOCODI]=C.FPCOTICO     \n";
                sql += " and MT.TICOMUNI=C.FPCOMUNI)) PuntosTotales       \n";
                sql += " ,(RTRIM(LTRIM(P.[FIPRMUNI]))   \n";
                sql += " +(RTRIM(LTRIM(convert( varchar(2),P.FIPRCLSE))))   \n";
                sql += " +(RTRIM(LTRIM(P.FIPRCORR)))   \n";
                sql += " +(RTRIM(LTRIM(P.FIPRBARR)))   \n";
                sql += " +(RTRIM(LTRIM(P.FIPRMANZ)))   \n";
                sql += " +(RTRIM(LTRIM(P.FIPRPRED)))   \n";
                sql += " +(RTRIM(LTRIM(P.[FIPREDIF])))   \n";
                sql += " +(RTRIM(LTRIM(P.FIPRUNPR)))   \n";
                sql += " +(right('00000'+RTRIM(LTRIM(Convert(varchar(50),C.FPCOUNID))),5))   \n";
                sql += " ) pkConstruccionAlfanumerico   \n";
                sql += " ,(right('00000'+(RTRIM(LTRIM(P.[FIPRMUNI]))),3)   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(convert( varchar(2),P.FIPRCLSE)))),1))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRCORR))),3))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRBARR))),3))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRMANZ))),4))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRPRED))),5))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.[FIPREDIF])) ),4))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRUNPR))),5))   \n";
                sql += " +(right('00000'+RTRIM(LTRIM(Convert(varchar(50),C.FPCOUNID))),5))   \n";
                sql += " ) pkConstruccionGrafico   \n";
                sql += " ,(RTRIM(LTRIM(P.[FIPRMUNI]))   \n";
                sql += " +(RTRIM(LTRIM(convert( varchar(2),P.FIPRCLSE))))   \n";
                sql += " +(RTRIM(LTRIM(P.FIPRCORR)))   \n";
                sql += " +(RTRIM(LTRIM(P.FIPRBARR)))   \n";
                sql += " +(RTRIM(LTRIM(P.FIPRMANZ)))   \n";
                sql += " +(RTRIM(LTRIM(P.FIPRPRED)))   \n";
                sql += " ) pkPredio   \n";
                sql += " ,(right('00000'+(RTRIM(LTRIM(P.[FIPRMUNI]))),3)   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(convert( varchar(2),P.FIPRCLSE)))),1))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRCORR))),3))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRBARR))),3))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRMANZ))),4))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRPRED))),5))   \n";
                sql += " ) pkPredioGrafico   \n";
                sql += ",convert(varchar(50), P.[FIPRNUFI] )\n";
                sql += ",ltrim(rtrim(convert(varchar(50), P.[FIPRUNPR] )))\n";
                sql += ",convert(varchar(2), C.FPCOCLCO )  \n";

                sql += " ,Convert(varchar(50),C.FPCOTICO)  Identificador     \n";
                sql += " ,Convert(varchar(50),C.FPCOARCO )  Ares     \n";
                sql += " ,Convert(varchar(50),(case       \n";
                sql += " when C.FPCOMEJO=0 then '2'      \n";
                sql += " when C.FPCOMEJO=1 then '1'      \n";
                sql += "  end)) Mejora       \n";
                sql += "  ,Convert(varchar(50),(case     \n";
                sql += "  when C.FPCOLEY=0 then '2'     \n";
                sql += "  when C.FPCOLEY=1 then '1'       \n";
                sql += "  end)) Ley59       \n";
                sql += " ,(select top 1 TC.TICODESC  \n";
                sql += "from [dbo].[MANT_TIPOCONS] TC  \n";
                sql += "where TC.TICOCODI=C.FPCOTICO  \n";
                sql += "and TC.TICODESC<> TC.TICOCODI) DescrpcionTipoConstruccion  \n";


                sql += " from [dbo].[FIPRCONS] C        \n";
                sql += " inner join   [dbo].[FICHPRED] P on C.FPCONUFI=P.[FIPRNUFI]   \n";
                sql += " where (C.FPCONUFI=@nufi or @nufi is null)   \n";
                sql += "  and ((right('00000'+(RTRIM(LTRIM(P.[FIPRMUNI]))),3)   \n";
                sql += " 	+(right('00000'+(RTRIM(LTRIM(convert( varchar(2),P.FIPRCLSE)))),1))   \n";
                sql += " 	+(right('00000'+(RTRIM(LTRIM(P.FIPRCORR))),3))   \n";
                sql += " 	+(right('00000'+(RTRIM(LTRIM(P.FIPRBARR))),3))   \n";
                sql += " 	+(right('00000'+(RTRIM(LTRIM(P.FIPRMANZ))),4))   \n";
                sql += " 	+(right('00000'+(RTRIM(LTRIM(P.FIPRPRED))),5))   \n";
                sql += " 	)=@pkPredioGRafico or @pkPredioGRafico is null   \n";
                sql += " )   \n";
                sql += " and ((right('00000'+(RTRIM(LTRIM(P.[FIPRMUNI]))),3)   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(convert( varchar(2),P.FIPRCLSE)))),1))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRCORR))),3))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRBARR))),3))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRMANZ))),4))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRPRED))),5))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.[FIPREDIF])) ),4))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRUNPR))),5))   \n";
                sql += " +(right('00000'+RTRIM(LTRIM(Convert(varchar(50),C.FPCOUNID))),5))   \n";
                sql += " ) =@pkCOnstruccionGeografica or @pkCOnstruccionGeografica is null)   \n";
                sql += " and (P.[FIPRMUNI]=@Municipio or @Municipio is null)   \n";
                sql += "and (P.FIPRCLSE=@Sector or @Sector is null)  \n";
                sql += "and  P.[FIPRESTA]='ac' \n";
                SqlDataReader read = this.EjecutarConsulta(sql);
                if (read != null)
                {
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            Listas.Consultar_Construcciones_Result objConstruccion = new Listas.Consultar_Construcciones_Result();

                            objConstruccion.strTipoConstruccion = (read[0] == null ? string.Empty : read.GetString(0));
                            objConstruccion.strUnidad = (read[1] == null ? string.Empty : read.GetString(1));
                            objConstruccion.strAcueducto = (read[2] == null ? string.Empty : read.GetString(2));
                            objConstruccion.strAlcantarillado = (read[3] == null ? string.Empty : read.GetString(3));
                            objConstruccion.strEnergia = (read[4] == null ? string.Empty : read.GetString(4));
                            objConstruccion.strTelefono = (read[5] == null ? string.Empty : read.GetString(5));
                            objConstruccion.strGas = (read[6] == null ? string.Empty : read.GetString(6));
                            objConstruccion.strPisos = (read[7] == null ? string.Empty : read.GetString(7));
                            objConstruccion.strEdad = (read[8] == null ? string.Empty : read.GetString(8));
                            objConstruccion.strPorcentajeConstruido = (read[9] == null ? string.Empty : read.GetString(9));
                            objConstruccion.strTotalPuntos100 = (read[10] == null ? string.Empty : read.GetString(10));
                            objConstruccion.strTotalPuntos200 = (read[11] == null ? string.Empty : read.GetString(11));
                            objConstruccion.strTotalPuntos300 = (read[12] == null ? string.Empty : read.GetString(12));
                            objConstruccion.strTotalPuntos400 = (read[13] == null ? string.Empty : read.GetString(13));
                            objConstruccion.strTotalPuntos500 = (read[14] == null ? string.Empty : read.GetString(14));
                            objConstruccion.strTotalPuntos = (read[15] == null ? string.Empty : read.GetString(15));
                            objConstruccion.strPkConstruccionALfanumerico = (read[16] == null ? string.Empty : read.GetString(16));
                            objConstruccion.strPkConstruccionGeografico = (read[17] == null ? string.Empty : read.GetString(17));
                            objConstruccion.strPkPredioALfanumerico = (read[18] == null ? string.Empty : read.GetString(18));
                            objConstruccion.strPkPredioGeografico = (read[19] == null ? string.Empty : read.GetString(19));
                            objConstruccion.strNufi = (read[20] == null ? string.Empty : read.GetString(20));
                            objConstruccion.strUnidadPredial = (read[21] == null ? string.Empty : read.GetString(21));
                            objConstruccion.strClaseConstruccion = (read[22] == null ? string.Empty : read.GetString(22));
                            objConstruccion.strIdentificador = (read[23] == null ? string.Empty : read.GetString(23));
                            objConstruccion.strArea = (read[24] == null ? string.Empty : read.GetString(24));
                            objConstruccion.strMejora = (read[25] == null ? string.Empty : read.GetString(25));
                            objConstruccion.strLey59 = (read[26] == null ? string.Empty : read.GetString(26));
                            objConstruccion.strDescipcionIdentificador = (read[27] == null ? string.Empty : read.GetString(27));
                            ls.Add(objConstruccion);
                        }
                    }
                    else
                    {
                        ls = new List<Listas.Consultar_Construcciones_Result>();
                    }
                }
                else
                {
                    ls = new List<Listas.Consultar_Construcciones_Result>();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                ls = new List<Listas.Consultar_Construcciones_Result>();
            }
            this.Desconectar();
            return ls;
        }
        #endregion

        #region CONSULTAR PREDIO
        public List<Listas.Consultar_Predio_Result> Consultar_Predio(string strMunicipio
                                    , string strSector
                                    , string strCorregimiento
                                    , string strBarrio
                                    , string strManzna
                                    , string strPredio
                                    , string strEdificio
                                    , string strUnidadPredial
                                    , string strFichasPrediales)
        {
            List<Listas.Consultar_Predio_Result> objLstPredio = new List<Listas.Consultar_Predio_Result>();
            try
            {
                strMunicipio = strMunicipio == string.Empty ? "null  \n" : "'" + strMunicipio + "'  \n";
                strSector = strSector == string.Empty ? "null  \n" : strSector;
                strCorregimiento = strCorregimiento == string.Empty ? "null  \n" : "'" + strCorregimiento + "'  \n";
                strBarrio = strBarrio == string.Empty ? "null  \n" : "'" + strBarrio + "'  \n";
                strManzna = strManzna == string.Empty ? "null  \n" : "'" + strManzna + "'  \n";
                strPredio = strPredio == string.Empty ? "null  \n" : "'" + strPredio + "'  \n";
                strEdificio = strEdificio == string.Empty ? "null  \n" : "'" + strEdificio + "'  \n";
                strUnidadPredial = strUnidadPredial == string.Empty ? "null  \n" : "'" + strUnidadPredial + "'  \n";

                string sql = "declare @Municipio varchar(3)=" + strMunicipio + " \n";
                sql += "declare @Sector int=" + strSector + "  \n";
                sql += "declare @Corregimiento varchar(2)=" + strCorregimiento + "  \n";
                sql += "declare @Barrio varchar(3)=" + strBarrio + "  \n";
                sql += "declare @Manzana varchar(3)=" + strManzna + "  \n";
                sql += "declare @Predio varchar(5)=" + strPredio + "  \n";
                sql += "declare @Edificio varchar(3)=" + strEdificio + "  \n";
                sql += "declare @UnidadPredial varchar(3)=" + strUnidadPredial + "  \n";
                sql += "select   \n";
                sql += "convert(varchar(max),P.FIPRDIRE) Dirreccion   \n";
                sql += ",convert(varchar(3),P.FIPRMUNI) Municipio   \n";
                sql += ",convert(varchar(1),P.FIPRCLSE) Clase   \n";
                sql += ",convert(varchar(2),P.FIPRCORR) Corregimiento   \n";
                sql += ",convert(varchar(3),P.FIPRBARR) Barrio   \n";
                sql += ",convert(varchar(3),P.FIPRMANZ) Manzana   \n";
                sql += ",convert(varchar(5),P.FIPRPRED) Predio   \n";
                sql += ",convert(varchar(3),P.FIPREDIF) Edificio   \n";
                sql += ",convert(varchar(5),P.FIPRUNPR) UnidadPredial   \n";
                sql += ",convert(varchar(3),P.FIPRMUAN) AntMunicipio   \n";
                sql += ",convert(varchar(1),P.FIPRCSAN) AntClase   \n";
                sql += ",convert(varchar(2),P.FIPRCOAN) AntCorregimiento   \n";
                sql += ",convert(varchar(3),P.FIPRBAAN) AntBarrio   \n";
                sql += ",convert(varchar(3),P.FIPRMAAN) AntManzana   \n";
                sql += ",convert(varchar(5),P.FIPRPRAN) AntPredio   \n";
                sql += ",convert(varchar(3),P.FIPREDAN) AntEdificio   \n";
                sql += ",convert(varchar(5),P.FIPRUPAN) AntUnidadPredial   \n";
                sql += ",convert(varchar(2),D.FPDEDEEC) DestinoEconomico   \n";
                sql += ",convert(varchar(2),P.FIPRCAPR) CaracteristicaPredio   \n";
                sql += ",convert(varchar(2),P.FIPRMOAD) ModoAdquisicion   \n";
                sql += ",convert(varchar(2),P.FIPRLITI) Litigio   \n";
                sql += ",convert(varchar(max),P.FIPRPOLI) PorcentajeLitigio   \n";
                sql += " ,isnull((select top 1 PR.FPPRMAIN    \n";
                sql += " from [dbo].[FIPRPROP] PR    \n";
                sql += " where PR.FPPRNUFI=P.FIPRNUFI),'') Matricula    \n";
                sql += ",convert(varchar(35),P.FIPRNUFI) NumeroFicha     \n";
                sql += ",isnull((select top 1 PR.FPPRTOMO    \n";
                sql += "from [dbo].[FIPRPROP] PR    \n";
                sql += "where PR.FPPRNUFI=P.FIPRNUFI),'') Tomo    \n";
                sql += " ,convert(varchar(250),P.[FIPRARTE]) AreaTerreno  \n";
                sql += " ,convert(varchar(250),P.[FIPRCOED]) CoeficientePredio  \n";
                sql += " ,convert(varchar(2),P.[FIPRTIFI]) TipoFicha  \n";

                sql += ",convert(varchar(250),P.[FIPRATLO]) AreaTotalLote  \n";
                sql += ",convert(varchar(250),P.[FIPRACLO])AreaComunLote  \n";
                sql += ",convert(varchar(250),P.[FIPRAPLO])AreaPrivadaLote  \n";
                sql += ",convert(varchar(250),P.[FIPRTOED]) Edificios  \n";
                sql += ",convert(varchar(250),P.[FIPRUNCO])UnidadesEnCOndominio  \n";
                sql += ",convert(varchar(250),P.[FIPRURPH])UnidadesRPH  \n";
                sql += ",convert(varchar(250),P.[FIPRAPCA])AparatamentosOCasas  \n";
                sql += ",convert(varchar(250),P.[FIPRLOCA])Locales  \n";
                sql += ",convert(varchar(250),P.[FIPRCUUT])CUartosUriles  \n";
                sql += ",convert(varchar(250),P.[FIPRGACU])GarajesCubiertos  \n";
                sql += ",convert(varchar(250),P.[FIPRGADE])GarejesDescubierto  \n";
                sql += ",convert(varchar(250),P.[FIPRPISO])Pisos  \n";
                sql += ",isnull((select top 1 C.[CODIGO_NACIONAL] from [dbo].[CODIGONACIONAL] C where C.[FICHA]=P.FIPRNUFI),' ') \n";

                sql += ",(select top 1 MM.MUNIDESC  \n";
                sql += "from [dbo].[MANT_MUNICIPIO] MM \n";
                sql += "where MM.MUNICODI=P.FIPRMUNI \n";
                sql += "and MM.MUNIDEPA=P.FIPRDEPA) Municipio \n";
                sql += ",(select top 1 MC.CORRDESC \n";
                sql += "from [dbo].[MANT_CORREGIMIENTO] MC \n";
                sql += "where MC.CORRDEPA=P.FIPRDEPA \n";
                sql += "and MC.CORRMUNI=P.FIPRMUNI \n";
                sql += "and MC.CORRCODI=P.FIPRCORR)Departamento \n";
                sql += ",(select top 1 MBV.BAVEDESC \n";
                sql += "from [dbo].[MANT_BARRVERE] MBV \n";
                sql += "where MBV.BAVEDEPA=P.FIPRDEPA \n";
                sql += "and MBV.BAVEMUNI=P.FIPRMUNI \n";
                sql += "and MBV.BAVECORR=P.FIPRCORR \n";
                sql += "and MBV.BAVECODI=(case P.[FIPRBARR] \n";
                sql += "				when '000' then P.FIPRMANZ \n";
                sql += "				ElSE P.FIPRBARR \n";
                sql += "				end)) Vereda \n";

                sql += "from [dbo].[FICHPRED] P  \n";
                sql += "INNER JOIN [dbo].[FIPRDEEC] D ON P.FIPRNUFI=D.FPDENUFI \n";
                sql += "where (P.FIPRMUNI=@Municipio or @Municipio is null)  \n";
                sql += "and (P.FIPRCLSE=@Sector or @Sector is null)  \n";
                sql += "and (P.FIPRCORR =@Corregimiento or @Corregimiento is null)  \n";
                sql += "and (P.FIPRBARR=@Barrio or @Barrio is null)  \n";
                sql += "and (P.FIPRMANZ=@Manzana or @Manzana is null)  \n";
                sql += "and (P.FIPRPRED=@Predio or @Predio is null)  \n";
                sql += "and (P.FIPREDIF=@Edificio or @Edificio is null)  \n";
                sql += "and(P.FIPRUNPR=@UnidadPredial or @UnidadPredial is null)  \n";
                sql += "and P.[FIPRESTA]='ac' \n";
                sql += strFichasPrediales != string.Empty ? "and P.FIPRNUFI in (" + strFichasPrediales + ")  \n" : string.Empty;
                SqlDataReader read = this.EjecutarConsulta(sql);
                if (read != null)
                {
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            Listas.Consultar_Predio_Result Predio = new Listas.Consultar_Predio_Result();
                            Predio.strDirreccion = (read[0] == null ? string.Empty : read.GetString(0));
                            Predio.strMunicipio = (read[1] == null ? string.Empty : read.GetString(1));
                            Predio.strSector = (read[2] == null ? string.Empty : read.GetString(2));
                            Predio.strCorregimiento = (read[3] == null ? string.Empty : read.GetString(3));
                            Predio.strBarrio = (read[4] == null ? string.Empty : read.GetString(4));
                            Predio.strManzana = (read[5] == null ? string.Empty : read.GetString(5));
                            Predio.strPredio = (read[6] == null ? string.Empty : read.GetString(6));
                            Predio.strEdificio = (read[7] == null ? string.Empty : read.GetString(7));
                            Predio.strUnidadPredial = (read[8] == null ? string.Empty : read.GetString(8));
                            Predio.strAntMunicipio = (read[9] == null ? string.Empty : read.GetString(9));
                            Predio.strAntSector = (read[10] == null ? string.Empty : read.GetString(10));
                            Predio.strAntCorregimiento = (read[11] == null ? string.Empty : read.GetString(11));
                            Predio.strAntBarrio = (read[12] == null ? string.Empty : read.GetString(12));
                            Predio.strAntManzana = (read[13] == null ? string.Empty : read.GetString(13));
                            Predio.strAntPredio = (read[14] == null ? string.Empty : read.GetString(14));
                            Predio.strAntEdificio = (read[15] == null ? string.Empty : read.GetString(15));
                            Predio.strAntUnidadPredial = (read[16] == null ? string.Empty : read.GetString(16));
                            Predio.strDestinoEconomico = (read[17] == null ? string.Empty : read.GetString(17));
                            Predio.strCaracteristicaPredio = (read[18] == null ? string.Empty : read.GetString(18));
                            Predio.strModoAdquisicion = (read[19] == null ? string.Empty : read.GetString(19));
                            Predio.strLitigio = (read[20] == null ? string.Empty : read.GetString(20));
                            Predio.strPorcentajeLitigio = (read[21] == null ? string.Empty : read.GetString(21));
                            Predio.strMatricula = (read[22] == null ? string.Empty : read.GetString(22));
                            Predio.strNumeroFicha = (read[23] == null ? string.Empty : read.GetString(23));
                            Predio.strTomo = (read[24] == null ? string.Empty : read.GetString(24));
                            Predio.strAreaTerreno = (read[25] == null ? string.Empty : read.GetString(25));
                            Predio.strCoeficientePredio = (read[26] == null ? string.Empty : read.GetString(26));
                            Predio.strTipoFicha = (read[27] == null ? string.Empty : read.GetString(27));
                            Predio.strAreaTotalLote = (read[28] == null ? string.Empty : read.GetString(28));
                            Predio.strAreaComunLote = (read[29] == null ? string.Empty : read.GetString(29));
                            Predio.strAreaPrivadaLote = (read[30] == null ? string.Empty : read.GetString(30));
                            Predio.strTotalEdificios = (read[31] == null ? string.Empty : read.GetString(31));
                            Predio.strUnidadesEnCondominio = (read[32] == null ? string.Empty : read.GetString(32));
                            Predio.strUnidadesRPH = (read[33] == null ? string.Empty : read.GetString(33));
                            Predio.strAparatamentosOCasas = (read[34] == null ? string.Empty : read.GetString(34));
                            Predio.strLocales = (read[35] == null ? string.Empty : read.GetString(35));
                            Predio.strCuartosUriles = (read[36] == null ? string.Empty : read.GetString(36));
                            Predio.strGarajesCubiertos = (read[37] == null ? string.Empty : read.GetString(37));
                            Predio.strGarejesDescubierto = (read[38] == null ? string.Empty : read.GetString(38));
                            Predio.strPisos = (read[39] == null ? string.Empty : read.GetString(39));
                            Predio.strNPN = (read[40] == null ? string.Empty : read.GetString(40));

                            /*Predio.strDescripcionMunicipio = (read[41] == null ? string.Empty : read.GetString(41).Trim());
                            Predio.strDescripcionCorregimiento = (read[42] == null ? string.Empty : read.GetString(42).Trim());
                            Predio.strDescripcionVereda = Predio.strSector == "2" ? (read[43] == null ? string.Empty : Convert.ToString(read[43]).Trim()) : Predio.strManzana;
                            Predio.strDescripcionBarrio = Predio.strSector == "1" ? (read[43] == null ? string.Empty : Convert.ToString(read[43]).Trim()) : Predio.strBarrio;*/
                            objLstPredio.Add(Predio);

                        }
                    }
                    else
                    {
                        objLstPredio = new List<Listas.Consultar_Predio_Result>();
                    }
                }
                else
                {
                    objLstPredio = new List<Listas.Consultar_Predio_Result>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                objLstPredio = new List<Listas.Consultar_Predio_Result>();
            }
            this.Desconectar();
            return objLstPredio;
        }

        public List<Listas.Consultar_Predio_Result> Consultar_PredioSinDestino(string strMunicipio
                                   , string strSector
                                   , string strCorregimiento
                                   , string strBarrio
                                   , string strManzna
                                   , string strPredio
                                   , string strEdificio
                                   , string strUnidadPredial
                                   , string strFichasPrediales
                                   , string strDescripcionMunicipio
                                   , string strstrDescripcionCorregimiento)
        {
            List<Listas.Consultar_Predio_Result> objLstPredio = new List<Listas.Consultar_Predio_Result>();
            try
            {
                strMunicipio = strMunicipio == string.Empty ? "null  \n" : "'" + strMunicipio + "'  \n";
                strSector = strSector == string.Empty ? "null  \n" : strSector;
                strCorregimiento = strCorregimiento == string.Empty ? "null  \n" : "'" + strCorregimiento + "'  \n";
                strBarrio = strBarrio == string.Empty ? "null  \n" : "'" + strBarrio + "'  \n";
                strManzna = strManzna == string.Empty ? "null  \n" : "'" + strManzna + "'  \n";
                strPredio = strPredio == string.Empty ? "null  \n" : "'" + strPredio + "'  \n";
                strEdificio = strEdificio == string.Empty ? "null  \n" : "'" + strEdificio + "'  \n";
                strUnidadPredial = strUnidadPredial == string.Empty ? "null  \n" : "'" + strUnidadPredial + "'  \n";

                string sql = "declare @Municipio varchar(3)=" + strMunicipio + " \n";
                sql += "declare @Sector int=" + strSector + "  \n";
                sql += "declare @Corregimiento varchar(2)=" + strCorregimiento + "  \n";
                sql += "declare @Barrio varchar(3)=" + strBarrio + "  \n";
                sql += "declare @Manzana varchar(3)=" + strManzna + "  \n";
                sql += "declare @Predio varchar(5)=" + strPredio + "  \n";
                sql += "declare @Edificio varchar(3)=" + strEdificio + "  \n";
                sql += "declare @UnidadPredial varchar(3)=" + strUnidadPredial + "  \n";
                sql += "select   \n";
                sql += "convert(varchar(max),P.FIPRDIRE) Dirreccion   \n";
                sql += ",convert(varchar(3),P.FIPRMUNI) Municipio   \n";
                sql += ",convert(varchar(1),P.FIPRCLSE) Clase   \n";
                sql += ",convert(varchar(2),P.FIPRCORR) Corregimiento   \n";
                sql += ",convert(varchar(3),P.FIPRBARR) Barrio   \n";
                sql += ",convert(varchar(3),P.FIPRMANZ) Manzana   \n";
                sql += ",convert(varchar(5),P.FIPRPRED) Predio   \n";
                sql += ",convert(varchar(3),P.FIPREDIF) Edificio   \n";
                sql += ",convert(varchar(5),P.FIPRUNPR) UnidadPredial   \n";
                sql += ",convert(varchar(3),P.FIPRMUAN) AntMunicipio   \n";
                sql += ",convert(varchar(1),P.FIPRCSAN) AntClase   \n";
                sql += ",convert(varchar(2),P.FIPRCOAN) AntCorregimiento   \n";
                sql += ",convert(varchar(3),P.FIPRBAAN) AntBarrio   \n";
                sql += ",convert(varchar(3),P.FIPRMAAN) AntManzana   \n";
                sql += ",convert(varchar(5),P.FIPRPRAN) AntPredio   \n";
                sql += ",convert(varchar(3),P.FIPREDAN) AntEdificio   \n";
                sql += ",convert(varchar(5),P.FIPRUPAN) AntUnidadPredial   \n";

                sql += ",convert(varchar(2),P.FIPRCAPR) CaracteristicaPredio   \n";
                sql += ",convert(varchar(2),P.FIPRMOAD) ModoAdquisicion   \n";
                sql += ",convert(varchar(2),P.FIPRLITI) Litigio   \n";
                sql += ",convert(varchar(max),P.FIPRPOLI) PorcentajeLitigio   \n";
                sql += " ,isnull((select top 1 PR.FPPRMAIN    \n";
                sql += " from [dbo].[FIPRPROP] PR    \n";
                sql += " where PR.FPPRNUFI=P.FIPRNUFI),'') Matricula    \n";
                sql += ",convert(varchar(35),P.FIPRNUFI) NumeroFicha     \n";
                sql += ",isnull((select top 1 PR.FPPRTOMO    \n";
                sql += "from [dbo].[FIPRPROP] PR    \n";
                sql += "where PR.FPPRNUFI=P.FIPRNUFI),'') Tomo    \n";
                sql += " ,convert(varchar(250),P.[FIPRARTE]) AreaTerreno  \n";
                sql += " ,convert(varchar(250),P.[FIPRCOED]) CoeficientePredio  \n";
                sql += " ,convert(varchar(2),P.[FIPRTIFI]) TipoFicha  \n";

                sql += ",convert(varchar(250),P.[FIPRATLO]) AreaTotalLote  \n";
                sql += ",convert(varchar(250),P.[FIPRACLO])AreaComunLote  \n";
                sql += ",convert(varchar(250),P.[FIPRAPLO])AreaPrivadaLote  \n";
                sql += ",convert(varchar(250),P.[FIPRTOED]) Edificios  \n";
                sql += ",convert(varchar(250),P.[FIPRUNCO])UnidadesEnCOndominio  \n";
                sql += ",convert(varchar(250),P.[FIPRURPH])UnidadesRPH  \n";
                sql += ",convert(varchar(250),P.[FIPRAPCA])AparatamentosOCasas  \n";
                sql += ",convert(varchar(250),P.[FIPRLOCA])Locales  \n";
                sql += ",convert(varchar(250),P.[FIPRCUUT])CUartosUriles  \n";
                sql += ",convert(varchar(250),P.[FIPRGACU])GarajesCubiertos  \n";
                sql += ",convert(varchar(250),P.[FIPRGADE])GarejesDescubierto  \n";
                sql += ",convert(varchar(250),P.[FIPRPISO])Pisos  \n";
                sql += ",isnull((select C.[CODIGO_NACIONAL] from [dbo].[CODIGONACIONAL] C where C.[FICHA]=P.FIPRNUFI),' ') \n";

                sql += ",(select MM.MUNIDESC  \n";
                sql += "from [dbo].[MANT_MUNICIPIO] MM \n";
                sql += "where MM.MUNICODI=P.FIPRMUNI \n";
                sql += "and MM.MUNIDEPA=P.FIPRDEPA) Municipio \n";
                sql += ",(select MC.CORRDESC \n";
                sql += "from [dbo].[MANT_CORREGIMIENTO] MC \n";
                sql += "where MC.CORRDEPA=P.FIPRDEPA \n";
                sql += "and MC.CORRMUNI=P.FIPRMUNI \n";
                sql += "and MC.CORRCODI=P.FIPRCORR)Departamento \n";
                sql += ",(select MBV.BAVEDESC \n";
                sql += "from [dbo].[MANT_BARRVERE] MBV \n";
                sql += "where MBV.BAVEDEPA=P.FIPRDEPA \n";
                sql += "and MBV.BAVEMUNI=P.FIPRMUNI \n";
                sql += "and MBV.BAVECORR=P.FIPRCORR \n";
                sql += "and MBV.BAVECODI=(case P.[FIPRBARR] \n";
                sql += "				when '000' then P.FIPRMANZ \n";
                sql += "				ElSE P.FIPRBARR \n";
                sql += "				end)) Vereda \n";

                sql += "from [dbo].[FICHPRED] P  \n";

                sql += "where (P.FIPRMUNI=@Municipio or @Municipio is null)  \n";
                sql += "and (P.FIPRCLSE=@Sector or @Sector is null)  \n";
                sql += "and (P.FIPRCORR =@Corregimiento or @Corregimiento is null)  \n";
                sql += "and (P.FIPRBARR=@Barrio or @Barrio is null)  \n";
                sql += "and (P.FIPRMANZ=@Manzana or @Manzana is null)  \n";
                sql += "and (P.FIPRPRED=@Predio or @Predio is null)  \n";
                sql += "and (P.FIPREDIF=@Edificio or @Edificio is null)  \n";
                sql += "and(P.FIPRUNPR=@UnidadPredial or @UnidadPredial is null)  \n";
                sql += "and P.[FIPRESTA]='ac' \n";
                sql += strFichasPrediales != string.Empty ? "and P.FIPRNUFI in (" + strFichasPrediales + ")  \n" : string.Empty;
                SqlDataReader read = this.EjecutarConsulta(sql);
                if (read != null)
                {
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            try
                            {


                                Listas.Consultar_Predio_Result Predio = new Listas.Consultar_Predio_Result();
                                Predio.strDirreccion = (read[0] == null ? string.Empty : read.GetString(0));
                                Predio.strMunicipio = (read[1] == null ? string.Empty : read.GetString(1));
                                Predio.strSector = (read[2] == null ? string.Empty : read.GetString(2));
                                Predio.strCorregimiento = (read[3] == null ? string.Empty : read.GetString(3));
                                Predio.strBarrio = (read[4] == null ? string.Empty : read.GetString(4));
                                Predio.strManzana = (read[5] == null ? string.Empty : read.GetString(5));
                                Predio.strPredio = (read[6] == null ? string.Empty : read.GetString(6));
                                Predio.strEdificio = (read[7] == null ? string.Empty : read.GetString(7));
                                Predio.strUnidadPredial = (read[8] == null ? string.Empty : read.GetString(8));
                                Predio.strAntMunicipio = (read[9] == null ? string.Empty : read.GetString(9));
                                Predio.strAntSector = (read[10] == null ? string.Empty : read.GetString(10));
                                Predio.strAntCorregimiento = (read[11] == null ? string.Empty : read.GetString(11));
                                Predio.strAntBarrio = (read[12] == null ? string.Empty : read.GetString(12));
                                Predio.strAntManzana = (read[13] == null ? string.Empty : read.GetString(13));
                                Predio.strAntPredio = (read[14] == null ? string.Empty : read.GetString(14));
                                Predio.strAntEdificio = (read[15] == null ? string.Empty : read.GetString(15));
                                Predio.strAntUnidadPredial = (read[16] == null ? string.Empty : read.GetString(16));
                                Predio.strCaracteristicaPredio = (read[17] == null ? string.Empty : read.GetString(17));
                                Predio.strModoAdquisicion = (read[18] == null ? string.Empty : read.GetString(18));
                                Predio.strLitigio = (read[19] == null ? string.Empty : read.GetString(19));
                                Predio.strPorcentajeLitigio = (read[20] == null ? string.Empty : read.GetString(20));
                                Predio.strMatricula = (read[21] == null ? string.Empty : read.GetString(21));
                                Predio.strNumeroFicha = (read[22] == null ? string.Empty : read.GetString(22));
                                Predio.strTomo = (read[23] == null ? string.Empty : read.GetString(23));
                                Predio.strAreaTerreno = (read[24] == null ? string.Empty : read.GetString(24));
                                Predio.strCoeficientePredio = (read[25] == null ? string.Empty : read.GetString(25));
                                Predio.strTipoFicha = (read[26] == null ? string.Empty : read.GetString(26));
                                Predio.strAreaTotalLote = (read[27] == null ? string.Empty : read.GetString(27));
                                Predio.strAreaComunLote = (read[28] == null ? string.Empty : read.GetString(28));
                                Predio.strAreaPrivadaLote = (read[29] == null ? string.Empty : read.GetString(29));
                                Predio.strTotalEdificios = (read[30] == null ? string.Empty : read.GetString(30));
                                Predio.strUnidadesEnCondominio = (read[31] == null ? string.Empty : read.GetString(31));
                                Predio.strUnidadesRPH = (read[32] == null ? string.Empty : read.GetString(32));
                                Predio.strAparatamentosOCasas = (read[33] == null ? string.Empty : read.GetString(33));
                                Predio.strLocales = (read[34] == null ? string.Empty : read.GetString(34));
                                Predio.strCuartosUriles = (read[35] == null ? string.Empty : read.GetString(35));
                                Predio.strGarajesCubiertos = (read[36] == null ? string.Empty : read.GetString(36));
                                Predio.strGarejesDescubierto = (read[37] == null ? string.Empty : read.GetString(37));
                                Predio.strPisos = (read[38] == null ? string.Empty : read.GetString(38));
                                Predio.strNPN = (read[39] == null ? string.Empty : read.GetString(39));
                                Predio.strDescripcionMunicipio = (read[40] == null ? string.Empty : read.GetString(40));
                                Predio.strDescripcionCorregimiento = (read[41] == null ? string.Empty : read.GetString(41));
                                Predio.strDescripcionVereda = Predio.strSector == "2" ? (read[42] == null ? string.Empty : Convert.ToString(read[42])) : Predio.strManzana;
                                Predio.strDescripcionBarrio = Predio.strSector == "1" ? (read[42] == null ? string.Empty : Convert.ToString(read[42])) : Predio.strBarrio;
                                objLstPredio.Add(Predio);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: " + ex.Message);
                                objLstPredio = new List<Listas.Consultar_Predio_Result>();
                            }

                        }
                    }
                    else
                    {
                        objLstPredio = new List<Listas.Consultar_Predio_Result>();
                    }
                }
                else
                {
                    objLstPredio = new List<Listas.Consultar_Predio_Result>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                objLstPredio = new List<Listas.Consultar_Predio_Result>();
            }
            this.Desconectar();
            return objLstPredio;
        }
        #endregion

        #region CONSULTAR PROPIETARIO
        public List<Listas.Consultar_Propietario_Result> Consultar_Propietario(int nufi)
        {
            List<Listas.Consultar_Propietario_Result> ls = new List<Listas.Consultar_Propietario_Result>();
            try
            {
                string sql = "";
                sql = " declare @nufi int=" + nufi + "  \n";
                sql += " SELECT   \n";
                sql += " convert(varchar(3),P.FPPRCAPR )   \n";
                sql += " ,convert(varchar(3),P.FPPRGRAV )   \n";
                sql += " ,convert(varchar(3),P.FPPRSEXO)    \n";
                sql += " ,LTRIM( RTRIM(P.FPPRNOMB))+' '+LTRIM( RTRIM(P.FPPRPRAP))+' '+LTRIM( RTRIM(P.FPPRSEAP)) Nombre     \n";
                sql += " ,convert(varchar(3),P.FPPRSICO )     \n";
                sql += " ,LTRIM( RTRIM(P.FPPRTIDO)) TipoDocumento     \n";
                sql += " ,(CASE     \n";
                sql += "     WHEN LTRIM( RTRIM(P.FPPRTIDO))='8' THEN ''    \n";
                sql += "     ELSE LTRIM( RTRIM(convert(varchar(250),P.FPPRNUDO)))    \n";
                sql += " END) Documento      \n";
                sql += " ,convert(varchar(250),P.FPPRDERE )     \n";
                sql += " ,convert(varchar(250),P.FPPRESCR )    \n";
                sql += " ,convert(varchar(250),P.FPPRFEES )    \n";
                sql += " ,convert(varchar(250),P.FPPRNOTA )    \n";
                sql += " ,convert(varchar(250),P.FPPRDENO )    \n";
                sql += " ,convert(varchar(250),P.FPPRMUNO )    \n";
                sql += " ,convert(varchar(250),P.FPPRFERE )    \n";
                sql += " ,isnull((select PA.PRANCAAC   \n";
                sql += " 		from [PROPANTE] PA    \n";
                sql += " 		where PA.PRANNUFI=P.FPPRNUFI   \n";
                sql += " 		and PA.PRANNUDO=P.FPPRNUDO)  ,'')      \n";
                sql += " ,isnull((select LTRIM(RTRIM(PA.PRANNOMB)) +' '+LTRIM(RTRIM(PA.PRANPRAP))+' '+LTRIM(RTRIM(PA.PRANSEAP))    \n";
                sql += " 		from [PROPANTE] PA    \n";
                sql += " 		where PA.PRANNUFI=P.FPPRNUFI   \n";
                sql += " 		and PA.PRANNUDO=P.FPPRNUDO)  ,''),     \n";
                sql += "LTRIM( RTRIM(P.FPPRNOMB)),  \n";
                sql += "+LTRIM( RTRIM(P.FPPRPRAP)), \n";
                sql += "+LTRIM( RTRIM(P.FPPRSEAP)) \n";
                sql += ", P.FPPRIDRE \n";
                sql += " FROM [dbo].[FIPRPROP]  P      \n";
                sql += " where P.FPPRNUFI=@nufi      \n";
                sql += " order by P.FPPRIDRE     \n";
                SqlDataReader read = this.EjecutarConsulta(sql);
                if (read != null)
                {
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            Listas.Consultar_Propietario_Result objPropietario = new Listas.Consultar_Propietario_Result();
                            objPropietario.strCalidadPropietario = (read[0] == null ? string.Empty : read.GetString(0));
                            objPropietario.strGravable = (read[1] == null ? string.Empty : read.GetString(1));
                            objPropietario.strSexo = (read[2] == null ? string.Empty : read.GetString(2));
                            objPropietario.strNombreApellido = (read[3] == null ? string.Empty : read.GetString(3));
                            objPropietario.strSiglasComercial = (read[4] == null ? string.Empty : read.GetString(4));
                            objPropietario.strTipoDocumento = (read[5] == null ? string.Empty : read.GetString(5));
                            objPropietario.strDocumento = (read[6] == null ? string.Empty : read.GetString(6));
                            objPropietario.strDerecho = (read[7] == null ? string.Empty : read.GetString(7));
                            objPropietario.strEscritura = (read[8] == null ? string.Empty : read.GetString(8));
                            objPropietario.strFecha = (read[9] == null ? string.Empty : read.GetString(9));
                            objPropietario.strEntidad = (read[10] == null ? string.Empty : read.GetString(10));
                            objPropietario.strDepartamento = (read[11] == null ? string.Empty : read.GetString(11));
                            objPropietario.strMunicipio = (read[12] == null ? string.Empty : read.GetString(12));
                            objPropietario.strFechaRegistro = (read[13] == null ? string.Empty : read.GetString(13));
                            objPropietario.strCausaActo = (read[14] == null ? string.Empty : read.GetString(14));
                            objPropietario.strPropietarioAnterior = (read[15] == null ? string.Empty : read.GetString(15));
                            objPropietario.strNombre = (read[16] == null ? string.Empty : read.GetString(16));
                            objPropietario.strPrimerApellido = (read[17] == null ? string.Empty : read.GetString(17));
                            objPropietario.strSegundoApellido = (read[18] == null ? string.Empty : read.GetString(18));
                            objPropietario.intIPropietario = (read[19] == null ? 0 : read.GetInt32(19));
                            ls.Add(objPropietario);
                        }
                    }
                    else
                    {
                        ls = new List<Listas.Consultar_Propietario_Result>();
                    }
                }
                else
                {
                    ls = new List<Listas.Consultar_Propietario_Result>();
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error: " + ex.Message);
                ls = new List<Listas.Consultar_Propietario_Result>();
            }
            this.Desconectar();
            return ls;
        }

        #endregion

        #region CONSULTAR LINDERO
        public List<Listas.Consultar_Colindantes_Result> Consultar_Colindantes(int nufi, string strPuntoCardinal)
        {
            List<Listas.Consultar_Colindantes_Result> ls = new List<Listas.Consultar_Colindantes_Result>();
            try
            {
                string sql = "";
                sql += " declare @nufi int=" + nufi + "      \n";
                sql += "   declare @PuntoCardinal varchar(2)='" + strPuntoCardinal + "'     \n";
                sql += " select      \n";
                sql += " (CASE       \n";
                sql += " WHEN L.FPLIPUCA='N' THEN 'NORTE'      \n";
                sql += " WHEN L.FPLIPUCA='E' THEN 'ORIENTE'      \n";
                sql += " WHEN L.FPLIPUCA='S' THEN 'SUR'      \n";
                sql += " WHEN L.FPLIPUCA='O' THEN 'OCCIDENTE'       \n";
                sql += " WHEN L.FPLIPUCA='ZE' THEN 'ZENIT'      \n";
                sql += " WHEN L.FPLIPUCA='NA' THEN 'NADIR'      \n";
                sql += " END	      \n";
                sql += " ) ORIENTACION	      \n";
                sql += " ,L.FPLICOLI      \n";
                sql += " from [dbo].[FIPRLIND] L      \n";
                sql += " where L.FPLINUFI=@nufi      \n";
                sql += " and L.[FPLIPUCA]=@PuntoCardinal     \n";
                sql += " order by L.FPLIPUCA ,L.FPLICOLI      \n";
                SqlDataReader read = this.EjecutarConsulta(sql);

                if (read != null)
                {
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            Listas.Consultar_Colindantes_Result objColindante = new Listas.Consultar_Colindantes_Result();
                            objColindante.strOrientacion = (read[0] == null ? string.Empty : read.GetString(0));
                            objColindante.strColindante = (read[1] == null ? string.Empty : read.GetString(1));
                            ls.Add(objColindante);
                        }
                    }
                    else
                    {
                        ls = new List<Listas.Consultar_Colindantes_Result>();
                    }
                }
                else
                {
                    ls = new List<Listas.Consultar_Colindantes_Result>();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                ls = new List<Listas.Consultar_Colindantes_Result>();
            }
            this.Desconectar();
            return ls;
        }

        #endregion

        #region CONSULTAR INFORMACION COMPLEMENTARIA
        public List<Listas.Consultar_Informacion_Complementaria_Result> Consultar_Inforamcion_Complementaria(int nufi)
        {
            List<Listas.Consultar_Informacion_Complementaria_Result> ls = new List<Listas.Consultar_Informacion_Complementaria_Result>();
            try
            {
                string sql = "";
                sql += " declare @nufi int=" + nufi + "  \n";
                sql += "SELECT  [RECOINGE] Ingeniero  \n";
                sql += "  ,[RECOPRED] Prediador  \n";
                sql += ",[RECOEMPR] Empresa  \n";
                sql += ",[RECOPROP] Propietarios  \n";
                sql += " ,[RECOREPR] RepresentantePropietario  \n";
                sql += ",(case  \n";
                sql += "  when  [RECOFECH]='-  -      ' then ''  \n";
                sql += "  when [RECOFECH]<>'-  -      ' then [RECOFECH]  \n";
                sql += "end) Fecha  \n";
                sql += "  ,(select P.FIPROBSE  \n";
                sql += "  from [dbo].[FICHPRED] P  \n";
                sql += "  where P.FIPRNUFI=R.RECONUFI) Observacion  \n";
                sql += " FROM [dbo].[REGICONT] R  \n";
                sql += " where R.RECONUFI=@nufi \n";

                SqlDataReader read = this.EjecutarConsulta(sql);

                if (read != null)
                {
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            Listas.Consultar_Informacion_Complementaria_Result objInformacionComplementaria = new Listas.Consultar_Informacion_Complementaria_Result();

                            objInformacionComplementaria.strIngenieroResidente = (read[0] == null ? string.Empty : read.GetString(0));
                            objInformacionComplementaria.strPrediador = (read[1] == null ? string.Empty : read.GetString(1));
                            objInformacionComplementaria.strEmpresa = (read[2] == null ? string.Empty : read.GetString(2));
                            objInformacionComplementaria.strPropietario = (read[3] == null ? string.Empty : read.GetString(3));
                            objInformacionComplementaria.strRespresentante = (read[4] == null ? string.Empty : read.GetString(4));
                            objInformacionComplementaria.strFecha = (read[5] == null ? string.Empty : read.GetString(5));
                            objInformacionComplementaria.strObservacion = (read[6] == null ? string.Empty : read.GetString(6));

                            ls.Add(objInformacionComplementaria);
                        }
                    }
                    else
                    {
                        ls = new List<Listas.Consultar_Informacion_Complementaria_Result>();
                    }
                }
                else
                {
                    ls = new List<Listas.Consultar_Informacion_Complementaria_Result>();
                }

            }
            catch (Exception ex)
            {
                ls = new List<Listas.Consultar_Informacion_Complementaria_Result>();
                MessageBox.Show("Error: " + ex.Message);
            }
            this.Desconectar();
            return ls;
        }
        #endregion

        #region CONSULTAR INFORMACION GRAFICA
        public List<Listas.Consultar_Informacion_Geografica_Result> Consultar_Informacion_Geografico(int Nufi)
        {
            List<Listas.Consultar_Informacion_Geografica_Result> ls = new List<Listas.Consultar_Informacion_Geografica_Result>();
            string sql = "";
            sql += " declare @nufi int=" + Nufi + "  \n";
            sql += "select C.[FPCAPLAN]   \n";
            sql += ",C.[FPCAVENT]   \n";
            sql += ",C.[FPCAESGR]   \n";
            sql += ",convert(varchar(10),C.[FPCAVIGR] )   \n";
            sql += ",C.FPCAVUEL    \n";
            sql += ",C.FPCAFAJA    \n";
            sql += ",C.FPCAFOTO    \n";
            sql += ",convert(varchar(10),[FPCAVIAE]  )    \n";
            sql += ",[FPCAAMPL]    \n";
            sql += ",[FPCAESAE]    \n";
            sql += "from [dbo].[FIPRCART] C   \n";
            sql += "where C.FPCANUFI=@nufi	   \n";
            sql += "order by C.[FPCAIDRE]   \n";
            SqlDataReader read = this.EjecutarConsulta(sql);

            if (read != null)
            {
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Listas.Consultar_Informacion_Geografica_Result objInfromacionGeografica = new Listas.Consultar_Informacion_Geografica_Result();
                        objInfromacionGeografica.strPlancha = (read[0] == null ? string.Empty : read.GetString(0));
                        objInfromacionGeografica.strVentana = (read[1] == null ? string.Empty : read.GetString(1));
                        objInfromacionGeografica.strEscala = (read[2] == null ? string.Empty : read.GetString(2));
                        objInfromacionGeografica.strVegencia = (read[3] == null ? string.Empty : read.GetString(3));
                        objInfromacionGeografica.strVuelo = (read[4] == null ? string.Empty : read.GetString(4));
                        objInfromacionGeografica.strFaja = (read[5] == null ? string.Empty : read.GetString(5));
                        objInfromacionGeografica.strFoto = (read[6] == null ? string.Empty : read.GetString(6));
                        objInfromacionGeografica.strAnio = (read[7] == null ? string.Empty : read.GetString(7));
                        objInfromacionGeografica.strAmpliacion = (read[8] == null ? string.Empty : read.GetString(8));
                        objInfromacionGeografica.strEscalaAerografica = (read[9] == null ? string.Empty : read.GetString(9));
                        ls.Add(objInfromacionGeografica);
                    }
                }
                else
                {
                    ls = new List<Listas.Consultar_Informacion_Geografica_Result>();
                }
            }
            else
            {
                ls = new List<Listas.Consultar_Informacion_Geografica_Result>();
            }
            this.Desconectar();
            return ls;
        }
        #endregion

        #region CONSULTAR CALIFICACION
        public List<Listas.Consultar_Calificacion_Result> Consultar_Calificacion(int strNufi, string strUnidad)
        {
            List<Listas.Consultar_Calificacion_Result> lst = new List<Listas.Consultar_Calificacion_Result>();
            string sql = " ";
            sql = "";
            sql += " declare @nufi int=" + strNufi + "  \n";
            sql += " declare @unidad int =" + strUnidad + "  \n";
            sql += " select Convert(varchar(50),CO.FPCCCODI) \n";
            sql += " ,Convert(varchar(50),CO.FPCCPUNT) \n";
            sql += " from [dbo].[FIPRCACO] CO \n";
            sql += " where CO.FPCCNUFI=@nufi \n";
            sql += " AND CO.FPCCUNID=@unidad \n";
            SqlDataReader read = this.EjecutarConsulta(sql);
            if (read != null)
            {
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Listas.Consultar_Calificacion_Result objConsulta = new Listas.Consultar_Calificacion_Result();
                        objConsulta.strCodigoCalificacion = (read[0] == null ? string.Empty : read.GetString(0));
                        objConsulta.strPuntos = (read[1] == null ? string.Empty : read.GetString(1));
                        lst.Add(objConsulta);
                    }
                }
                else
                {
                    lst = new List<Listas.Consultar_Calificacion_Result>();
                }
            }
            else
            {
                lst = new List<Listas.Consultar_Calificacion_Result>();
            }
            this.Desconectar();
            return lst;
        }
        #endregion

        #region CONSULTAR DESTINO
        public List<Listas.Consultar_Destino_Economico_Result> Consultar_Destino(int strNufi)
        {
            List<Listas.Consultar_Destino_Economico_Result> lst = new List<Listas.Consultar_Destino_Economico_Result>();
            string sql = " ";
            sql = "";
            sql += " declare @nufi int=" + strNufi + "  \n";
            sql += " select   \n";
            sql += " PD.[FPDENUFI]  \n";
            sql += " ,PD.[FPDEDEEC]  \n";
            sql += " ,PD.[FPDEPORC]  \n";
            sql += " ,D.DEECDESC  \n";
            sql += " FROM [FIPRDEEC] PD  \n";
            sql += " inner join [MANT_DESTECON] D   \n";
            sql += " on PD.[FPDEDEEC]= D.DEECCODI  \n";
            sql += " where PD.FPDENUFI =@nufi  \n";
            SqlDataReader read = this.EjecutarConsulta(sql);
            if (read != null)
            {
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Listas.Consultar_Destino_Economico_Result objConsulta = new Listas.Consultar_Destino_Economico_Result();
                        objConsulta.strNufi = (read[0] == null ? string.Empty : Convert.ToString(read[0]));
                        objConsulta.strDestino = (read[1] == null ? string.Empty : Convert.ToString(read[1]));
                        objConsulta.strPorcentaje = (read[2] == null ? string.Empty : Convert.ToString(read[2]));
                        objConsulta.strDescripcion = (read[3] == null ? string.Empty : Convert.ToString(read[3]));
                        lst.Add(objConsulta);
                    }
                }
                else
                {
                    lst = new List<Listas.Consultar_Destino_Economico_Result>();
                }
            }
            else
            {
                lst = new List<Listas.Consultar_Destino_Economico_Result>();
            }
            this.Desconectar();
            return lst;
        }
        #endregion

        #region CONSULTAR Zonas Fisicas
        public List<Listas.Consultar_ZonasFisicas_Result> Consultar_ZonasFisicas(int strNufi)
        {
            List<Listas.Consultar_ZonasFisicas_Result> lst = new List<Listas.Consultar_ZonasFisicas_Result>();
            string sql = " ";
            sql = "";
            sql += " declare @nufi int=" + strNufi + "  \n";
            sql += " SELECT FZF.FPZFNUFI  \n";
            sql += " ,FZF.FPZFZOFI  \n";
            sql += " ,FZF.FPZFPORC     \n";
            sql += " ,ZF.ZOFIDESC     \n";
            sql += " ,((convert(numeric(20,4),(select P.FIPRARTE   \n";
            sql += " 	from [dbo].[FICHPRED] P  \n";
            sql += " 	where P.FIPRNUFI=@nufi))/10000)   \n";
            sql += " 	*(convert(numeric(20,4),FZF.FPZFPORC)  /100))  \n";
            sql += " FROM FIPRZOFI FZF      \n";
            sql += " inner join MANT_ZONAFISI ZF on FZF.FPZFZOFI=ZF.ZOFICODI      \n";
            sql += " and ZF.ZOFIMUNI=FZF.FPZFMUNI    \n";
            sql += " where FZF.FPZFNUFI=@nufi      \n";
            SqlDataReader read = this.EjecutarConsulta(sql);
            if (read != null)
            {
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Listas.Consultar_ZonasFisicas_Result objConsulta = new Listas.Consultar_ZonasFisicas_Result();
                        objConsulta.strNufi = (read[0] == null ? string.Empty : Convert.ToString(read[0]));
                        objConsulta.strZonaFisica = (read[1] == null ? string.Empty : Convert.ToString(read[1]));
                        objConsulta.strPorcentaje = (read[2] == null ? string.Empty : Convert.ToString(read[2]));
                        objConsulta.strDescripcion = (read[3] == null ? string.Empty : Convert.ToString(read[3]));
                        objConsulta.AreaZona = (read[4] == null ? 0 : Convert.ToDecimal(read[4]));
                        lst.Add(objConsulta);
                    }
                }
                else
                {
                    lst = new List<Listas.Consultar_ZonasFisicas_Result>();
                }
            }
            else
            {
                lst = new List<Listas.Consultar_ZonasFisicas_Result>();
            }
            this.Desconectar();
            return lst;
        }
        #endregion

        #region CONSULTAR Zonas Economicas
        public List<Listas.Consultar_ZonasEconomicas_Result> Consultar_ZonasEconomicas(int strNufi)
        {
            List<Listas.Consultar_ZonasEconomicas_Result> lst = new List<Listas.Consultar_ZonasEconomicas_Result>();
            string sql = " ";
            sql = "";
            sql += " declare @nufi int=" + strNufi + "  \n";
            sql += "  SELECT [FPZENUFI]    \n";
            sql += " ,[FPZEZOEC]      \n";
            sql += " ,[FPZEPORC]      \n";
            sql += " ,MZ.ZOECDESC     \n";
            sql += " ,[ZOECVALO]   \n";
            sql += " ,((convert(numeric(20,4),(select P.FIPRARTE     \n";
            sql += " from [dbo].[FICHPRED] P    \n";
            sql += " where P.FIPRNUFI=@nufi))/10000)     \n";
            sql += " *(convert(numeric(20,4),[FPZEPORC] )  /100)) AreaLote    \n";
            sql += " ,	(((convert(numeric(20,4),(select P.FIPRARTE     \n";
            sql += " 	from [dbo].[FICHPRED] P    \n";
            sql += " 	where P.FIPRNUFI=@nufi))/10000)     \n";
            sql += " 	*(convert(numeric(10,4),[FPZEPORC] )  /100)) * [ZOECVALO] ) ValorZona  \n";
            sql += " FROM [FIPRZOEC] ZE      \n";
            sql += " inner join [MANT_ZONAECON] MZ on ZE.FPZEZOEC=MZ.ZOECCODI     \n";
            sql += " 			and MZ.ZOECMUNI=ZE.FPZEMUNI    \n";
            sql += "  where ZE.FPZENUFI=@nufi      \n";

            SqlDataReader read = this.EjecutarConsulta(sql);
            if (read != null)
            {
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Listas.Consultar_ZonasEconomicas_Result objConsulta = new Listas.Consultar_ZonasEconomicas_Result();
                        objConsulta.strNufi = (read[0] == null ? string.Empty : Convert.ToString(read[0]));
                        objConsulta.strZonaEconomica = (read[1] == null ? string.Empty : Convert.ToString(read[1]));
                        objConsulta.strPorcentaje = (read[2] == null ? string.Empty : Convert.ToString(read[2]));
                        objConsulta.strDescripcion = (read[3] == null ? string.Empty : Convert.ToString(read[3]));
                        objConsulta.ValorZona = (read[4] == null ? 0 : Convert.ToDecimal(read[4]));
                        objConsulta.AreaZona = (read[5] == null ? 0 : Convert.ToDecimal(read[5]));
                        objConsulta.ValorZonaTotal = (read[6] == null ? 0 : Convert.ToDecimal(read[6]));
                        lst.Add(objConsulta);
                    }
                }
                else
                {
                    lst = new List<Listas.Consultar_ZonasEconomicas_Result>();
                }
            }
            else
            {
                lst = new List<Listas.Consultar_ZonasEconomicas_Result>();
            }
            this.Desconectar();
            return lst;
        }
        #endregion

        #region CONSULTAR Zonas Economicas Municipio
        public List<Consultar_ZonasEconomicas_Municipio_Result> Consultar_ZonasEconomicas_Municipio(string strMunicipio)
        {
            List<Consultar_ZonasEconomicas_Municipio_Result> lst = new List<Consultar_ZonasEconomicas_Municipio_Result>();
            string sql = " ";
            sql = "";
            sql += " select MZE.ZOECCODI \n";
            sql += " ,MZE.ZOECMUNI \n";
            sql += " ,MZE.ZOECDESC \n";
            sql += " ,MZE.ZOECVALO \n";
            sql += " from   [dbo].[MANT_ZONAECON] MZE  \n";
            sql += " where MZE.ZOECMUNI=" + strMunicipio + " \n";
            sql += " group by MZE.ZOECCODI,MZE.ZOECMUNI,MZE.ZOECDESC,MZE.ZOECVALO \n";
            sql += " order by MZE.ZOECCODI \n";
            SqlDataReader read = this.EjecutarConsulta(sql);
            if (read != null)
            {
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Consultar_ZonasEconomicas_Municipio_Result objConsulta = new Consultar_ZonasEconomicas_Municipio_Result();
                        objConsulta.strCodigoZona = (read[0] == null ? string.Empty : Convert.ToString(read[0]));
                        objConsulta.strCodigoMunicipio = (read[1] == null ? string.Empty : Convert.ToString(read[1]));
                        objConsulta.strDescripcion = (read[2] == null ? string.Empty : Convert.ToString(read[2]));
                        objConsulta.strValorZona = (read[3] == null ? string.Empty : Convert.ToString(read[3]));
                        lst.Add(objConsulta);
                    }
                }
                else
                {
                    lst = new List<Consultar_ZonasEconomicas_Municipio_Result>();
                }
            }
            else
            {
                lst = new List<Consultar_ZonasEconomicas_Municipio_Result>();
            }
            this.Desconectar();
            return lst;
        }

        #endregion

        #region Consultar Predios ExportarCultivos
        public List<Consultar_Predio_Reporte_Excel> Consultar_Predios_Reporte_Excel(string strFichasPrediales)
        {
            List<Consultar_Predio_Reporte_Excel> lst = new List<Consultar_Predio_Reporte_Excel>();


            string sql = "";

            sql += " select P.FIPRNUFI \n";
            sql += " ,PR.FPPRTIDO \n";
            sql += " ,PR.FPPRNUDO \n";
            sql += " ,PR.FPPRPRAP \n";
            sql += " ,PR.FPPRSEAP \n";
            sql += " ,PR.FPPRNOMB \n";
            sql += " ,PR.FPPRDERE \n";
            sql += " ,PR.FPPRESCR \n";
            sql += " ,(PR.FPPRDENO+PR.FPPRMUNO+PR.FPPRNOTA) Notaria \n";
            sql += " ,PR.FPPRFEES \n";
            sql += " ,PR.FPPRFERE \n";
            sql += " ,PR.FPPRTOMO \n";
            sql += " ,PR.FPPRMAIN \n";
            sql += " ,P.FIPRARTE \n";
            sql += " ,P.FIPRMUNI \n";
            sql += " ,P.FIPRCLSE \n";
            sql += " ,P.FIPRCORR \n";
            sql += " ,P.FIPRBARR \n";
            sql += " ,P.FIPRMANZ \n";
            sql += " ,P.FIPRPRED \n";
            sql += " ,P.FIPRDIRE \n";
            sql += " ,(select top 1 MBV.BAVEDESC  \n";
            sql += " from [dbo].[MANT_BARRVERE] MBV  \n";
            sql += " where MBV.BAVEDEPA=P.FIPRDEPA  \n";
            sql += " and MBV.BAVEMUNI=P.FIPRMUNI  \n";
            sql += " and MBV.BAVECORR=P.FIPRCORR  \n";
            sql += " and MBV.BAVECODI=(case P.[FIPRBARR]  \n";
            sql += " when '000' then P.FIPRMANZ  \n";
            sql += " ElSE P.FIPRBARR  \n";
            sql += " end)) Vereda  \n";

            sql += " from [dbo].[FIPRPROP] PR  \n";
            sql += " inner join [dbo].[FICHPRED] P on P.FIPRNUFI=PR.FPPRNUFI  \n";

            sql += "where  P.[FIPRESTA]='ac' \n";
            sql += strFichasPrediales != string.Empty ? "and P.FIPRNUFI in (" + strFichasPrediales + ")  \n" : string.Empty;

            SqlDataReader read = this.EjecutarConsulta(sql);
            if (read != null)
            {
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Consultar_Predio_Reporte_Excel objConsulta = new Consultar_Predio_Reporte_Excel();
                        objConsulta.strNufi = (read[0] == null ? string.Empty : Convert.ToString(read[0]));
                        objConsulta.strTipoDocumento = (read[1] == null ? string.Empty : Convert.ToString(read[1]));
                        objConsulta.strNumeroDocumuento = (read[2] == null ? string.Empty : Convert.ToString(read[2]));
                        objConsulta.strPrimerApellido = (read[3] == null ? string.Empty : Convert.ToString(read[3]));
                        objConsulta.strSegundoApellido = (read[4] == null ? string.Empty : Convert.ToString(read[4]));
                        objConsulta.strNombre = (read[5] == null ? string.Empty : Convert.ToString(read[5]));
                        objConsulta.strDerecho = (read[6] == null ? string.Empty : Convert.ToString(read[6]));
                        objConsulta.strEscritura = (read[7] == null ? string.Empty : Convert.ToString(read[7]));
                        objConsulta.strNotaria = (read[8] == null ? string.Empty : Convert.ToString(read[8]));
                        objConsulta.strFechaEscritura = (read[9] == null ? string.Empty : Convert.ToString(read[9]));
                        objConsulta.strFechaRegistro = (read[10] == null ? string.Empty : Convert.ToString(read[10]));
                        objConsulta.strTomo = (read[11] == null ? string.Empty : Convert.ToString(read[11]));
                        objConsulta.strMaricula = (read[12] == null ? string.Empty : Convert.ToString(read[12]));
                        objConsulta.strAreaTerreno = (read[13] == null ? string.Empty : Convert.ToString(read[13]));
                        objConsulta.strMunicipio = (read[14] == null ? string.Empty : Convert.ToString(read[14]));
                        objConsulta.strClase = (read[15] == null ? string.Empty : Convert.ToString(read[15]));
                        objConsulta.strCorregimiento = (read[16] == null ? string.Empty : Convert.ToString(read[16]));
                        objConsulta.strBarrio = (read[17] == null ? string.Empty : Convert.ToString(read[17]));
                        objConsulta.strManzana = (read[18] == null ? string.Empty : Convert.ToString(read[18]));
                        objConsulta.strPredio = (read[19] == null ? string.Empty : Convert.ToString(read[19]));
                        objConsulta.strDirreccion = (read[20] == null ? string.Empty : Convert.ToString(read[20]));
                        objConsulta.strVereda = (read[21] == null ? string.Empty : Convert.ToString(read[21]));
                        lst.Add(objConsulta);
                    }
                }
                else
                {
                    lst = new List<Consultar_Predio_Reporte_Excel>();
                }
            }
            else
            {
                lst = new List<Consultar_Predio_Reporte_Excel>();
            }
            this.Desconectar();
            return lst;
        }

        #endregion
    }

}
