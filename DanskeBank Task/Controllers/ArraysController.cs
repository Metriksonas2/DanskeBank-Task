using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;

namespace DanskeBank_Task.Controllers
{
    public class ArraysController : ApiController
    {
        private string conString =
            $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={HostingEnvironment.MapPath(@"~/App_Data/Arrays.mdf")};Integrated Security=True";

        // GET: api/Arrays
        public IEnumerable<NumberArray> Get()
        {
            return ArrayService.GetArrays(conString);
        }

        // GET: api/Arrays/5
        public NumberArray Get(int id)
        {
            return ArrayService.GetArray(id, conString);
        }

        // POST: api/Arrays
        public void Post([FromBody]NumberArray array)
        {
            ArrayService.PostArray(array, conString);
        }

        // PUT: api/Arrays/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Arrays/5
        public void Delete(int id)
        {
            ArrayService.DeleteArray(id, conString);
        }
    }
}
