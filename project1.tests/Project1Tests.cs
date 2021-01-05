using System;
using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace project1.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            //ARRANGE
            var opt = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("UNIT_TEST").Options;
            //ACT
            using (var db = new AppDbContext(opt)){
            ProjectRepository projectRepository = new ProjectRepository(db);
            var result = projectRepository.AllProjects;
            
            //ASSERT
            Assert.Equal(1, result.Count()); //fail expected because i have 3 projects ATM
            
            
            }

        

            

        }
    }
}
