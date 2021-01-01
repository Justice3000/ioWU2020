using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace project1
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProjectRepository(AppDbContext appDbContext){
            _appDbContext = appDbContext;
        }

    
        public IEnumerable<Project> AllProjects
        {
            get
            {
                
                return _appDbContext.Projects.Include(p => p.Items);
            }
        }

      

        public void CreateProject(Project project)
        {
           _appDbContext.Projects.Add(project);
           _appDbContext.SaveChanges();

        }

        public void EditProject(Project project)
        {
            _appDbContext.Projects.Update(project);
            _appDbContext.SaveChanges();
        }
        
    }
}