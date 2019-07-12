using RationCard.Interface;
using System.Collections.Generic;

namespace RationCard.Model
{
    public class CategoryWiseSearchResult
    {
        public List<RationCardDetail> CardSearchResult { get; set; }
        public Category CategoryOfCard { get; set; }
        public int CardCountOfCategory { get; set; }
    }
}
