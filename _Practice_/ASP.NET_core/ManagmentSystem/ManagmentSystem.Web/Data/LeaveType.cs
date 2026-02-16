using System.ComponentModel.DataAnnotations.Schema;

namespace ManagmentSystem.Web.Data
{
    public class LeaveType
    {
        /*
            To let EF Core know that it's primary key there are couple of ways: 
            * use PascalCase for primary key
            * also we can put prefix for it like so "int LeaveTypeId"
            * we can do outside of the EF Core framework, but then we need use data annotation/attribute to let EF Core know that this is primary key:
            
              [Key]
              public int leavetype_id { get; set; }
         */

        // Creating data model
        public int Id { get; set; } // primary key
        [Column(TypeName = "nvarchar(150)")] // selecting the type of the string as without it the EF Core is selecting it at max
        public string Name { get; set; }
        public int NumbersOfDays { get; set; }
    }
}
