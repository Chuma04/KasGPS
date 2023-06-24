using KasGPS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Point = KasGPS.Models.Point;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KasGPS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Location : ControllerBase
    {
        public static HomeField Homefeild { get; set; }
        // GET: api/<Location>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Location>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Location>
        [HttpPost("log_locatioin")]
        public IActionResult Post(Point point)
        {
            Console.WriteLine(point.ToString());
            return (Homefeild.IsHome(point)) ? Ok("is home") : Ok("is not home");
            //this should log the data to the database 
        }

        //This post's purpose if to initialize the fielf location param. in which the animal should not leave
        [HttpPost("initialize")]
        public IActionResult InitializeHome([FromBody] Models.Point[] points )
        {
            if (points == null) return BadRequest("You have to provide the location ");
            if (points.Length < 3) return BadRequest("the number of coordinate pairs required to form a tracable area is 3 or more");
            Homefeild = new HomeField(points);
            return Ok(points);
        }

        // PUT api/<Location>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Location>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
