using EDS_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_API.Interface
{
    public interface IRepository
    {
        IEnumerable<FolioViajeGeneral> GetFolios();
        IEnumerable<ConcesionarioRutum> GetConcesionario(int clave);
        Task<bool> InsertJson(TbhisContenidoViajeSae obj);
    }
}
