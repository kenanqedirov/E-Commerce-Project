using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDto;
using MultiShop.Catalog.Services.SpecialOffer;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService _specialOfferService;
        public SpecialOffersController(ISpecialOfferService SpecialOfferService)
        {
            _specialOfferService = SpecialOfferService;
        }
        [HttpGet]
        public async Task<IActionResult> SpecialOfferList()
        {
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return Ok("SpecialOffer successfully added");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("SpecialOffer successfully deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return Ok("SpecialOffer successfully updated");
        }
    }
}
