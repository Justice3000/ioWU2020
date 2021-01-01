using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace project1.ViewModels{

    public class RolesViewModel{

    public IEnumerable <IdentityRole> roleManager {set; get;}
    public IEnumerable <IdentityUser> userManager {set; get;}
    }
}