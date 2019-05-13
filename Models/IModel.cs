using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public interface IModel
    {
        string ImageUrl { get; set; }
        string Title { get; set; }
        string VideoUrl { get; set; }
    }
}
