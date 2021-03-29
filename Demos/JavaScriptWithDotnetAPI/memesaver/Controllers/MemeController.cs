﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace memesaver
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemeController : ControllerBase
    {
        private readonly UserMethods _business;
        public MemeController(UserMethods business)
        {
            this._business = business;
        }

        [HttpPost("register")]
        public ActionResult<RawPerson> Register(RawPerson rawperson)
        {
            if (!ModelState.IsValid)
            {
                // return StatusCode(409, $"User '{rawPerson.UserName}' already exists.");
                return StatusCode(400, "That was a failue of modelbinding");
            }
            else
            {
                // here you will use the bussiness logic layer instance to pass the data to that layer and eventually save it to the Db.
                Console.WriteLine($"{rawperson.Fname}, {rawperson.Lname}");
            }

            return rawperson;
        }





        // THIS IS AN ACTION METHOD
        // GET: api/<MemeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Mark", "Moore" };
        }

        // GET api/<MemeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MemeController>
        [HttpPost]
        // [Route("/postrequest")]
        public Person Post([FromBody] Person obj)
        {
            Console.WriteLine($"YAY! we made it to the C# side with {obj.Fname}, {obj.Lname}. ");
            //call a method in the business logic layer.
            //the business logic layer implements business requirements. Thisi s where the majority of 
            // the data manipulation will be.
            Person obj1 = business.Login(obj);

            return obj1;
        }

        // PUT api/<MemeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MemeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
