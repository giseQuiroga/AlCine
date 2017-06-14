﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfaces;
using DataAccessLayer;
using System.Data.Entity;


namespace Service.Services
{
    public class PeliculaService : IPeliculaService
    {
        private AlCineEntities db = new AlCineEntities();

        public List<Pelicula> ListarPeliculas()
        {
            var peliculas = db.Peliculas.Include(p => p.Calificacione).Include(p => p.Genero);            
            return peliculas.ToList() ;
        }
    }
}