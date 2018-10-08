using System;
using System.Collections.Generic;

namespace RationCard.Model
{
    public static class MasterData
    {
        public static List<Product> PrdData { get; set; }
        public static List<Hof> Hofs { get; set; }
        public static List<Uom> Uoms { get; set; }
        public static List<RelationMaster> Relations { get; set; }
        public static List<Category> Categories { get; set; }
        public static List<CategoryWiseSearchResult> CategoryWiseSearchResult { get; set; }
        public static int TotalHofCount { get; set; }
        public static int ActiveHofCount { get; set; }
        public static bool MasterDataFetchComplete { get; set; }
        public static DateTime DataFetchTime { get; set; }
    }
}
