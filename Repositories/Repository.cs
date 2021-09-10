using EDS_API.Data;
using EDS_API.Entities;
using EDS_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_API.Repositories
{
    public class Repository : IRepository
    {
        private readonly SIDTUM_PRODContext _context;

        public Repository(SIDTUM_PRODContext context)
        {
            _context = context;
        }

        public IEnumerable<FolioViajeGeneral> GetFolios()
        {
            try
            {
                var data = _context.FolioViajeGenerals.AsEnumerable();
                return data;
            }
            catch (Exception)
            {

                throw new Exception("Error de comunicación");
            }
        }

        public IEnumerable<ConcesionarioRutum> GetConcesionario(int clave)
        {
            try
            {
                var data = _context.ConcesionarioRuta.Where(x => x.c == clave).ToList();
                if (data != null)
                {
                    return data;
                }
                else
                {
                    throw new Exception("No existe");
                }
               
            }
            catch (Exception)
            {

                throw new Exception("Error de comunicación");
            }
        }

        public async Task<bool> InsertJson(TbhisContenidoViajeSae obj)
        {
            try
            {
                await _context.TbhisContenidoViajeSaes.AddAsync(obj);
                var response =  _context.SaveChanges();
                return response > 0;
            }
            catch (Exception e)
            {

                throw new Exception("Error de comunicación" + e);
            }
        }
    }
}
