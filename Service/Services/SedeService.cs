using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfaces;
using DataAccessLayer;
using System.Data.Entity;


namespace Service.Services
{
    public class SedeService : ISedeService
    {
        private AlCineEntities db = new AlCineEntities();

        public List<Sede> ListarSede()
        {
            var sede = db.Sedes.Select(s=>s);            
            return sede.ToList() ;
        }

        public Sede ObtenerDetalle(int? id)
        {
            Sede sede = db.Sedes.Find(id);

            return sede;
        }

        public Sede EditarSede(int? id)
        {
            Sede sede = db.Sedes.Find(id);

            return sede;
        }

        public Sede BorrarSede(int? id)
        {
            Sede sede = db.Sedes.Find(id);

            return sede;
        }
    }
}
