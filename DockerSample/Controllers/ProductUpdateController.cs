using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DbRepository;

namespace WriteView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductUpdateController : ControllerBase    , IWriteProduct
    {

    }
}