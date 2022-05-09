using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupaTest.Classes;
using SupaTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SupaTest
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        Supabase.Client context = SupaClient.getInstance().Result;

        // GET: api/<ValuesController>
        [HttpGet]
        async public Task<ActionResult> Get()
        {
            Console.WriteLine(
                
            ) ;

            var res = context.From<Biens>().Select("*").Get().Result.Content.ToString();

            //return new string[] { "value1", "value2" };
            return Ok(res);
        }   

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        async public Task<ActionResult> Get(int id)
        {
            //return "value" + id.ToString();
            var res = context.From<Biens>().Select("*").Filter("id", Postgrest.Constants.Operator.Equals, id).Limit(1).Get().Result;

            return Ok(res.Content);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post(string nom, string idImm)
        {
            if(!String.IsNullOrEmpty(nom) && !String.IsNullOrEmpty(idImm))
            {
                int _idImm = int.Parse(idImm);

                var bien = new Biens();
                bien.Nom = nom;
                bien.idImm = _idImm;

                var res = context.From<Biens>().Insert(bien).Result.Content;
                return Ok(res);

            }
            return NotFound();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
