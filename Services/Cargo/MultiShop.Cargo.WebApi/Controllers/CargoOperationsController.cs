using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }
        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoDetailrById(int id)
        {
            var value = _cargoOperationService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoOperationDto createCargoOperationDto)
        {
            _cargoOperationService.TInsert(new CargoOperation
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate
            });
            return Ok("CargoCustomer successfully added");
        }
        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("CargoCustomer successfully deleted");
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoOperationDto updateCargoOperationDto)
        {
            _cargoOperationService.TUpdate(new CargoOperation
            {
               Barcode = updateCargoOperationDto.Barcode,
               CargoOperationId = updateCargoOperationDto.CargoOperationId,
               Description = updateCargoOperationDto.Description,
               OperationDate = updateCargoOperationDto.OperationDate
            });
            return Ok("Cargo Detail successfully updated");
        }
    }
}
