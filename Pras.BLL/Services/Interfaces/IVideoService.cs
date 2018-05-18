using System;
using System.Collections.Generic;
using Pras.BLL.DTO;

namespace Pras.BLL.Services.Interfaces
{
    public interface IVideoService
    {
        List<VideoDTO> Find();
        VideoDTO Find(Guid id);
        VideoDTO Save(VideoDTO model);
        void Delete(Guid id);
    }
}
