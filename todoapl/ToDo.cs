using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace todo
{
    public class ToDo
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; } = string.Empty; 
        [Required(ErrorMessage = "Please enter a due date.")]
        public DateTime? DueDate { get; set; }
        [Required(ErrorMessage = "Please enter a category.")]
        public string CategoryId { get; set; }= string.Empty ;
        [ValidateNever]
        public category Category { get; set; } = null!;
        public string StatusId { get; set; } = null!;


        [Required(ErrorMessage = "please select a status.")]
        public string statusId { get; set; } = string.Empty;
        [ValidateNever]
        public status status { get; set; } = null!;
        public bool Overdue => statusId == "open" && DueDate < DateTime.Today; 

    }
}
