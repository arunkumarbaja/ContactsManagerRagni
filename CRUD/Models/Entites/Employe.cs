namespace CRUD.Models.Entites
{
    using CRUD.Enum;
    // You will need these using statements for the annotations
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Employe
    {
        // --- Primary Key ---
        [Key] 
        public int Id { get; set; }

        [StringLength(50)] 
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last name is mandatory.")]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required]
        [EmailAddress] 
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage ="select the following gender")]
        public Gender Gender { get; set; }  

        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
  

        [Required]
        [StringLength(100)]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; } 
    
        [DataType(DataType.Date)] 
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [Range(30000, 250000, ErrorMessage = "Salary must be between $30,000 and $250,000.")]
        [DataType(DataType.Currency)] 
        [Column(TypeName = "decimal(18, 2)")] 
        public decimal Salary { get; set; }

        [Display(Name = "Is Active?")]
        public bool IsActive { get; set; } = true; 

        
    }

}
