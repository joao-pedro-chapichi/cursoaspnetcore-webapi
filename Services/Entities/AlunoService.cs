using AutoMapper;
using CursoAPIWeb.Data.Interfaces;
using CursoAPIWeb.Objects.Dtos.Entities;
using CursoAPIWeb.Objects.Models;
using CursoAPIWeb.Services.Interfaces;

namespace CursoAPIWeb.Services.Entities;

public class AlunoService : GenericService<Aluno, AlunoDTO>, IAlunoService
{
    private readonly IAlunoRepository _alunoRepository;
    private readonly IMapper _mapper;

    public AlunoService(IAlunoRepository alunoRepository, IMapper mapper) : base(alunoRepository, mapper)
    {
        _alunoRepository = alunoRepository;
        _mapper = mapper;
    }
}
