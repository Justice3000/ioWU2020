using project1.Models;
using project1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace project1.ProjectController{

    
    public class ProjectController:Controller{
        private readonly IProjectRepository _projectRepository;
        private readonly IItemRepository _itemRepository;
        private readonly UserManager<IdentityUser> _userManager;
        


        public ProjectController(IProjectRepository projectRepository, IItemRepository itemRepository, UserManager<IdentityUser> userManager)
        {
           _itemRepository = itemRepository;
            _projectRepository = projectRepository;
            _userManager = userManager;
           
        }

        [Authorize(Policy="user")]
        public ViewResult AllProjects()
        {   
            IEnumerable<Project> projects;

            var userEmail =_userManager.GetUserName(User);

            if(User.IsInRole("manager") || User.IsInRole("admin"))
            {
              projects =_projectRepository.AllProjects.OrderBy(o => o.ProjectId); 
            }
            else 
            {
            projects = _projectRepository.AllProjects.OrderBy(o => o.ProjectId)
            .Where(u => u.ProjectOwner == userEmail);

            
            }

            return View(new ProjectsAllProjectsViewModel
            {
                Projects = projects

            });
          
            
        }




        [Authorize(Policy="user")]
        public IActionResult CreateProject()
    {
        return View();
    }

        [HttpPost]
        public IActionResult CreateProject(Project project)
        {
            if(ModelState.IsValid)
            {
                _projectRepository.CreateProject(project);
            return RedirectToAction("CreateProjectComplete");
            }
            return View(project);
        }

         [Authorize(Policy="user")]
        public IActionResult CreateProjectComplete()
        {
          return RedirectToAction("AllProjects");
        }


        [Authorize(Policy="user")]
        public IActionResult EditProject(int? projectId)
        {
            var project = _projectRepository.AllProjects.FirstOrDefault(x => x.ProjectId == projectId);

            return View(project);
        }

         [Authorize(Policy="user")]
         [HttpPost]
         public IActionResult EditProject(Project project)
         {
             if(ModelState.IsValid)
             {
                 _projectRepository.EditProject(project);
                 return RedirectToAction("AllProjects");
             }
             return View(project);
         }
        

       

    



       

    
    }
}