using Models;
using System.Collections.Generic;


namespace WebPagesPack.Models
{
    public class JbzdyViewModel
    {
        public IEnumerable<JbzdyModel> JbzdyList { get; set; }

        public int CurrentPageNumber { get; set; }
    }
}
