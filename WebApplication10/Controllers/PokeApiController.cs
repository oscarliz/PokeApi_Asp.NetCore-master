using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    public class PokeApiController : Controller
    {


        
         List<Result> Pokemones = new List<Result>();


        [HttpGet("[action]")]
        public IEnumerable<Result> Index()
        {

            string url = "https://pokeapi.co/api/v2/pokemon/?offset=500&limit=500";
            WebClient nn = new WebClient();
            var data = nn.DownloadString(url);
            var rs = JsonConvert.DeserializeObject<RootObject>(data);

            foreach (var item in rs.results)
            {
                Pokemones.Add(item);
            }


            return Pokemones;

        }
        
    }
}