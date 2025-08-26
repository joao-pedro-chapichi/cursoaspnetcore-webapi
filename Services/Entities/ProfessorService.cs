using AutoMapper;
using CursoAPIWeb.Data.Interfaces;
using CursoAPIWeb.Objects.Dtos.Entities;
using CursoAPIWeb.Objects.Models;
using CursoAPIWeb.Services.Interfaces;

namespace CursoAPIWeb.Services.Entities;


public class ProfessorService : GenericService<Professor, ProfessorDTO>, IProfessorService
{
    private readonly IProfessorRepository _professorRepository;
    private readonly IMapper _mapper;

    public ProfessorService(IProfessorRepository professorRepository, IMapper mapper) : base(professorRepository, mapper)
    {
        _professorRepository = professorRepository;
        _mapper = mapper;
    }
}
