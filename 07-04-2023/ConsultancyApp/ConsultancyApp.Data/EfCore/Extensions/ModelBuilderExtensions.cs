using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.Entity.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.EfCore.Extensions
{
    public  static class ModelBu_lderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region Rol bilgileri
            List<Role> roles = new List<Role>
            {
                new Role{Name="Admin", Description="Yöneticiler", NormalizedName="ADMIN"},
                new Role{Name="User", Description="Kullanıcılar", NormalizedName="USER"},
                new Role{Name="Psychologist", Description="Psikologlar", NormalizedName="PSYCHOLOGIST"},
            };
            modelBuilder.Entity<Role>().HasData(roles);

            #endregion
            #region Kullanıcı Bilgileri
            List<User> users = new List<User>
            {
                 new User{FirstName="Selvi", LastName="Kartal", UserName="selvi", NormalizedUserName="SELVI", Email="selvi@gmail.com", NormalizedEmail="SELVI@GMAIL.COM", DateOfBirth=new DateTime(1978,5,2), EmailConfirmed=true,NormalizedName="SELVIKARTAL" ,Type=(EnumType)1},
                  new User{FirstName="Emma", LastName="Deniz", UserName="emma", NormalizedUserName="EMMA", Email="emma@gmail.com", NormalizedEmail="EMMA@GMAIL.COM", DateOfBirth=new DateTime(1978,5,2), EmailConfirmed=true,NormalizedName="EMMADENIZ" ,Type=(EnumType)1},

                  new User{FirstName="Sema", LastName="Yıldırım", UserName="sema", NormalizedUserName="SEMA", Email="sema@gmail.com", NormalizedEmail="SEMA@GMAIL.COM", DateOfBirth=new DateTime(1978,5,2), EmailConfirmed=true,NormalizedName="SEMAYILDIRIM" ,Type=(EnumType)0},

                   new User{FirstName="Selin", LastName="Kara", UserName="selin", NormalizedUserName="SELIN", Email="selin@gmail.com", NormalizedEmail="SELIN@GMAIL.COM", DateOfBirth=new DateTime(1978,5,2), EmailConfirmed=true,NormalizedName="SELINKARA" ,Type=(EnumType)2},
            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion

            #region Customer
            List<Customer> customers = new List<Customer>
            {
                new Customer { Id = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Ahmet", Url = "ahmet-hasta", userId = "a5f6faa1-645c-4ce9-88ce-939a4d1e1b7f" ,Address="Armağan evler mahallesi 23 Nisan Caddesi no:37 Daire:4",PsychologistId=1},
                new Customer { Id = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Selin", Url = "selin-hasta", userId = "eabb7e42-6e53-4696-b350-da64de2c79fa", Address = "Güzelbahçe mahallesi Kumsal sokak no:13", PsychologistId = 2 },
                new Customer { Id = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Mehmet", Url = "mehmet-hasta", userId = "8da007be-c50b-4973-aa45-224b7368d185", Address = "Karşıyaka mahallesi Yalı Caddesi no:27 Daire:5", PsychologistId = 3 }
            };
            #endregion
            #region Parola İşlemleri

            var passwordHasher =new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0],"Qwe123.");

            users[1].PasswordHash = passwordHasher.HashPassword(users[1],"Qwe123.");

            users[2].PasswordHash = passwordHasher.HashPassword(users[2],"Qwe123.");
            #endregion
            #region Rol Atama İşlemleri
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>{ UserId=users[0].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Psychologist").Id},
                new IdentityUserRole<string>{ UserId=users[1].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Psychologist").Id},
                new IdentityUserRole<string>{ UserId=users[2].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Admin").Id},
                new IdentityUserRole<string>{ UserId=users[3].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="User").Id}

            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion

            #region Alışveriş Sepeti İşlemleri
            List<Cart> carts = new List<Cart>
            {
                new Cart{Id=1, UserId=users[0].Id},
                new Cart{Id=2, UserId=users[1].Id},
                new Cart{Id=3, UserId=users[2].Id},
                new Cart{Id=4, UserId=users[3].Id}
            };
            modelBuilder.Entity<Cart>().HasData(carts);
            #endregion


        }
    }
}
