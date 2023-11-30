using BuisnessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Photographs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotographController : ControllerBase
    {
        readonly IPhotographService photographService;
        public PhotographController(IPhotographService photographService)
        {
            this.photographService = photographService;
        }
        [HttpGet]
        [Route("{id}")]
        public CollectionDetails getCollectionNameById(string id)
        {
            return photographService.getCollectionNameById(id);
        }
        [HttpPost]
        public async Task AddCards(List<Card> cards)
        {
            await photographService.AddCards(cards);
        }

    }
}
