using KwejkParser.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPagesPack.Models
{
    public class IndexViewModel
    {
        public IEnumerable<IKwejkModel> KwejkViewModel { get; set; }
    }
}
