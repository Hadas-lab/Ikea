using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly IkeaContext _ikeaContect;

        public RatingRepository(IkeaContext ikeaContect)
        {
            _ikeaContect = ikeaContect;
        }

        public async Task<Rating> AddRating(Rating rating)
        {
            await _ikeaContect.Rating.AddAsync(rating);
            await _ikeaContect.SaveChangesAsync();
            return rating;
        }

    }
}
