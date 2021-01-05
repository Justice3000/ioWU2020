using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace project1{
    internal class ItemRepository : Models.IItemRepository
    {
        private readonly AppDbContext _appDbContext;

        public ItemRepository(AppDbContext appDbContext){
            _appDbContext = appDbContext;
        }

        public IEnumerable<Item> AllItems
        {
            get
            {
                return _appDbContext.Items.Include(p => p.Project);
            }
        }

        public IEnumerable<Item> GetItemByProject(int projectID)
        {
            return _appDbContext.Items.Where(i => i.ProjectId == projectID);
        }

        public void CreateItem(Item item)
        {
            _appDbContext.Items.Add(item);
            _appDbContext.SaveChanges();
        }

        public void EditItem(Item item)
        {
            _appDbContext.Items.Update(item);
            _appDbContext.SaveChanges();
        }

       

    
    }
}