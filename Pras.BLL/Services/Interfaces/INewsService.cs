using System;
using System.Collections.Generic;
using Pras.BLL.DTO;

namespace Pras.BLL.Services.Interfaces
{
    public interface INewsService
    {
        List<NewsDTO> Find();
        NewsDTO Find(Guid id);
        NewsDTO Save(NewsDTO model);
        void Delete(Guid id);
        NewsDTO Find(string url);
    }
}
