using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IT2030_Lab13_MovieStore.Models
{
    public class IT2030_Lab13_MovieStoreDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public IT2030_Lab13_MovieStoreDbContext() : base("name=IT2030_Lab13_MovieStoreDbContext")
        {
        }

        public virtual System.Data.Entity.DbSet<IT2030_Lab13_MovieStore.Models.Movie> Movies { get; set; }  // This needs to be virtual for 
                                                                                                            // Moq to work!!!
    }
}
