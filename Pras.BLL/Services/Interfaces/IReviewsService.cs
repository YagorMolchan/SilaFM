using System;
using System.Collections.Generic;
using Pras.BLL.DTO;

namespace Pras.BLL.Services.Interfaces
{
    public interface IReviewsService
    {
        List<ReviewDTO> Find();
        ReviewDTO Find(Guid id);
        ReviewDTO Save(ReviewDTO model);
        void Delete(Guid id);
        List<ReviewDTO> GetLastReviews(int count);
    }
}
