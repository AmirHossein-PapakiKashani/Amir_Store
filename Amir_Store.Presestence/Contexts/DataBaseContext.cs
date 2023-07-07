using Amir_Store.Domain.Entities.Users;
using Amir_Store.Common.Roles;
using Amir_Store.Application.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amir_Store.Domain.Entities.Products;

namespace Amir_Store.Persistence.Contexts { 

    public class DataBaseContext : DbContext, Amir_Store.Application.Interfaces.Context.IDataBaseContext


    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UsersInRoles { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //افزودن مقادیر پیشفرض به جدول Roles
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(UserRoles.Customer) });


            //اعمال ایندکس بر روی فیلد ایمیل
            // اعمال عدم تکراری بودن ایمیل
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();


            //--

            //modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
        }





    }
    


}
