using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{
    [Route("api/[controller]")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository vehicleRepository;
        private readonly IFeatureRepository featureRepository;
        private readonly IUnitOfWork unitOfWork;

        public VehiclesController(IMapper mapper, IVehicleRepository vehicleRepository, IFeatureRepository featureRepository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.vehicleRepository = vehicleRepository;
            this.featureRepository = featureRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody]SaveVehicleResources vehicleResources)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if ((await featureRepository.GetModelAsync(vehicleResources.ModelId)) == null)
            {
                ModelState.AddModelError("ModelId", "Invalid ModelId");
                return BadRequest(ModelState);
            }

            var vehicle = mapper.Map<Vehicle>(vehicleResources);
            vehicle.LastUpdate = DateTime.Now;
            vehicleRepository.Add(vehicle);
            await unitOfWork.CompleteAsync();

            vehicle = await vehicleRepository.GetVehicleAsync(vehicle.Id);

            var result = mapper.Map<VehicleResources>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody]SaveVehicleResources vehicleResources)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await vehicleRepository.GetVehicleAsync(id);

            if (vehicle == null)
            {
                ModelState.AddModelError("Id", "Invalid Vehicle Id");
                return BadRequest(ModelState);
            }

            mapper.Map<SaveVehicleResources, Vehicle>(vehicleResources, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            await unitOfWork.CompleteAsync();
            var result = mapper.Map<VehicleResources>(vehicle);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await vehicleRepository.GetVehicleAsync(id);

            if (vehicle == null)
                return NotFound();

            vehicleRepository.Remove(vehicle);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await vehicleRepository.GetVehicleAsync(id);

            if (vehicle == null)
                return NotFound();

            var vehicleResource = mapper.Map<VehicleResources>(vehicle);

            return Ok(vehicleResource);
        }

    }
}