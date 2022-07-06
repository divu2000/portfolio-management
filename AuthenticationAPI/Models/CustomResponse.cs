using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAPI.Models
{
    public class CustomResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public CustomResponse(int status, string message)
        {
            this.status = status;
            this.message = message;
        }
    }
}
