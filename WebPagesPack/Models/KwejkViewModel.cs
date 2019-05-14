using Models;
using System.Collections.Generic;


namespace WebPagesPack.Models
{
    public class KwejkViewModel
    {
        public IEnumerable<KwejkModel> KwejkList { get; set; }

        public int CurrentPageNumber { get; set; }
    }
}
