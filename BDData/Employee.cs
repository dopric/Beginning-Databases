using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDData
{
    [Table("Employees")]
    public class Employee
    {
        [Column("EmployeeID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage ="Employee Id is required")]
        [Display(Name ="Employee Id")]
        public int EmployeeID { get; set; }

        [Column("FirstName")]
        [Display(Name ="First Name")]
        [Required(ErrorMessage ="First Name is required")]
        [StringLength(50, ErrorMessage ="First Name must be less than 50 Characters")]
        public string FirstName { get; set; }

        [Column("LastName")]
        [Display(Name ="Last Name")]
        [Required(ErrorMessage ="Last Name is required")]
        [StringLength(50, ErrorMessage ="Last Name must be less than 50 Characters")]
        public string LastName { get; set; }

        [Column("Title")]
        [Required]
        [StringLength(30, ErrorMessage ="Title must be less than 30 characters")]
        public string Title { get; set; }

        [Display(Name ="Birth Date")]
        [Required(ErrorMessage ="Birth Date is required")]
        public DateTime BirthDate { get; set; }

        [Display(Name ="Hire Date")]
        [Required(ErrorMessage ="Hire Date is required")]
        public DateTime HireDate { get; set; }

        [StringLength(50, ErrorMessage ="Country must be less than 50 characters")]
        [Required(ErrorMessage ="Country is required")]
        public string Country { get; set; }

        [StringLength(500, ErrorMessage ="Notes must be less than 500 characters")]
        public string Notes { get; set; }

    }
}
