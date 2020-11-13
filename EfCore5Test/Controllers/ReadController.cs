using EfCore5Test.Db;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore5Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReadController : ControllerBase
    {
        private readonly MyDbContext myDbContext;
        private readonly ILogger<ReadController> _logger;

        public ReadController(MyDbContext myDbContext, ILogger<ReadController> logger)
        {
            this.myDbContext = myDbContext;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<MyCoolModel>> Get()
        {
            var ids = new int[] { 1, 2, 3 };
            var data = await myDbContext.Set<MyCoolModel>()
                            .Where(cool => ids.Contains(EF.Property<int>(cool, "FirstId")))
                            .ToListAsync();
            return data;
        }
    }
}
