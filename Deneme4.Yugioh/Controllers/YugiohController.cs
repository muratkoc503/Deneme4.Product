using Deneme4.Yugioh.Models;
using Deneme4.Yugioh.Repositories;
using Deneme4.Yugioh.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Deneme4.Yugioh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YugiohController : ControllerBase
    {
        #region Variables

        private readonly IYugiohRepository _yugiohRepository;
        private readonly ILogger<YugiohController> _logger;

        #endregion

        #region Constructor

        public YugiohController(IYugiohRepository yugiohRepository, ILogger<YugiohController> logger)
        {
            _yugiohRepository = yugiohRepository;
            _logger = logger;
        }

        #endregion

        #region Crud_Actions

        [HttpGet]
        [Route("GetCards")]
        [ProducesResponseType(typeof(YugiohCard), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<YugiohCard>>> GetCards()
        {
            var YugiohCard = await _yugiohRepository.GetCards();
            return Ok(YugiohCard);
        }

        [HttpGet("{id}", Name = "GetCard")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(YugiohCard), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<YugiohCard>> GetPCard(int id)
        {
            var product = await _yugiohRepository.GetCard(id);
            if (product == null)
            {
                _logger.LogError($"Product with id : {id},hasn't been found in databasei");
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<YugiohCard>> CreateCard([FromBody] YugiohCard card)
        {
            await _yugiohRepository.Create(card);

            return CreatedAtRoute("GetCard", new { id = card.Id }, card);
        }


        [HttpPut]
        [ProducesResponseType(typeof(YugiohCard), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCard([FromBody] YugiohCard card)
        {
            return Ok(await _yugiohRepository.Update(card));
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(YugiohCard), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            return Ok(await _yugiohRepository.Delete(id));
        }

        #endregion
    }
}
