using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }
        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoDetailrById(int id)
        {
            var value = _cargoDetailService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            _cargoDetailService.TInsert(new CargoDetail
            {
               Barcode = createCargoDetailDto.Barcode,
               CargoCompanyId = createCargoDetailDto.CargoCompanyId,
               ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
               SenderCustomer = createCargoDetailDto.SenderCustomer,
            });
            return Ok("CargoCustomer successfully added");
        }
        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("CargoCustomer successfully deleted");
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            _cargoDetailService.TUpdate(new CargoDetail
            {
               Barcode = updateCargoDetailDto.Barcode,
               CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
               CargoDetailId= updateCargoDetailDto.CargoDetailId,
               ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
               SenderCustomer = updateCargoDetailDto.SenderCustomer
            });
            return Ok("Cargo Detail successfully updated");
        }
    }
}