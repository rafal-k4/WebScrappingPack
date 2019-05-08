using Models;
using System.Collections.Generic;


namespace WebPagesPack.Models
{
    public class IndexViewModel
    {
        public IEnumerable<KwejkModel> KwejkViewModel { get; set; }

        public IEnumerable<JbzdyModel> JbzdyViewModel { get; set; }

        public int CurrentPageNumber { get; set; }
    }
}
