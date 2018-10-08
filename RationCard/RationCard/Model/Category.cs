using RationCard.Interface;

namespace RationCard.Model
{
    public class Category: ICategory
    {
        public string Cat_Id { get; set; }
        public string Cat_Key { get; set; }
        public string Cat_Desc { get; set; }
        public string CardCount { get; set; }
        public string FamilyCount { get; set; }
    }
}
