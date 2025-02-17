﻿using Application.Interfaces.Services;
using Application.Mapper.DTOs;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers
{
    [Route("api")] // Remove /Car from URL route
    [ApiController]
    public class CarController : ControllerBase
    {
        #region Injection

        private readonly ILogger<CarController> _logger;
        private readonly ICarService _carService;

        public CarController(ILogger<CarController> logger, ICarService carService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _carService = carService ?? throw new ArgumentNullException(nameof(carService));
        }

        #endregion Injection

        [HttpGet("cars")]
        // [Authorize]
        public ActionResult GetCars()
        {
            var carDTOs = _carService.GetCars();
            if (!carDTOs.Any())
                return NoContent(); // Returns HTTP 204 if there are no records

            // HTTP 200
            return Ok(
                new
                {
                    Response = "Cars records retrieved successfully",
                    Data = carDTOs
                });
        }

        [HttpGet("cars/{carID}")]
        [Authorize]
        public ActionResult GetCarByID(int carID)
        {
            var carDTO = _carService.GetCar(carID);

            // HTTP 200
            return Ok(
                new
                {
                    Response = "Car record retrieved successfully",
                    Data = carDTO
                });
        }

        [HttpPost("cars")]
        [Authorize(Roles = "Admin")]
        public ActionResult AddCar(CarDTO carDTO)
        {
            if (carDTO == null)
                return BadRequest("Invalid input data"); // return 400 Bad Request

            _carService.AddCar(carDTO);

            // HTTP 200
            return Ok(
                new
                {
                    Response = "Car record created successfully",
                    Data = carDTO
                });
        }

        [HttpPut("cars/{carID}")]
        [Authorize]
        public ActionResult UpdateCar(int carID, CarDTO carDTO)
        {
            if (carDTO == null)
                return BadRequest("Invalid input data"); // return 400 Bad Request

            _carService.UpdateCar(carID, carDTO);

            // HTTP 200
            return Ok(
                new
                {
                    Response = "Car record updated successfully",
                    Data = carDTO
                });
        }

        [HttpDelete("cars/{carID}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteCar(int carID)
        {
            _carService.DeleteCar(carID);

            // HTTP 200
            return Ok(
                new
                {
                    Response = "Car record deleted successfully"
                });
        }

        [HttpPut("cars/upload-image/{carID}")]
        [Authorize]
        public ActionResult UploadImage(IFormFile formFile, int carID)
        {
            var carDTO = _carService.UploadImage(formFile, carID);

            // HTTP 200
            return Ok(new
            {
                Response = "Car image uploaded successfully",
                Data = carDTO
            });
        }
    }
}
