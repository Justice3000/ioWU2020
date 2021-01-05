using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace project1{

    public class Item{

        public int ItemId{get; set;}

        [Required(ErrorMessage = "Please enter the item's name")]
        [Display(Name = "Item's name")]
        [StringLength(100)]
        public string Name{get; set;}


         [Required(ErrorMessage = "Please enter the supplier's name")]
        [Display(Name = "Supplier")]
        [StringLength(100)]
        public string SupplierName{get; set;}

        [Required(ErrorMessage = "Please enter the price")]
        [DataType(DataType.Currency)]
        [Display(Name = "Supplier's Price")]
        public double SupplierPrice{get; set;}


        [Required(ErrorMessage = "Please enter quantity")]
        [Display(Name = "Quantity")]
        public int Quantity{get; set;}

        [Required(ErrorMessage = "Please enter a valid URL ")]
        [DataType(DataType.Url)]
        [Display(Name = "Link")]
        public string Url{get; set;}

        [Required(ErrorMessage = "Please enter something")]
        [DataType(DataType.Text)]
        [Display(Name = "Long Description")]
        public string LongImportantInfo{get; set;}
        public int ProjectId{get; set;}
        public string ItemOwner {get; set;}
        public Project Project {get; set;} 

    }
}