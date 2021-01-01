using System.Collections.Generic;

namespace project1.ViewModels
{
    public class ItemsAllViewModel{
        public IEnumerable<Item> Items {get;set;}
        public int curProjectID;
        public IEnumerable<Project> Projects {get; set;}

    }
}