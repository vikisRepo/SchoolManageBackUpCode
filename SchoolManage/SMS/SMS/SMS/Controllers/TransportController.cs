using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SMS.Models.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly MysqlDataContext _dbContext;
        private readonly IMapper _mapper;

        public TransportController(MysqlDataContext dbcontext, IMapper mapper)
        {
            this._dbContext = dbcontext;
            this._mapper = mapper;
        }

        // GET: api/<TransportController>
        [HttpGet("BusesAndDriver")]
        public IEnumerable<BusesAndDriver> BusesAndDriver()
        {
            return this._dbContext.BusesAndDrivers.ToList();
        }

        // GET api/<TransportController>/5
        [HttpGet("BusesAndDriver/{id}")]
        public IEnumerable<BusesAndDriver> BusesAndDriver(int id)
        {
            return _dbContext.BusesAndDrivers.Where(X => X.BusesAndDriverId == id).ToList();
        }

        // POST api/<TransportController>
        [HttpPost ("CreateBusAndDriver")]
        public void CreateBusAndDriver([FromBody] BusesAndDriverReq value)
        {
            //var result = _mapper.Map<BusesAndDriver>(value);
            var BD = new BusesAndDriver();

            BD.BusTypeid = value.busTypeid;
            BD.company = value.company;
            BD.SeatCount = value.seatCount;
            BD.BusNumber = value.busNumber;
            BD.InsurancePolicyNum = value.insurancePolicyNum;
            BD.InsuranceEndDate = value.insuranceEndDate;
            BD.DriverAadhar = value.driverAadhar;
            BD.DriverName = value.driverName;
            BD.DriverNumber = value.driverNumber;
            BD.NotificationSpanId = value.notificationSpanId;

            //BD.ArrivalTime = value.ArrivalTime;
            //BD.BusLocation = value.busLocation;
            //BD.BusStatus = value.BusStatus;
            _dbContext.BusesAndDrivers.Add(BD);
            _dbContext.SaveChanges();
        }

        // PUT api/<TransportController>/5
        [HttpPut("UpdateBusAndDriver/{id}")]
        public void UpdateBusAndDriver(int id, [FromBody] BusesAndDriverReq value)
        {
            _dbContext.Entry(_dbContext.BusesAndDrivers.Where(X => X.BusesAndDriverId == id).SingleOrDefault()).CurrentValues.SetValues(value);
            _dbContext.SaveChanges();
        }

        // DELETE api/<TransportController>/5
        [HttpDelete("RemoveBusAndDriver/{id}")]
        public void RemoveBusAndDriver(int id)
        {
            var result = _dbContext.BusesAndDrivers.Where(X => X.BusesAndDriverId == id).SingleOrDefault();

            if (result != null)
            {
                _dbContext.BusesAndDrivers.Remove(result);
                _dbContext.SaveChanges();
            }
        }
    }
}
