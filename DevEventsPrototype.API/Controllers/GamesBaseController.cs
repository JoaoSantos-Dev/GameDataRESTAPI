using AutoMapper;
using GamesBasePrototype.API.Entities;
using GamesBasePrototype.API.Models;
using GamesBasePrototype.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamesBasePrototype.API.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class GamesBaseController : ControllerBase
    {
        private readonly GamesBaseDbContext _context;
        private readonly IMapper _mapper;

        public GamesBaseController(
            GamesBaseDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Obter todos os Jogos
        /// </summary>
        /// <returns>Coleção de Jogos</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var gamesBase = _context.GamesBase.Where(d => !d.IsDeleted).ToList();

            var viewModel = _mapper.Map<List<GamesBaseViewModel>>(gamesBase);

            return Ok(viewModel);
        }

        /// <summary>
        /// Obter um Jogo
        /// </summary>
        /// <param name="id">Identificador do Jogos</param>
        /// <returns>Dados do Evento por ID</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var gamesBase = _context.GamesBase
                .Include(g => g.Devs) // Certifique-se de incluir os desenvolvedores
                .SingleOrDefault(d => d.Id == id);

            if (gamesBase == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<GamesBaseViewModel>(gamesBase);

            return Ok(viewModel);
        }

        /// <summary>
        /// Cadastrar um Jogo
        /// </summary>
        /// <remarks>
        /// {"title": "string","description":"string","startDate": "2024-08-31T12:12:33.866Z","endDate": "2024-08-31T12:12:33.866Z"}
        /// </remarks>
        /// <param name="input">Dados do Jogo</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(GamesBaseInputModel input)
        {
            var gamesBase = _mapper.Map<GamesBase>(input);

            _context.GamesBase.Add(gamesBase);

            _context.SaveChanges();


            return CreatedAtAction(nameof(GetById), new {id = gamesBase.Id}, gamesBase);
        }

        /// <summary>
        /// Atualizar um Jogo
        /// </summary>
        /// <remarks>
        /// {"title": "string","description":"string","startDate": "2024-08-31T12:12:33.866Z","endDate": "2024-08-31T12:12:33.866Z"}
        /// </remarks>
        /// <param name="id">Identificador do Jogo</param>
        /// <param name="input">Dados do Jogo</param>
        /// <returns>Nada</returns>
        /// <response code="204">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(Guid id, GamesBaseInputModel input)
        {
            var gamesBase = _context.GamesBase.SingleOrDefault(d => d.Id == id);

            if (gamesBase == null)
            {
                return NotFound();
            }

            gamesBase.Update(input.Title, input.Description, input.AnnouncementDate, input.EndDate);


            _context.GamesBase.Update(gamesBase);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Deletar um Jogo
        /// </summary>
        /// <param name="id">Identificador do Jogo</param>
        /// <returns>Nada</returns>
        /// <response code="204">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(Guid id)
        {
            var gamesBase = _context.GamesBase.SingleOrDefault(d => d.Id == id);

            if (gamesBase == null)
            {
                return NotFound();
            }

            gamesBase.Delete();
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Cadastrar Desenvolvedora
        /// </summary>
        /// <remarks>
        /// {"name": "string","talkTitle": "string","talkDescription": "string","linkedInProfile": "string"}
        /// </remarks>
        /// <param name="id">Identificador do Jogo</param>
        /// <param name="input">Dados da Desenvolvedora</param>
        /// <returns>Nada</returns>
        /// <response code="204">Sucesso</response>
        /// <response code="404">Jogo não Encontrado</response>
        [HttpPost("{id}/devs")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PostSpeaker(Guid id, GamesBaseDevInputModel input)
        {
            var gamesBase = _context.GamesBase.SingleOrDefault(g => g.Id == id);

            if (gamesBase == null)
            {
                return NotFound();
            }

            var developer = _mapper.Map<GamesBaseDev>(input);
            developer.GamesBaseId = id;

            _context.GamesBaseDev.Add(developer);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
