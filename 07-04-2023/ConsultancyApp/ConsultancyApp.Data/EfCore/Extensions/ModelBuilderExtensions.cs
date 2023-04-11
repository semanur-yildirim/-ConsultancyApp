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
                new Role{Name="Customer", Description="Kullanıcılar", NormalizedName="Customer"},
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
            #region Psychologist
            List<Psychologist> psychologists = new List<Psychologist>
            {
                 new Psychologist { Id = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Selvi",  Price = 450, Url = "Selvi-psikolog", Gender="Kadın",userId= "8da007be-c50b-4973-aa45-224b7358hkn15" },

                 new Psychologist { Id = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Zeynep", Price = 350, Url = "zeynep-psikolog", Gender="Kadın",userId= "a20b74f2-9d2c-47ee-bf20-13a75c6tpr62" },
                new Psychologist { Id = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Merve", Price = 400, Url = "merve-psikolog", Gender="Kadın",userId= "6d091b6c-6b61-4b37-9d9d-9df0566sbv42" },
                new Psychologist { Id = 4, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Aslı", Price = 450, Url = "asli-psikolog", Gender="Kadın",userId= "a5e1a9e5-5d05-4487-9945-43d2ff1kgd34" },
                new Psychologist { Id = 5, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Ali", Price = 500, Url = "ali-psikolog", Gender="Erkek",userId= "b342e19c-42af-4f25-b820-7a07dc9mbf13" },
                new Psychologist { Id = 6, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Aylin", Price = 350, Url = "aylin-psikolog", Gender="Kadın",userId= "2b1db9c9-cd8e-476e-a289-886fd84azh24" },
                new Psychologist { Id = 7, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Cem", Price = 400, Url = "cem-psikolog", Gender="Erkek",userId= "b35f20c1-836f-49c1-b46f-2399e12pvc85" },
                new Psychologist { Id = 8, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Burcu", Price = 350, Url = "burcu-psikolog", Gender="Kadın",userId= "9e8f345d-141f-4ef2-99c7-8a9476llh93" },
                 new Psychologist { Id = 9, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Nazlı", Price = 350, Url = "nazli-psikolog", Gender="Kadın",userId= "1ab0e5e7-6f81-4d8e-a4e4-9de4c31b92ba" },
                 new Psychologist { Id = 10, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Ebru", Price = 350, Url = "ebru-psikolog", Gender="Kadın",userId= "5bcf4a7a-4b4d-4c9a-a582-6230f635mnb21" }
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
                new IdentityUserRole<string>{ UserId=users[3].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Customer").Id}

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
