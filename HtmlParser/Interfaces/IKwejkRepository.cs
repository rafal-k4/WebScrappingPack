﻿using Models;
using System.Collections.Generic;

namespace HtmlParser.Interfaces
{
    public interface IKwejkRepository
    {
        int GetFirstPageNumber();
        IEnumerable<KwejkModel> GetObjects();
        IEnumerable<KwejkModel> GetObjects(int id);
    }
}