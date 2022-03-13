using Microsoft.AspNetCore.Mvc;
using System;
using TruckControl.API.Application.Services.Validations;
using TruckControl.API.Data.Repositories;
using TruckControl.API.Domain.Entities;
using TruckControl.API.Domain.Entities.Enums;
using TruckControl.API.Models;
using TruckControl.API.Utils.Exceptions;

namespace TruckControl.API.Controllers
{
    [Route("api/truck-register")]
    [ApiController]
    public class TruckRegisterController : ControllerBase
    {
        private readonly ITruckRegisterRepository _repository;

        public TruckRegisterController(ITruckRegisterRepository repository)
        {
            _repository = repository;
         }

        [HttpGet]
        public IActionResult GetAll() 
        { 
            var trucks = _repository.GetAll();
            return Ok(trucks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var truck = _repository.GetById(id);
            if (truck == null)
                return StatusCode(404, new TruckNotFoundException().NotExist(id));
            
            return StatusCode(200,truck);
        }
        
        /// <summary>
        /// Register a new Truck.
        /// </summary>
        /// <param name="truckModel">Truck model</param>
        /// <param name="truckRequestDto">
        /// Request Example:
        /// {
        ///     "details": "Truck detais",
        ///     "fabricationYear": 2022,
        ///     "modelYear": 2023
        /// }
        /// </param>
        /// <returns></returns>
        /// <reponse code="201">Success.</reponse>
        [HttpPost(Name = nameof(Post))]
        public IActionResult Post(TruckModel truckModel, [FromBody] TruckDto truckDto)
        {
            var fabricationYear = new ValidateFabricationYear().IsValid(truckDto.FabricationYear);
            var modelYear = new ValidateModelYear().IsValid(truckDto.ModelYear);

            if (fabricationYear == false) return StatusCode(400, new FabricationYearException().YearException());
            if (modelYear == false) return StatusCode(400, new ModelYearException().YearException());
            
            Truck truck = new Truck();
            truck.Details = truckDto.Details;
            truck.FabricationYear = truckDto.FabricationYear;
            truck.ModelYear = truckDto.ModelYear;
            truck.TruckModel = truckModel;

            _repository.Add(truck);

            return StatusCode(201, truck);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TruckModel truckModel, TruckDto truckDto)
        {
            var truck = _repository.GetById(id);
            if (truck == null)
                return StatusCode(404, new TruckNotFoundException().NotExist(id));

            var fabricationYear = new ValidateFabricationYear().IsValid(truckDto.FabricationYear);
            var modelYear = new ValidateModelYear().IsValid(truckDto.ModelYear);

            if (fabricationYear == false) return StatusCode(400, new FabricationYearException().YearException());
            if (modelYear == false) return StatusCode(400, new ModelYearException().YearException());

            truck.Update(truckDto.Details, truckModel, truckDto.FabricationYear, truckDto.ModelYear);
            _repository.Update(truck);
            
            return StatusCode(201,truck);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var truck = _repository.GetById(id);
            if (truck == null)
                return StatusCode(404, new TruckNotFoundException().NotExist(id));

            _repository.Delete(truck);

            return StatusCode(204);
        }
    }
}
