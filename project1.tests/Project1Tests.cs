using System;
using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace project1.tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestProjectCreation()
        {

            //ARRANGE
            var opt = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("UNIT_TEST").Options;
            
            using (var db = new AppDbContext(opt)){
            ProjectRepository projectRepository = new ProjectRepository(db);
            var result = projectRepository.AllProjects;
            




            //ACT
            //using my method of project creation
        projectRepository.CreateProject(new Project
            {
                Name = "Unit Test",
                ProjectId = 4,
                ProjectOwner = "unitTester",
                Description = "text"
            });
            
            //ASSERT
            // checking if I've made an addition, and if my seed is present. 
            Assert.Equal(4, result.Count()); 

            //looking for the test name ive added
            Assert.Equal("Unit Test",db.Projects.FirstOrDefault(c => c.Name =="Unit Test").Name);

            //checking if that name has expected id
            Assert.Equal("Unit Test", db.Projects.FirstOrDefault(i => i.ProjectId == 4).Name);
            
            
            }

        }


         [Fact]
            public void TestItem1(){
                 var opt = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("UNIT_TEST").Options;
            
            using (var db = new AppDbContext(opt)){
                ItemRepository itemRepository = new ItemRepository(db);
                ProjectRepository projectRepository = new ProjectRepository(db);

                var projectCostBefore = projectRepository.AllProjects.FirstOrDefault(x => x.ProjectId ==1).ProjectCost;
               

               
                //ACT

            //creating new item
                itemRepository.CreateItem(new Item
                {
                    Name = "Unit Item",
                    ItemId = 999,
                    ProjectId = 1,
                    SupplierPrice = 1,
                    Quantity = 1
                });

                 var itemNumberInProject = projectRepository.AllProjects.FirstOrDefault(c => c.ProjectId == 1).Items.Count;

                 var projectCostAfter = projectRepository.AllProjects.FirstOrDefault(x => x.ProjectId ==1).ProjectCost;

                 

                //ASSERT
                
                // project with id=1 has items seeded. Im execting to get 4 with my latest addition
                Assert.Equal(4, itemNumberInProject);

                // My newly added item is valued = 1, therefore im expecting that cost after addition will be just -1.
                Assert.Equal(projectCostBefore, projectCostAfter -1);
                }


        }
    }
}
