using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginTest.Models
{
    public class response
    {
       public List<User> body { get; set; }
       public status status { get; set; }
    }
}
