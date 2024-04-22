using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerManager _cargoCustomerManager;

        public CargoCustomersController(ICargoCustomerManager cargoCustomerManager)
        {
            _cargoCustomerManager = cargoCustomerManager;
        }
        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerManager.GetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = _cargoCustomerManager.GetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            _cargoCustomerManager.Insert(new CargoCustomer
            {
                Address = createCargoCustomerDto.Address,
                City = createCargoCustomerDto.City,
                District = createCargoCustomerDto.District,
                Email = createCargoCustomerDto.Email,
                Name = createCargoCustomerDto.Name,
                Phone = createCargoCustomerDto.Phone,
                Surname = createCargoCustomerDto.Surname
            });
            return Ok("CargoCustomer successfully added");
        }
        [HttpDelete]
        public IActionResult  RemoveCargoCustomer(int id)
        {
            _cargoCustomerManager.Delete(id);
            return Ok("CargoCustomer successfully deleted");
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            _cargoCustomerManager.Update(new CargoCustomer
            {
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                Address = updateCargoCustomerDto.Address, 
                City = updateCargoCustomerDto.City,
                District = updateCargoCustomerDto.District,
                Email = updateCargoCustomerDto.Email,
                Name = updateCargoCustomerDto.Name,
                Phone = updateCargoCustomerDto.Phone,
                Surname = updateCargoCustomerDto.Surname,
            });
            return Ok("Cargo Customer successfully updated");
        }
    } 
}
