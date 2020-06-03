using FirstPakWebApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FirstPakWebApi.Data
{
    public class FirstPakDbContext:DbContext
    {
        public FirstPakDbContext(DbContextOptions<FirstPakDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasMany(x=>x.EmployeeInfos).WithOne(x=>x.Department).HasForeignKey(e=>e.DepartmentId).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Position>().HasMany(x => x.EmployeeInfos).WithOne(x => x.Position).HasForeignKey(e => e.PositionId).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<User>().HasMany(x => x.EmployeeInfos).WithOne(x => x.User).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<EmployeeInfo>().HasMany(x => x.Departments).WithOne(x => x.EmployeeInfo).HasForeignKey(e => e.PrincipalId).OnDelete(DeleteBehavior.SetNull);
           
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<MenuRole> MenuRoles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<EmployeeInfo> EmployeeInfos { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
    }
}
