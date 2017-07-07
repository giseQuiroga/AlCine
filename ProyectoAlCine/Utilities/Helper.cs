using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using ProyectoAlCine.Utilities;
using System.Text;
using System.Text.RegularExpressions;

namespace ProyectoAlCine.Utilities
{
    public static class Helper
    {
        private static AlCineEntities DB = new AlCineEntities();

        private static List<string> HorariosConvertidos = new List<string>();

        private static List<string> DiasProyeccionPelicula = new List<string>();

        private static List<DiasSemana> ListaDias = new List<DiasSemana>();

        private static List<Fecha> ListaFechas = new List<Fecha>();


        public static List<string> ConstruirHora(int idSede, int idVersion, int idPelicula)
        {
            var duracion = DB.Peliculas.Where(x => x.IdPelicula == idPelicula).Select(y => y.Duracion).FirstOrDefault();
            var horaInicio = DB.Carteleras.Where(x => x.IdSede == idSede && x.IdVersion == idVersion && x.IdPelicula == idPelicula).Select(y => y.HoraInicio).FirstOrDefault();
            HorariosConvertidos.Clear();
            
            List<int> horarios = new List<int>() { horaInicio };
            for (int i = 1; i < 7; i++)
            {
                horarios.Add(horaInicio + duracion + 30);
                horaInicio = horaInicio + duracion + 30;
            }

            foreach (var hora in horarios)
            {
                var horas = Convert.ToInt32(hora.ToString().Substring(0, 2));
                var minutos = Convert.ToInt32(hora.ToString().Substring(2, 2));

                var timeSpan = TimeSpan.FromHours(horas) + TimeSpan.FromMinutes(minutos);
                HorariosConvertidos.Add(timeSpan.ToString(@"hh\:mm"));
            }

            return HorariosConvertidos;
        }

        public static List<string> ObtenerDias(int idSede, int idVersion, int idPelicula)
        {
            var seleccionarDias = DB.Carteleras.Where(x => x.IdPelicula == idPelicula && x.IdVersion == idVersion && x.IdSede == idSede).Select(y => new { y.Lunes, y.Martes, y.Miercoles, y.Jueves, y.Viernes, y.Sabado, y.Domingo }).ToList();

            if (seleccionarDias != null && seleccionarDias.Count > 0)
            {
                var dias = seleccionarDias[0];

                DiasProyeccionPelicula.Clear();

                foreach (var prop in dias.GetType().GetProperties())
                {
                    var name = prop.Name;
                    bool value = (bool)prop.GetValue(dias, null);
                    if (value)
                    {
                        DiasSemana dia = new DiasSemana() { Dia = name, Estado = value };
                        ListaDias.Add(dia);
                        DiasProyeccionPelicula.Add(name.ToUpper());

                    }
                }
            }
            return DiasProyeccionPelicula;
        }

        public static List<Fecha> ObtenerFechas()
        {
            var fechaInicio = DateTime.Today;
            var fechaFin = DateTime.Today.AddDays(30);
            ListaFechas.Clear();

            while (fechaInicio < fechaFin)
            {
                string diaSemanaFechaInicio = fechaInicio.ToString("dddd");

                string diaSemanaFechaInicioSinAcento = eliminarAcento(diaSemanaFechaInicio);

                bool contieneDia = DiasProyeccionPelicula.Where(x => DiasProyeccionPelicula.Contains(diaSemanaFechaInicioSinAcento)).Count() > 0;

                if (contieneDia)
                {
                    Fecha fecha = new Fecha();
                    fecha.Descripcion = diaSemanaFechaInicioSinAcento + " " + fechaInicio.ToShortDateString();
                    fecha.Valor = fechaInicio.ToShortDateString();
                    ListaFechas.Add(fecha);
                }

                fechaInicio = fechaInicio.AddDays(1);
            }
            return ListaFechas;

        }    

        public static string eliminarAcento(string source)
        {
            //8 bit characters 
            byte[] b = Encoding.GetEncoding(1251).GetBytes(source);

            // 7 bit characters
            string t = Encoding.ASCII.GetString(b);
            Regex re = new Regex("[^a-zA-Z0-9]=-_/");
            string c = re.Replace(t, " ");
            return c.ToUpper();
        }
    }
}