using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.lib
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Roll Number")]
        [Display(Name  = "Roll Number")]
        public int RollNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Father Name")]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile Number")]
        [Phone(ErrorMessage = "Please Enter a Valid Phone Number")]
        [Display(Name = "Phone Number")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Semester")]
        [Range(1,8,ErrorMessage = "Please Enter Your Valid Semester between 1-8")]
        [Display(Name = "Current Semester")]
        public string Semester { get; set; }
    }
}
