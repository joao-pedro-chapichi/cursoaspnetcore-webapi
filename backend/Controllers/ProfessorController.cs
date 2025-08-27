using CursoAPIWeb.Objects.Contracts;
using CursoAPIWeb.Objects.Dtos.Entities;
using CursoAPIWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CursoAPIWeb.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProfessorController : Controller
{
    private readonly IProfessorService _professorService;
    private readonly Response _response;

    public ProfessorController(IProfessorService professorService)
    {
        _professorService = professorService;
        _response = new Response();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var professorsDTO = await _professorService.GetAll();

        _response.Code = ResponseEnum.SUCCESS;
        _response.Data = professorsDTO;
        _response.Message = "Professores listados com sucesso";

        return Ok(_response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var professorDTO = await _professorService.GetById(id);

        if (professorDTO is null)
        {
            _response.Code = ResponseEnum.NOT_FOUND;
            _response.Data = null;
            _response.Message = "Professor não encontrado";

            return NotFound(_response);
        }

        _response.Code = ResponseEnum.SUCCESS;
        _response.Data = professorDTO;
        _response.Message = "Professor listado com sucesso";

        return Ok(_response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProfessorDTO professorDTO)
    {
        if (professorDTO is null)
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
            professorDTO.Id = 0;
            await _professorService.Create(professorDTO);

            _response.Code = ResponseEnum.SUCCESS;
            _response.Data = professorDTO;
            _response.Message = "Professor cadastrado com sucesso";

            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.Code = ResponseEnum.ERROR;
            _response.Message = "Não foi possível cadastrar o professor";
            _response.Data = new
            {
                ErrorMessage = ex.Message,
                StackTrace = ex.StackTrace ?? "No stack trace available"
            };
            return StatusCode(StatusCodes.Status500InternalServerError, _response);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ProfessorDTO professorDTO)
    {
        if (professorDTO is null)
        {
            _response.Code = ResponseEnum.INVALID;
            _response.Data = null;
            _response.Message = "Dados inválidos";

            return BadRequest(_response);
        }

        try
        {
            var existingProfessorDTO = await _professorService.GetById(id);
            if (existingProfessorDTO is null)
            {
                _response.Code = ResponseEnum.NOT_FOUND;
                _response.Data = null;
                _response.Message = "O professor informado não existe";
                return NotFound(_response);
            }

            await _professorService.Update(professorDTO, id);

            _response.Code = ResponseEnum.SUCCESS;
            _response.Data = professorDTO;
            _response.Message = "Professor atualizado com sucesso";

            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.Code = ResponseEnum.ERROR;
            _response.Message = "Ocorreu um erro ao tentar atualizar os dados do professor";
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
            var existingProfessorDTO = await _professorService.GetById(id);
            if (existingProfessorDTO is null)
            {
                _response.Code = ResponseEnum.NOT_FOUND;
                _response.Data = null;
                _response.Message = "O professor informado não existe";
                return NotFound(_response);
            }

            await _professorService.Remove(id);

            _response.Code = ResponseEnum.SUCCESS;
            _response.Data = null;
            _response.Message = "Professor removido com sucesso";

            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.Code = ResponseEnum.ERROR;
            _response.Message = "Ocorreu um erro ao tentar remover o professor";
            _response.Data = new
            {
                ErrorMessage = ex.Message,
                StackTrace = ex.StackTrace ?? "No stack trace available"
            };
            return StatusCode(StatusCodes.Status500InternalServerError, _response);
        }
    }
}
