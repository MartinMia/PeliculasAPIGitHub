using System;
using PeliculasAPI.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Repositorios
{
    public class RepositorioEnMemoria : IRepositorio
    {
        private List<Genero> _generos;

        public RepositorioEnMemoria()
        {
            _generos = new List<Genero>()
            {
                new Genero(){id=1, Nom="Comedia"},
                new Genero(){id=2, Nom="Accion"}
            };

            _guid = Guid.NewGuid();
        }

        public Guid _guid;

        public List<Genero> GetAll()
        {
            return _generos;
        }

        public async Task<Genero> GetId(int Id)
        {
            await Task.Delay(TimeSpan.FromSeconds(3));

            return _generos.FirstOrDefault(x => x.id == Id);
        }

        public Guid ObtenerGuid()
        {
            return _guid;
        }

        public void CrearGenero(Genero genero)
        {
            genero.id = _generos.Count() + 1;
            _generos.Add(genero);
        }
    }
}
