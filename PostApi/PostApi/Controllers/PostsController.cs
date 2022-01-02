using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        // GET: api/<PostsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        

        // GET api/<PostsController>/5
        [HttpGet("{start}/{end}")]
        public IActionResult Get(int start,int end)
        {
            var data = new Data();

            for (var i = start; i <= end; i++)
            {
               data.Add($"Post {i}");
            }

            return new JsonResult(data);          

        }

      
    }


     public class Data
     {

        public Data()
        {
            posts = new List<string>();
        }

        private List<string> posts;

        public List<string> Posts
        {
            get { return posts; }
            set { posts = value; }
        }

        public void Add(string post)
        {
            Posts.Add(post);
        }

        public void Remove(string post)
        {
            var ix=Posts.FindIndex(r => r == post);
            if (ix >= 0)
                Posts.RemoveAt(ix);
        }

    }

}
