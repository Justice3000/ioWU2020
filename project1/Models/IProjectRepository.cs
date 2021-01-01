using System.Collections.Generic;

namespace project1{
    public interface IProjectRepository{
        IEnumerable<Project> AllProjects{get;}
        void CreateProject(Project project);
        void EditProject(Project project);

       
    }
}