using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;


namespace Service.Interfaces
{
    public interface ICalificacionService
    {
        List<Calificacione> ListarCalificaciones();

        Calificacione ObtenerDetalle(int? id);

        Calificacione EditarCalificacion(int? id);

        Calificacione BorrarCalificacion(int? id);
       
    }
}
