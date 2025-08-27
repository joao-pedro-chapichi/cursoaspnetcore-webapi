using CursoAPIWeb.Data.Interfaces;
using CursoAPIWeb.Objects.Models;

namespace CursoAPIWeb.Data.Repositories;

public class ProfessorRepository : GenericRepository<Professor>, IProfessorRepository
{
    private readonly AppDbContext _context;

    public ProfessorRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
