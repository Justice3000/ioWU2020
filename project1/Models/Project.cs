using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace project1
{
    public class Project
    {
        public int ProjectId{get; set;}
        
        [Required(ErrorMessage = "Project name is mandatory")]
        [Display(Name = "Project Name")]
        [StringLength(50)]
        public string Name{get;set;}


        [Required(ErrorMessage = "Project requires short description")]
        [Display(Name = "Project Description")]
        [StringLength(200, MinimumLength=10)]
        public string Description{get; set;}
        public string ProjectOwner{get; set;}
        public double ProjectCost{
            get
            {
                if (Items != null)
                {
                 return Items.Sum(x=> x.Quantity*x.SupplierPrice);
                }
               return 0;
            }}

        public List<Item> Items {get; set;}
    }
}