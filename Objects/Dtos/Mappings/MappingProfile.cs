using AutoMapper;
using CursoAPIWeb.Objects.Dtos.Entities;
using CursoAPIWeb.Objects.Models;

namespace CursoAPIWeb.Objects.Dtos.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Professor, ProfessorDTO>().ReverseMap();
        CreateMap<Aluno, AlunoDTO>().ReverseMap();
    }
}
