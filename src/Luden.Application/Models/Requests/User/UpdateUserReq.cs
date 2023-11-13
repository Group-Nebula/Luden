using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luden.Application.Models.Requests.User
{
    public class UpdateUserReq
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}
