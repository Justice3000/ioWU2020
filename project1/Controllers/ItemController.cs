using project1.Models;
using project1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace project1.ItemController{


    public class ItemController:Controller{

        private readonly IItemRepository _itemRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly UserManager<IdentityUser> _userManager;
       

        public ItemController(IItemRepository itemRepository, IProjectRepository projectRepository, UserManager<IdentityUser> userManager)
        {
            _itemRepository = itemRepository;
            _projectRepository = projectRepository;
            _userManager = userManager;
           
        }

    [Authorize(Policy="user")]
    public IActionResult AllItemsByProject(int projectID)
    {
        var userEmail =_userManager.GetUserName(User);
        var items = _itemRepository.GetItemByProject(projectID);
        var projects = _projectRepository.AllProjects;

       
       if(User.IsInRole("manager") || User.IsInRole("admin"))
       {
           return View(new ItemsAllViewModel
             {
                 Items = items, curProjectID = projectID, Projects = projects
             });
       }else if(projectID == 0)
       {
           
           return View("~/Views/Home/Index.cshtml");
       }
       
       else {
           items = items.Where(x=> x.ItemOwner == userEmail);

           return View(new ItemsAllViewModel
             {
                 Items = items, curProjectID = projectID, Projects = projects
             });
       }
       
       
         
        
    }


 [Authorize(Policy="user")]
    public IActionResult EditItem(int? itemId)
        {   
        var item = _itemRepository.AllItems.FirstOrDefault(i => i.ItemId == itemId);
            
        return View(item); 
        
        }

[Authorize(Policy="user")]
[HttpPost]
    public IActionResult EditItem(Item item)
    {
        if(ModelState.IsValid)
        {
           _itemRepository.EditItem(item);
           return RedirectToAction("CreateItemComplete", new {item.ProjectId});
        }
        return View(item);
    }



    [Authorize(Policy="user")]
    public IActionResult CreateItem(int ProjectId)
        {   
            var userEmail =_userManager.GetUserName(User);
            var projectOwnerIs = _projectRepository.AllProjects.FirstOrDefault(w => w.ProjectId == ProjectId).ProjectOwner;

            if(userEmail == projectOwnerIs){
                return View();
            }
            else 
            return RedirectToAction("CreateItemComplete");
          
            
            
        }



    [Authorize(Policy="user")]
    [HttpPost]
    public IActionResult CreateItem(Item item)
    {
        if(ModelState.IsValid)
        {
        _itemRepository.CreateItem(item);
        return RedirectToAction("CreateItemComplete", new {item.ProjectId});
        }
        return View(item);
        
    }

    [Authorize(Policy="user")]
    public IActionResult CreateItemComplete(int ProjectID)
    {
       return RedirectToAction("AllItemsByProject", new {projectID = ProjectID });
    }

    }
}