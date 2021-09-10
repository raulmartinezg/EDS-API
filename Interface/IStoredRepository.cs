using EDS_API.Entities;
using EDS_API.Pagination;
using EDS_API.Parameters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_API.Interface
{
    public interface IStoredRepository
    {
        CalidadObject DWH_SPQRY_EncuestaSatisServ(string fecha_inicial, string fecha_final);
        List<RastreoDeEmbarque> DWH_SPQRY_RastreabilidadViajes(RastreoEmbarqueParameters rastreoEmbarqueParameters);
        TiempoObject DWH_SPORY_TiemposViajeEvaluacion(int cf);
        ViajeObject dbo_SPORY_TiemposViajeEvaluacion(DetalleParameters detalleParameters);
        List<RptEntregas> DWH_SPORY_RptEntregas(DateTime fecha);
        List<ReporteTipoEncuesta> DWH_SPORY_ReporteTipoEncuesta(DateTime fecha);
        List<DiarioDeViajes> DWH_SPORY_DiarioDeViaje(DateTime fecha);
        List<MensualDeViajes> DWH_SPORY_MensualDeViajes(DateTime fecha_inicial, DateTime fecha_final);
        MensualCVRObject DWH_SPORY_MensualCVR(DateTime fecha_inicial, DateTime fecha_final);
        NivelServicioObject DWH_SPORY_NivelServicio(string fecha, int clave);
        List<EficienciaEntregas> DWH_SPORY_EficienciaEntregas(DateTime fecha_inicial, DateTime fecha_final);
    }
}
