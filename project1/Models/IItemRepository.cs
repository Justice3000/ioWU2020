using System.Collections.Generic;

namespace project1.Models{
    public interface IItemRepository{

        IEnumerable<Item> AllItems{get;}
        IEnumerable<Item> GetItemByProject(int projectID);
        void CreateItem(Item item);
        void EditItem(Item item);
        

    }

}