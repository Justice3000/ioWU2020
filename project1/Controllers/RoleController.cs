using Microsoft.AspNetCore.Identity;  
using Microsoft.AspNetCore.Mvc;  
using System.Linq; 
using Microsoft.AspNetCore.Authorization;
using project1.ViewModels;


namespace project1.Controllers{
    
public class RoleController:Controller{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;
  

    public RoleController(RoleManager<IdentityRole> roleManager,UserManager<IdentityUser> userManager )
    {
        this._roleManager = roleManager;
        _userManager = userManager;
        
    }



    [Authorize(Policy="admin")]
    public IActionResult Index()
    {
        var roles = _roleManager.Roles.ToList();
        var users = _userManager.Users.ToList();
        
        
        return View(new RolesViewModel
        {
            roleManager = roles, userManager = users, 
        });
    }




//  This should create a new role. saving for later if needed
     
    // public IActionResult Create()
    // {
    //     return View(new IdentityRole());
    // }

    // [HttpPost]  
    //     public IActionResult Create(IdentityRole role)  
    //     {  
    //         roleManager.CreateAsync(role);  
    //         return RedirectToAction("Index");  
    //     }  





}

}