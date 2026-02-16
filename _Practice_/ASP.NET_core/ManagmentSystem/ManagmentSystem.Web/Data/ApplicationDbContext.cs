using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ManagmentSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // To make aware that EF Core should know about below data madel which os representation of table that we wanted in the database
        //           data types      name of the table in db
        //                |             |
        public DbSet<LeaveType> LeaveTypes { get; set; }

        // After creating above we do next migration: add-migration AddLeaveTypesTable

        // If we do any changes on Model we need to remove migration and again update the database: Remove-Migration

        // and then add the LeaveTypes table to database: update-database
    }
}
