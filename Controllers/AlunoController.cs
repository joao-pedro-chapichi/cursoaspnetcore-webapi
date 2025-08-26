using CursoAPIWeb.Objects.Contracts;
using CursoAPIWeb.Objects.Dtos.Entities;
using CursoAPIWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CursoAPIWeb.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AlunoController : Controller
{
    private readonly IAlunoService _alunoService;
    private readonly Response _response;

    public AlunoController(IAlunoService alunoService)
    {
        _alunoService = alunoService;
        _response = new Response();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var alunosDTO = await _alunoService.GetAll();

        _response.Code = ResponseEnum.SUCCESS;
        _response.Data = alunosDTO;
        _response.Message = "Alunos listados com sucesso";

        return Ok(_response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var alunoDTO = await _alunoService.GetById(id);

        if (alunoDTO is null)
        {
            _response.Code = ResponseEnum.NOT_FOUND;
            _response.Data = null;
            _response.Message = "Aluno não encontrado";

            return NotFound(_response);
        }

        _response.Code = ResponseEnum.SUCCESS;
        _response.Data = alunoDTO;
        _response.Message = "Aluno listado com sucesso";

        return Ok(_response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AlunoDTO alunoDTO)
    {
        if (alunoDTO is null)
        {
            _response.Code = ResponseEnum.INVALID;
            _response.Data = null;
            _response.Message = "Dados inválidos";

            return BadRequest(_response);
        }

        try
        {
            // Zeramos o id antes de cadastrar para que o banco gere automaticamente
            // e evite conflito com ids existentes
            alunoDTO.Id = 0;
            await _alunoService.Create(alunoDTO);

            _response.Code = ResponseEnum.SUCCESS;
            _response.Data = alunoDTO;
            _response.Message = "Aluno cadastrado com sucesso";

            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.Code = ResponseEnum.ERROR;
            _response.Message = "Não foi possível cadastrar o aluno";
            _response.Data = new
            {
                ErrorMessage = ex.Message,
                StackTrace = ex.StackTrace ?? "No stack trace available"
            };
            return StatusCode(StatusCodes.Status500InternalServerError, _response);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, AlunoDTO alunoDTO)
    {
        if (alunoDTO is null)
        {
            _response.Code = ResponseEnum.INVALID;
            _response.Data = null;
            _response.Message = "Dados inválidos";

            return BadRequest(_response);
        }

        try
        {
            var existingAlunoDTO = await _alunoService.GetById(id);
            if (existingAlunoDTO is null)
            {
                _response.Code = ResponseEnum.NOT_FOUND;
                _response.Data = null;
                _response.Message = "O aluno informado não existe";
                return NotFound(_response);
            }

            await _alunoService.Update(alunoDTO, id);

            _response.Code = ResponseEnum.SUCCESS;
            _response.Data = alunoDTO;
            _response.Message = "Aluno atualizado com sucesso";

            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.Code = ResponseEnum.ERROR;
            _response.Message = "Ocorreu um erro ao tentar atualizar os dados do aluno";
            _response.Data = new
            {
                ErrorMessage = ex.Message,
                StackTrace = ex.StackTrace ?? "No stack trace available"
            };
            return StatusCode(StatusCodes.Status500InternalServerError, _response);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var existingAlunoDTO = await _alunoService.GetById(id);
            if (existingAlunoDTO is null)
            {
                _response.Code = ResponseEnum.NOT_FOUND;
                _response.Data = null;
                _response.Message = "O aluno informado não existe";
                return NotFound(_response);
            }

            await _alunoService.Remove(id);

            _response.Code = ResponseEnum.SUCCESS;
            _response.Data = null;
            _response.Message = "Aluno removido com sucesso";

            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.Code = ResponseEnum.ERROR;
            _response.Message = "Ocorreu um erro ao tentar remover o aluno";
            _response.Data = new
            {
                ErrorMessage = ex.Message,
                StackTrace = ex.StackTrace ?? "No stack trace available"
            };
            return StatusCode(StatusCodes.Status500InternalServerError, _response);
        }
    }
}