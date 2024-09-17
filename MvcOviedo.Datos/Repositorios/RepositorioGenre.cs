using MvcOviedo.Datos.Interfaces;
using MvcOviedo.Entidades;

namespace MvcOviedo.Datos.Repositorios
{
    public class RepositorioGenre : RepositorioGenerico<Genre>, IRepositorioGenre
    {
        private readonly MvcOviedoDbContext _db;
        public RepositorioGenre(MvcOviedoDbContext? db) : base(db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public bool EstaRelacionado(int id)
        {
            return false;
            //return _db.Shoes.Any(p => p.GenreId == id);
        }

        public bool Existe(Genre Genre)
        {
            if (Genre.GenreId == 0)
            {
                return _db.Genres.Any(s => s.GenreName == Genre.GenreName);
            }
            return _db.Genres.Any(s => s.GenreName == Genre.GenreName &&
                    s.GenreId != Genre.GenreId);
        }

        public void Update(Genre Genre)
        {
            _db.Genres.Update(Genre);
        }

    }
}
