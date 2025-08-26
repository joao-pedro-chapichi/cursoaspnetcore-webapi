using CursoAPIWeb.Data.Interfaces;
using CursoAPIWeb.Objects.Models;

namespace CursoAPIWeb.Data.Repositories;

public class AlunoRepository : GenericRepository<Aluno>, IAlunoRepository
{
    private readonly AppDbContext _context;

    public AlunoRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
