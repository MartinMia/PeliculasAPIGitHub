using PeliculasAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Repositorios
{
    public interface IRepositorio
    {
        Task<Genero> GetId(int Id);
        List<Genero> GetAll();
        Guid ObtenerGuid();
        void CrearGenero(Genero genero);
    }
}
