using EDS_API.Entities;
using EDS_API.Interface;
using EDS_API.Parameters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EDS_API.Repositories
{
    public class StoredRepository : IStoredRepository
    {
        #region Query's
        private const string Connection = "Server=MexDis2k3\\EXDSCharge;uid=SID_Rastreo;pwd=9J+MkSAy7L1O70bW+wQA;Initial Catalog=SIDTUM_PROD";
        public List<RastreoDeEmbarque> DWH_SPQRY_RastreabilidadViajes(RastreoEmbarqueParameters rastreoEmbarqueParameters)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection);
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand comando = new SqlCommand("DWH.SPQRY_RastreabilidadViajes_new", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@OrdenEmbarque", rastreoEmbarqueParameters.OrdenEmbarque);
                comando.Parameters.AddWithValue("@NumeroPlacas", rastreoEmbarqueParameters.NumeroPlacas);
                comando.Parameters.AddWithValue("@FolioViaje", rastreoEmbarqueParameters.FolioViaje);
                comando.Parameters.AddWithValue("@NumeroUnidad", rastreoEmbarqueParameters.NumeroUnidad);
                comando.Parameters.AddWithValue("@NoCon", rastreoEmbarqueParameters.NoCon);
                comando.Parameters.AddWithValue("@NumeroOperador", rastreoEmbarqueParameters.NumeroOperador);
                comando.Parameters.AddWithValue("@FechaInicial", rastreoEmbarqueParameters.FechaInicial);
                comando.Parameters.AddWithValue("@FechaFinal", rastreoEmbarqueParameters.FechaFinal);
                da = new SqlDataAdapter(comando);
                da.Fill(ds);
                var dat = ds.Tables[0];
                List<RastreoDeEmbarque> rastreoList = new List<RastreoDeEmbarque>();
                rastreoList = (from DataRow dr in dat.Rows
                               select new RastreoDeEmbarque()
                               {
                                   ClaveFolioViaje = GetInt(dr, "ClaveFolioViaje"),
                                   Placas = GetString(dr, "Placas"),
                                   FolioViaje = GetString(dr, "FolioViaje"),
                                   Ruta = GetString(dr, "Ruta"),
                                   Unidad = GetInt(dr, "Unidad"),
                                   Operador = GetString(dr, "Operador"),
                                   Destino = GetString(dr, "Destino"),
                                   NoParadas = GetInt(dr, "NoParadas"),
                                   Bultos = GetInt(dr, "Bultos"),
                                   FFinCargar = GetDatetime(dr, "FFinCarga"),
                                   InicioViaje = GetDatetime(dr, "InicioViaje"),
                                   LlegadaProgramada = GetDatetime(dr, "LlegadaProgramada"),
                                   EstatusFolio = GetInt(dr, "EstatusFolio"),
                                   Latitud = GetDouble(dr, "Latitud"),
                                   Longitud = GetDouble(dr, "Longitud"),
                                   FechaPosicion = GetDatetime(dr, "FechaPosicion"),
                                   Porciento = GetInt(dr, "Porciento"),
                                   Pictograma = GetInt(dr, "Pictograma"),
                                   Porciento2 = GetDouble(dr, "Porciento2"),
                                   PrimerParada = GetDatetime(dr, "PrimeraParada"),
                                   UltimaParada = GetDatetime(dr, "UltimaParada"),
                                   CvEncuesta = GetInt(dr, "CvEncuesta")

                               }).ToList();

                return rastreoList;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public TiempoObject DWH_SPORY_TiemposViajeEvaluacion(int cf)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection);
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand comando = new SqlCommand("DWH.SPQRY_TiemposViajeEvaluacion", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@ClaveCliente", 3);
                comando.Parameters.AddWithValue("@ClaveFolioViaje", cf);
                da = new SqlDataAdapter(comando);
                da.Fill(ds);
                var dat = ds.Tables[0];
                var dat1 = ds.Tables[1];

                List<TiempoViajeEvaluacion> itemList = new List<TiempoViajeEvaluacion>();
                itemList = (from DataRow dr in dat1.Rows
                            select new TiempoViajeEvaluacion()
                            {
                                Secuencia = GetInt(dr, "Secuencia"),
                                NumeroConcesionario = GetInt(dr, "NumeroConcesionario"),
                                Concesionario = GetString(dr, "Concesionario"),
                                Ciudad = GetString(dr, "Ciudad"),
                                TotalOrdenEmbarque = GetInt(dr, "TotalOrdenEmbarque"),
                                TotalGarantiaDevolucion = GetInt(dr, "TotalGarantiaDevolucion"),
                                LlegadaEstimada = GetDatetime(dr, "LlegadaEstimada"),
                                LlegadaReal = GetDatetime(dr, "LlegadaReal"),
                                EvalLlegada = GetString(dr, "EvalLlegada"),
                                SalidaEstimada = GetDatetime(dr, "SalidaEstimada"),
                                SalidaReal = GetDatetime(dr, "SalidaReal"),
                                EstanciaConc = GetString(dr, "EstanciaConc"),
                                PersonaRecibe = GetString(dr, "PersonaRecibe"),
                                ClaveFolioViaje = GetInt(dr, "ClaveFolioViaje"),
                                Latitud = GetDouble(dr, "Latitud"),
                                Longitud = GetDouble(dr, "Longitud"),
                                Entregado = GetInt(dr, "Entregado")


                            }).ToList();

                List<RastreoEmbarqueSecond> itemList2 = new List<RastreoEmbarqueSecond>();
                itemList2 = (from DataRow dr in dat.Rows
                             select new RastreoEmbarqueSecond()
                             {
                                 ClaveFolioViaje = GetInt(dr, "ClaveFolioViaje"),
                                 FInicioCarga = GetDatetime(dr, "FInicioCarga"),
                                 FFinCarga = GetDatetime(dr, "FFinCarga"),
                                 FSalidaProgramada = GetDatetime(dr, "FSalidaProgramada"),
                                 FSalidaReal = GetDatetime(dr, "FSalidaReal"),
                                 Items = GetInt(dr, "Items"),
                                 TiempoMinutosViaje = GetDouble(dr, "TiempoMinutosViaje"),
                                 FFinServicio = GetDatetime(dr, "FFinServicio"),
                                 TiempoViaje = GetString(dr, "TiempoViaje"),
                                 TiempoRutaReal = GetString(dr, "TiempoRutaReal")

                             }).ToList();

                var Master = new TiempoObject();
                Master.Table0 = itemList;
                Master.Table1 = itemList2;

                return Master;
            }
            catch (Exception)
            {

                throw;
            }
            

        }
       
        public ViajeObject dbo_SPORY_TiemposViajeEvaluacion(DetalleParameters detalleParameters)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection);
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand comando = new SqlCommand("dbo.SPQRY_WEBViajesDetalleOE", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@ClaveFolioViaje", detalleParameters.ClaveFolioViaje);
                comando.Parameters.AddWithValue("@NumeroConcesionario", detalleParameters.NumeroConcesionario);
                da = new SqlDataAdapter(comando);
                da.Fill(ds);
                var dat = ds.Tables[1];
                var dat1 = ds.Tables[0];

                List<ViajeDetalle> itemList = new List<ViajeDetalle>();
                itemList = (from DataRow dr in dat1.Rows
                            select new ViajeDetalle()
                            {
                                OrdenEmbarque = GetString(dr, "OrdenEmbarque"),
                                Descripcion = GetString(dr, "Descripcion"),
                                SKU = GetString(dr, "SKU"),
                                Cantidad = GetInt(dr, "Cantidad"),
                                FechaProcesada = GetDatetime(dr, "FechaProcesada")


                            }).ToList();

                List<ViajeDetalleSecond> itemList2 = new List<ViajeDetalleSecond>();
                itemList2 = (from DataRow dr in dat.Rows
                             select new ViajeDetalleSecond()
                             {
                                 Guias = GetInt(dr, "guias"),
                                 Items = GetInt(dr, "Itmes"),
                                 Piezas = GetInt(dr, "Piezas"),
                                 Entregado = GetInt(dr, "Entregado"),
                                 NoCapturado = GetInt(dr, "NoCapturado"),
                                 Danno = GetInt(dr, "Danno"),
                                 FechaInicial = GetDatetime(dr, "FecIni"),
                                 FechaFinal = GetDatetime(dr, "FecFin"),
                                 Tiempo = GetString(dr, "tiempo")
                             }).ToList();

                var Master = new ViajeObject();
                Master.Tablet0 = itemList;
                Master.Table1 = itemList2;
                return Master;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<RptEntregas> DWH_SPORY_RptEntregas(DateTime fecha)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection);
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand comando = new SqlCommand("DWH.SPQRY_RptEntregas", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@mydate", fecha);
                da = new SqlDataAdapter(comando);
                da.Fill(ds);
                var dat1 = ds.Tables[0];
                int i = 0;
                List<RptEntregas> itemList = new List<RptEntregas>();
                itemList = (from DataRow dr in dat1.Rows
                            select new RptEntregas()
                            {
                                Id = GetString(dr, "FolioViaje") + GetString(dr, "NumeroConcesionario"),
                                ClaveFolioViaje = GetInt(dr, "ClaveFolioViaje"),
                                FolioViaje = GetString(dr, "FolioViaje"),
                                FechaEmbarque = GetDatetime(dr, "FechaEmbarque"),
                                InicioViaje = GetDatetime(dr, "InicioViaje"),
                                Unidad = GetInt(dr, "Unidad"),
                                Operador = GetString(dr, "Operador"),
                                Operador2 = GetString(dr, "Operador2"),
                                Ayudante1 = GetString(dr, "Ayudante1"),
                                Ayudante2 = GetString(dr, "Ayudante2"),
                                Ruta = GetString(dr, "Ruta"),
                                NumeroConcesionario = GetString(dr, "NumeroConcesionario"),
                                NombreConcesionario = GetString(dr, "NombreConcesionario"),
                                LlegadaEstimada = GetDatetime(dr, "LlegadaEstimada"),
                                LlegadaReal = GetDatetime(dr, "LlegadaReal"),
                                SalidaEstimada = GetDatetime(dr, "SalidaEstimada"),
                                SalidaReal = GetDatetime(dr, "SalidaReal"),
                                Estatus = GetString(dr, "Estatus"),


                            }).ToList();
                return itemList;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<ReporteTipoEncuesta> DWH_SPORY_ReporteTipoEncuesta(DateTime fecha)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection);
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand comando = new SqlCommand("DWH.SPQRY_ReporteTipoEncuesta", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@anio", fecha);
                da = new SqlDataAdapter(comando);
                da.Fill(ds);
                var dat1 = ds.Tables[0];

                List<ReporteTipoEncuesta> itemList = new List<ReporteTipoEncuesta>();
                itemList = (from DataRow dr in dat1.Rows
                            select new ReporteTipoEncuesta()
                            {
                                Id = GetString(dr, "FolioViaje") + GetString(dr, "NumeroConcesionario"),
                                FolioViaje = GetString(dr, "FolioViaje"),
                                Unidad = GetInt(dr, "Unidad"),
                                Operador = GetString(dr, "Operador"),
                                SalidaProgramada = GetDatetime(dr, "SalidaProgramada"),
                                NumeroConcesionario = GetString(dr, "NumeroConcesionario"),
                                RazonSocial = GetString(dr, "RazonSocial"),
                                FechaEncuesta = GetDatetime(dr, "FechaEncuesta"),
                                TipoEncuesta = GetString(dr, "TipoEncuesta"),
                            }).ToList();
                return itemList;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<DiarioDeViajes> DWH_SPORY_DiarioDeViaje(DateTime fecha)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection);
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand comando = new SqlCommand("DWH.SPQRY_DiarioDeViajes", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Fecha", fecha);
                da = new SqlDataAdapter(comando);
                da.Fill(ds);
                var dat1 = ds.Tables[0];


                List<DiarioDeViajes> itemList = new List<DiarioDeViajes>();
                itemList = (from DataRow dr in dat1.Rows
                            select new DiarioDeViajes()
                            {
                                Id = GetInt(dr, "ClaveFolioViaje"),
                                Fecha = GetDatetime(dr, "Fecha"),
                                RutaClasificada = GetString(dr, "RutaClasificada"),
                                FolioViaje = GetString(dr, "FolioViaje"),
                                Unidad = GetInt(dr, "Unidad"),
                                TipoUnidad = GetString(dr, "TipoUnidad"),
                                Nombre = GetString(dr, "Nombre"),
                                Concesionarios = GetInt(dr, "Concesionarios"),
                                Embarques = GetInt(dr, "Embarques"),
                                Items = GetInt(dr, "Items"),
                                PorcentajeCarga = GetInt(dr, "PorcentajeCarga"),
                                UltimaCiudad = GetString(dr, "UltimaCiudad"),
                                NumeroConcesionario = GetString(dr, "NumeroConcesionario"),
                                Rebotes = GetInt(dr, "Rebotes"),
                                DiasTransito = GetString(dr, "DiasTransito"),
                                Dealer = GetString(dr, "Dealer")
                            }).ToList();

                return itemList;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public CalidadObject DWH_SPQRY_EncuestaSatisServ(string fecha_inicial, string fecha_final)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection);
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand comando = new SqlCommand("DWH.SPQRY_EncuestaSatisServ", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@FechaInicial", fecha_inicial);
                comando.Parameters.AddWithValue("@FechaFinal", fecha_final);
                da = new SqlDataAdapter(comando);
                da.Fill(ds);
                var dat1 = ds.Tables[0];
                var dat2 = ds.Tables[1];


                List<Calidad> itemList = new List<Calidad>();
                itemList = (from DataRow dr in dat1.Rows
                            select new Calidad()
                            {
                                Id = GetInt(dr, "ClavePregunta"),
                                Pregunta = GetString(dr, "Pregunta"),
                                Excelente = GetInt(dr, "Excelente"),
                                Bueno = GetInt(dr, "Bueno"),
                                Regular = GetInt(dr, "Regular"),
                                Deficiente = GetInt(dr, "Deficiente"),
                            }).ToList();

                List<CalidadSecond> itemList2 = new List<CalidadSecond>();
                itemList2 = (from DataRow dr in dat2.Rows
                             select new CalidadSecond()
                             {
                                 Id = GetInt(dr, "ClavePregunta"),
                                 Pregunta = GetString(dr, "Pregunta"),
                                 Si = GetInt(dr, "SI"),
                                 No = GetInt(dr, "NO")
                             }).ToList();

                var Master = new CalidadObject();
                Master.Table0 = itemList;
                Master.Table1 = itemList2;
                return Master;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<MensualDeViajes> DWH_SPORY_MensualDeViajes(DateTime fecha_inicial,DateTime fecha_final)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection);
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand comando = new SqlCommand("DWH.SPQRY_MensualDeViajes", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@FechaInicial", fecha_inicial);
                comando.Parameters.AddWithValue("@FechaFinal", fecha_final);
                da = new SqlDataAdapter(comando);
                da.Fill(ds);
                var dat1 = ds.Tables[0];

                List<MensualDeViajes> itemList = new List<MensualDeViajes>();
                itemList = (from DataRow dr in dat1.Rows
                            select new MensualDeViajes()
                            {
                                Anio = GetInt(dr, "Anio"),
                                Id = GetInt(dr, "ClaveClasificacionRuta"),
                                RutaClasificada = GetString(dr, "RutaClasificada"),
                                ViajesEne = GetInt(dr, "ViajesEne"),
                                RebotesEne = GetInt(dr, "RebotesEne"),
                                PorcentajeCargaEne = GetInt(dr, "PorcentajeCargaEne"),
                                ViajesFeb = GetInt(dr, "ViajesFeb"),
                                RebotesFeb = GetInt(dr, "RebotesFeb"),
                                PorcentajeCargaFeb = GetInt(dr, "PorcentajeCargaFeb"),
                                ViajesMar = GetInt(dr, "ViajesMar"),
                                RebotesMar = GetInt(dr, "RebotesMar"),
                                PorcentajeCargaMar = GetInt(dr, "PorcentajeCargaMar"),
                                ViajesAbr = GetInt(dr, "ViajesAbr"),
                                RebotesAbr = GetInt(dr, "RebotesAbr"),
                                PorcentajeCargaAbr = GetInt(dr, "PorcentajeCargaAbr"),
                                ViajesMay = GetInt(dr, "ViajesMay"),
                                RebotesMay = GetInt(dr, "RebotesMay"),
                                PorcentajeCargaMay = GetInt(dr, "PorcentajeCargaMay"),
                                ViajesJun = GetInt(dr, "ViajesJun"),
                                RebotesJun = GetInt(dr, "RebotesJun"),
                                PorcentajeCargaJun = GetInt(dr, "PorcentajeCargaJun"),
                                ViajesJul = GetInt(dr, "ViajesJul"),
                                RebotesJul = GetInt(dr, "RebotesJul"),
                                PorcentajeCargaJul = GetInt(dr, "PorcentajeCargaJul"),
                                ViajesAgo = GetInt(dr, "ViajesAgo"),
                                RebotesAgo = GetInt(dr, "RebotesAgo"),
                                PorcentajeCargaAgo = GetInt(dr, "PorcentajeCargaAgo"),
                                ViajesSep = GetInt(dr, "ViajesSep"),
                                RebotesSep = GetInt(dr, "RebotesSep"),
                                PorcentajeCargaSep = GetInt(dr, "PorcentajeCargaSep"),
                                ViajesOct = GetInt(dr, "ViajesOct"),
                                RebotesOct = GetInt(dr, "RebotesOct"),
                                PorcentajeCargaOct = GetInt(dr, "PorcentajeCargaOct"),
                                ViajesNov = GetInt(dr, "ViajesNov"),
                                RebotesNov = GetInt(dr, "RebotesNov"),
                                PorcentajeCargaNov = GetInt(dr, "PorcentajeCargaNov"),
                                ViajesDic = GetInt(dr, "ViajesEne"),
                                RebotesDic = GetInt(dr, "RebotesEne"),
                                PorcentajeCargaDic = GetInt(dr, "PorcentajeCargaEne"),
                            }).ToList();

                return itemList;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public MensualCVRObject DWH_SPORY_MensualCVR(DateTime fecha_inicial, DateTime fecha_final)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection);
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand comando = new SqlCommand("DWH.SPQRY_MensualCVR", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@FechaInicial", fecha_inicial);
                comando.Parameters.AddWithValue("@FechaFinal", fecha_final);
                da = new SqlDataAdapter(comando);
                da.Fill(ds);
                var dat1 = ds.Tables[0];
                var dat2 = ds.Tables[1];
                var dat3 = ds.Tables[2];

                List<MensualCVR> itemList = new List<MensualCVR>();
                itemList = (from DataRow dr in dat1.Rows
                            select new MensualCVR()
                            {
                                Anio = GetInt(dr, "Anio"),
                                Id = GetString(dr, "RutaClasificada"),
                                Ene = GetInt(dr, "Ene"),
                                Feb = GetInt(dr, "Feb"),
                                Mar = GetInt(dr, "Mar"),
                                Abr = GetInt(dr, "Abr"),
                                May = GetInt(dr, "May"),
                                Jun = GetInt(dr, "Jun"),
                                Jul = GetInt(dr, "Jul"),
                                Ago = GetInt(dr, "Ago"),
                                Sep = GetInt(dr, "Sep"),
                                Oct = GetInt(dr, "Oct"),
                                Nov = GetInt(dr, "Nov"),
                                Dic = GetInt(dr, "Dic"),
                            }).ToList();

                List<MensualCVRSecond> itemList2 = new List<MensualCVRSecond>();
                itemList2 = (from DataRow dr in dat2.Rows
                             select new MensualCVRSecond()
                             {
                                 Anio = GetInt(dr, "Anio"),
                                 Id = GetString(dr, "RutaClasificada"),
                                 Ene = GetInt(dr, "Ene"),
                                 Feb = GetInt(dr, "Feb"),
                                 Mar = GetInt(dr, "Mar"),
                                 Abr = GetInt(dr, "Abr"),
                                 May = GetInt(dr, "May"),
                                 Jun = GetInt(dr, "Jun"),
                                 Jul = GetInt(dr, "Jul"),
                                 Ago = GetInt(dr, "Ago"),
                                 Sep = GetInt(dr, "Sep"),
                                 Oct = GetInt(dr, "Oct"),
                                 Nov = GetInt(dr, "Nov"),
                                 Dic = GetInt(dr, "Dic"),
                             }).ToList();

                List<MensualCVRThird> itemList3 = new List<MensualCVRThird>();
                itemList3 = (from DataRow dr in dat3.Rows
                             select new MensualCVRThird()
                             {
                                 Anio = GetInt(dr, "Anio"),
                                 Id = GetString(dr, "RutaClasificada"),
                                 Ene = GetInt(dr, "Ene"),
                                 Feb = GetInt(dr, "Feb"),
                                 Mar = GetInt(dr, "Mar"),
                                 Abr = GetInt(dr, "Abr"),
                                 May = GetInt(dr, "May"),
                                 Jun = GetInt(dr, "Jun"),
                                 Jul = GetInt(dr, "Jul"),
                                 Ago = GetInt(dr, "Ago"),
                                 Sep = GetInt(dr, "Sep"),
                                 Oct = GetInt(dr, "Oct"),
                                 Nov = GetInt(dr, "Nov"),
                                 Dic = GetInt(dr, "Dic"),
                             }).ToList();
                var Master = new MensualCVRObject();
                Master.Table0 = itemList;
                Master.Table1 = itemList2;
                Master.Table2 = itemList3;
                return Master;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<EficienciaEntregas> DWH_SPORY_EficienciaEntregas(DateTime fecha_inicial, DateTime fecha_final)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection);
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand comando = new SqlCommand("DWH.SPQRY_EficienciaEntregas", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@FechaInicial", fecha_inicial);
                comando.Parameters.AddWithValue("@FechaFinal", fecha_final);
                da = new SqlDataAdapter(comando);
                da.Fill(ds);
                var dat1 = ds.Tables[0];

                List<EficienciaEntregas> itemList = new List<EficienciaEntregas>();
                itemList = (from DataRow dr in dat1.Rows
                            select new EficienciaEntregas()
                            {
                                Anio = GetInt(dr, "Anio"),
                                Id = GetInt(dr, "ClaveClasificacionRuta"),
                                RutaClasificada = GetString(dr, "RutaClasificada"),
                                EneEnt = GetInt(dr, "EneEnt"),
                                EneEf = GetDouble(dr, "EneEf"),
                                FebEnt = GetInt(dr, "FebEnt"),
                                FebEf = GetDouble(dr, "FebEf"),
                                MarEnt = GetInt(dr, "MarEnt"),
                                MarEf = GetDouble(dr, "MarEf"),
                                AbrEnt = GetInt(dr, "AbrEnt"),
                                AbrEf = GetDouble(dr, "AbrEf"),
                                MayEnt = GetInt(dr, "MayEnt"),
                                MayEf = GetDouble(dr, "MayEf"),
                                JunEnt = GetInt(dr, "JunEnt"),
                                JunEf = GetDouble(dr, "JunEf"),
                                JulEnt = GetInt(dr, "JulEnt"),
                                JulEf = GetDouble(dr, "JulEf"),
                                AgoEnt = GetInt(dr, "AgoEnt"),
                                AgoEf = GetDouble(dr, "AgoEf"),
                                SepEnt = GetInt(dr, "SepEnt"),
                                SepEf = GetDouble(dr, "SepEf"),
                                OctEnt = GetInt(dr, "OctEnt"),
                                OctEf = GetDouble(dr, "OctEf"),
                                NovEnt = GetInt(dr, "NovEnt"),
                                NovEf = GetDouble(dr, "NovEf"),
                                DicEnt = GetInt(dr, "DicEnt"),
                                DicEf = GetDouble(dr, "DicEf"),

                            }).ToList();

                return itemList;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public NivelServicioObject DWH_SPORY_NivelServicio(string fecha, int clave)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Connection);
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand comando = new SqlCommand("DWH.SPQRY_NivelServicio1", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Fecha", fecha);
                comando.Parameters.AddWithValue("@ClaveRuta", clave);
                da = new SqlDataAdapter(comando);
                da.Fill(ds);
                var dat1 = ds.Tables[0];
                var dat2 = ds.Tables[1];
                var dat3 = ds.Tables[3];
                var dat4 = ds.Tables[4];

                List<NivelServicio> itemList = new List<NivelServicio>();
                itemList = (from DataRow dr in dat1.Rows
                            select new NivelServicio()
                            {
                                ClaveNivelRutaMes = GetInt(dr, "ClaveNivelRutaMes"),
                                Anio = GetInt(dr, "Anio"),
                                Mes = GetInt(dr, "Mes"),
                                Prefijo = GetString(dr, "Prefijo"),
                                Ruta = GetString(dr, "Ruta"),
                                Total = GetInt(dr, "Total"),
                                Atiempo = GetInt(dr, "Atiempo"),
                                Tarde = GetInt(dr, "Tarde"),
                                SinDatos = GetInt(dr, "SinDatos"),
                                PorcAtiempo = GetInt(dr, "PorcATiempo"),
                                Target = GetInt(dr, "Target")
                            }).ToList();

                List<NivelServicioSecond> itemList2 = new List<NivelServicioSecond>();
                itemList2 = (from DataRow dr in dat2.Rows
                             select new NivelServicioSecond()
                             {
                                 ClaveNivelSerDiario = GetInt(dr, "ClaveNivelSerDiario"),
                                 Anio = GetInt(dr, "Anio"),
                                 Mes = GetInt(dr, "Mes"),
                                 Dia = GetInt(dr, "Dia"),
                                 Total = GetInt(dr, "Total"),
                                 Atiempo = GetInt(dr, "Atiempo"),
                                 Tarde = GetInt(dr, "Tarde"),
                                 SinDatos = GetInt(dr, "SinDatos"),
                                 PorcAtiempo = GetInt(dr, "PorcATiempo"),
                                 Target = GetInt(dr, "Target")
                             }).ToList();

                List<NivelServicioThird> itemList3 = new List<NivelServicioThird>();
                itemList3 = (from DataRow dr in dat3.Rows
                             select new NivelServicioThird()
                             {
                                 ClaveNivelSerMensual = GetInt(dr, "ClaveNivelSerMensual"),
                                 Anio = GetInt(dr, "Anio"),
                                 Mes = GetInt(dr, "Mes"),
                                 MesL = GetString(dr, "MesL"),
                                 Total = GetInt(dr, "Total"),
                                 Atiempo = GetInt(dr, "Atiempo"),
                                 Tarde = GetInt(dr, "Tarde"),
                                 Sindatos = GetInt(dr, "SinDatos"),
                                 PorcAtiempo = GetInt(dr, "PorcATiempo"),
                                 Target = GetInt(dr, "Target")
                             }).ToList();

                List<NivelServicioFour> itemList4 = new List<NivelServicioFour>();
                itemList4 = (from DataRow dr in dat4.Rows
                             select new NivelServicioFour()
                             {
                                 Clave = GetInt(dr, "Clave"),
                                 Ruta = GetString(dr, "Ruta")
                             }).ToList();

                var Master = new NivelServicioObject();
                Master.Table0 = itemList;
                Master.Table1 = itemList2;
                Master.Table2 = itemList3;
                Master.Table3 = itemList4;

                return Master;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        #endregion

        #region Gets
        private double GetDouble(DataRow data, string param)
        {
            if (data[$"{param}"] == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(data[$"{param}"]);
            }
        }

        private int GetInt(DataRow data, string param)
        {
            if (data[$"{param}"] == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(data[$"{param}"]);
            }
        }

        private DateTime GetDatetime(DataRow data, string param)
        {
            if (data[$"{param}"] == DBNull.Value)
            {
                return DateTime.Now;
            }
            else
            {
                return Convert.ToDateTime(data[$"{param}"]);
            }
        }

        private string GetString(DataRow data, string param)
        {
            if (data[$"{param}"] == DBNull.Value)
            {
                return "Empty";
            }
            else
            {
                return Convert.ToString(data[$"{param}"]);
            }
        }

        #endregion


    }
}
