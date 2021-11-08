using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public BusesAndDriver BusesAndDriver(int id)
    {
      return _dbContext.BusesAndDrivers.Where(X => X.BusesAndDriverId == id).FirstOrDefault();
    }

    // POST api/<TransportController>
    [HttpPost("CreateBusAndDriver")]
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
      var updateBusandDriver = _dbContext.BusesAndDrivers.Where(X => X.BusesAndDriverId == id).FirstOrDefault();

      updateBusandDriver.company = value.company;
      updateBusandDriver.SeatCount = value.seatCount;
      updateBusandDriver.BusNumber = value.busNumber;
      updateBusandDriver.InsurancePolicyNum = value.insurancePolicyNum;
      updateBusandDriver.InsuranceEndDate = value.insuranceEndDate;
      updateBusandDriver.DriverAadhar = value.driverAadhar;
      updateBusandDriver.DriverName = value.driverName;
      updateBusandDriver.DriverNumber = value.driverNumber;
      updateBusandDriver.NotificationSpanId = value.notificationSpanId;

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

    //POST CREATE api/<TransportController>
    [HttpPost("CreateBusTripDetails")]
    public int BusTripDetails([FromBody] BusTripReqandResp busTripReq)
    {
      BusTrip busTrip = new BusTrip();
      busTrip.TripNumber = busTripReq.TripNumber;
      busTrip.TripAreas = busTripReq.TripAreas;
      var splittime = busTripReq.TripTimingFrom.Split(':');
      busTrip.TripTimingFrom = new TimeSpan(Convert.ToInt32(splittime[0]), Convert.ToInt32(splittime[1]), 0);
      splittime = busTripReq.TripTimingTo.Split(':');
      busTrip.TripTimingTo = new TimeSpan(Convert.ToInt32(splittime[0]), Convert.ToInt32(splittime[1]), 0);
      busTrip.BusesAndDriverId = busTripReq.BusesAndDriverId;
      _dbContext.BusTrips.Add(busTrip);
      _dbContext.SaveChanges();

      return busTrip.BusTripid;
    }

    // GET: api/<TransportController>
    [HttpGet("GetBusTripDetails")]
    public IEnumerable<BusTrip> GetBusTripDetails()
    {
      return this._dbContext.BusTrips.Include(x => x.BusesAndDrivers).ToList();
    }

    // GET api/<TransportController>/5
    [HttpGet("BusTripDetails/{id}")]
    public BusTripReqandResp BusTripDetails(int id)
    {
      var busTrips = _dbContext.BusTrips.Where(X => X.BusTripid == id).Include(y => y.BusesAndDrivers).FirstOrDefault();

      return new BusTripReqandResp
      {
        BusesAndDriverId = busTrips.BusesAndDriverId,
        TotalHeadCount = busTrips.TotalHeadCount,
        BusTripid = busTrips.BusTripid,
        TripAreas = busTrips.TripAreas,
        TripNumber = busTrips.TripNumber,
        TripTimingFrom = String.Format("{0}:{1}", busTrips.TripTimingFrom.Hours, busTrips.TripTimingFrom.Minutes),
        TripTimingTo = String.Format("{0}:{1}", busTrips.TripTimingTo.Hours, busTrips.TripTimingTo.Minutes)
      };

    }

    // PUT api/<TransportController>/5
    [HttpPut("UpdateBusTripDetails/{id}")]
    public void UpdateBusTripDetails(int id, [FromBody] BusTripReqandResp busTripReq)
    {
      var updateTrips = _dbContext.BusTrips.Where(X => X.BusTripid == id).FirstOrDefault();

      updateTrips.TripNumber = busTripReq.TripNumber;
      updateTrips.TripAreas = busTripReq.TripAreas;
      var splittime = busTripReq.TripTimingFrom.Split(':');
      updateTrips.TripTimingFrom = new TimeSpan(Convert.ToInt32(splittime[0]), Convert.ToInt32(splittime[1]), 0);
      splittime = busTripReq.TripTimingTo.Split(':');
      updateTrips.TripTimingTo = new TimeSpan(Convert.ToInt32(splittime[0]), Convert.ToInt32(splittime[1]), 0);
      _dbContext.SaveChanges();
    }

    // DELETE api/<TransportController>/5
    [HttpDelete("RemoveBusTripDetail/{id}")]
    public void RemoveBusTripDetail(int id)
    {
      var result = _dbContext.BusTrips.Where(X => X.BusTripid == id).SingleOrDefault();

      if (result != null)
      {
        _dbContext.BusTrips.Remove(result);
        _dbContext.SaveChanges();
      }
    }

    [HttpDelete("UpdateStudentTripDetails/{tripId}/{admissionNumbers}")]
    public void UpdateStudentTripDetails(int tripId, int[] admissionNumbers)
    {
            foreach (var admissionNumber in admissionNumbers)
            {
                var studentUpdate = _dbContext.Students.Where(x => x.AdmissionNumber == admissionNumber).FirstOrDefault();
                if (studentUpdate != null)
                {
                    studentUpdate.StudentTrip.BusTripid = tripId;
                }
                _dbContext.SaveChanges();
            }
    }

  }
}
