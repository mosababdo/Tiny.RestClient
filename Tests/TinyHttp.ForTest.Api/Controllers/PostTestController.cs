﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Tiny.Http.ForTest.Api.Controllers
{
    [Route("api/PostTest")]
    [ApiController]
    public class PostTestController : ControllerBase
    {
        public PostTestController()
        {
        }

        [HttpPost("NoResponse")]
        public Task NoResponse()
        {
            return Task.Delay(1);
        }

        [HttpGet("Simple")]
        public bool Simple()
        {
            return true;
        }

        [HttpGet("Complex")]
        public IEnumerable<string> Complex()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("Stream")]
        public Stream Stream()
        {
            byte[] byteArray = new byte[42];

            for (int i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = i % 2 == 0 ? (byte)0 : (byte)1;
            }

            Stream stream = new MemoryStream(byteArray);

            return stream;
        }
    }
}
