using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.Entity.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Concrete.EfCore.Extensions
{
    public static class ModelBu_lderExtensions
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
                #region Psychologist
                    new User{Id="8da007be-c50b-4973-aa45-224b7358hkn15",FirstName="Selvi", LastName="Kartal", UserName="selvi", NormalizedUserName="SELVI", Email="selvi@gmail.com", NormalizedEmail="SELVI@GMAIL.COM", DateOfBirth=new DateTime(1978,5,2), EmailConfirmed=true,NormalizedName="SELVIKARTAL" ,Type=(EnumType)1},

                 new User{Id="a20b74f2-9d2c-47ee-bf20-13a75c6tpr62",FirstName="Zeynep", LastName="Öztürk", UserName="zeynep", NormalizedUserName="ZEYNEP", Email="zeynep@gmail.com", NormalizedEmail="ZEYNEP@GMAIL.COM", DateOfBirth=new DateTime(1978,5,2), EmailConfirmed=true,NormalizedName="ZEYNEPOZTURK" ,Type=(EnumType)1},

                 new User{Id="a5e1a9e5-5d05-4487-9945-43d2ff1kgd34",FirstName="Merve", LastName="Kara", UserName="merve", NormalizedUserName="MERVE", Email="merve@gmail.com", NormalizedEmail="MERVE@GMAIL.COM", DateOfBirth=new DateTime(1978,5,2), EmailConfirmed=true,NormalizedName="MERVEKARA" ,Type=(EnumType)1},

                 new User{Id="s8e3a9e7-5K05-4487-9945-43d2ff1kgd34",FirstName="Aslı", LastName="Yaman", UserName="aslı", NormalizedUserName="ASLI", Email="aslı@gmail.com", NormalizedEmail="ASLI@GMAIL.COM", DateOfBirth=new DateTime(1978,5,2), EmailConfirmed=true,NormalizedName="ASLIYAMAN" ,Type=(EnumType)1},

                 new User{Id="n6R1a9e5-5d05-4487-9945-43d2ff1L5gd34",FirstName="Aylin", LastName="Uzar", UserName="aylin", NormalizedUserName="AYLIN", Email="aylin@gmail.com", NormalizedEmail="AYLIN@GMAIL.COM", DateOfBirth=new DateTime(1978,5,2), EmailConfirmed=true,NormalizedName="AYLINUZAR" ,Type=(EnumType)1},



                   new User{Id="b342e19c-42af-4f25-b820-7a07dc9mbf13",FirstName="Ali", LastName="Yılmaz", UserName="ali", NormalizedUserName="ALI", Email="ali@gmail.com", NormalizedEmail="ALI@GMAIL.COM", DateOfBirth=new DateTime(1978,5,2), EmailConfirmed=true,NormalizedName="ALIYILMAZ" ,Type=(EnumType)1},

                   new User{Id="b35f20c1-836f-49c1-b46f-2399e12pvc85",FirstName="Cem", LastName="Kar", UserName="cem", NormalizedUserName="CEM", Email="cem@gmail.com", NormalizedEmail="CEM@GMAIL.COM", DateOfBirth=new DateTime(1978,5,2), EmailConfirmed=true,NormalizedName="CEMKAR" ,Type=(EnumType)1},

                   new User{Id="9e8f345d-141f-4ef2-99c7-8a9476llh93",FirstName="Ahmet", LastName="Ovalı", UserName="ahmet", NormalizedUserName="AHMET", Email="ahmet@gmail.com", NormalizedEmail="AHMET@GMAIL.COM", DateOfBirth=new DateTime(1978,5,2), EmailConfirmed=true,NormalizedName="AHMETOVALI" ,Type=(EnumType)1},

                    new User{Id="b342e25a-42af-4f25-b820-7a07dc9mbf13",FirstName="Emre", LastName="Ateş", UserName="emre", NormalizedUserName="EMRE", Email="emre@gmail.com", NormalizedEmail="EMRE@GMAIL.COM", DateOfBirth=new DateTime(1978,5,2), EmailConfirmed=true,NormalizedName="EMREATES" ,Type=(EnumType)1},

                    new User{Id="5bcf4a7a-4b4d-4c9a-a582-6230f635mnb21",FirstName="Barış", LastName="Durmuş", UserName="barıs", NormalizedUserName="BARIS", Email="baris@gmail.com", NormalizedEmail="BARIS@GMAIL.COM", DateOfBirth=new DateTime(1978,5,2), EmailConfirmed=true,NormalizedName="BARISDURMUS" ,Type=(EnumType)1},
                #endregion
                #region Customer
                     new User{Id="eabb7e42-6e53-4696-b350-da56Or2c79fa",FirstName="Canan", LastName="Umaç", UserName="canan", NormalizedUserName="CANAN", Email="canan@gmail.com", NormalizedEmail="CANAN@GMAIL.COM", DateOfBirth=new DateTime(1978,5,2), EmailConfirmed=true,NormalizedName="CANANUMAC" ,Type=(EnumType)2},

                     new User{Id="eabb7e42-6e53-4696-b350-da64de2c79fa",FirstName="Ömer", LastName="Akyüz", UserName="ömer", NormalizedUserName="OMER", Email="omer@gmail.com", NormalizedEmail="OMER@GMAIL.COM", DateOfBirth=new DateTime(1978,5,2), EmailConfirmed=true,NormalizedName="OMERAKYUZ" ,Type=(EnumType)2},

                     new User{Id="a1f6faa1-645c-4ce9-98ce-939a4d1e1b7f",FirstName="Mehmet", LastName="Tatlı", UserName="-mehmet", NormalizedUserName="MEHMET", Email="mehmet@gmail.com", NormalizedEmail="MEHMET@GMAIL.COM", DateOfBirth=new DateTime(1978,5,2), EmailConfirmed=true,NormalizedName="MEHMETTATLI" ,Type=(EnumType)2},
                #endregion
                #region Admin
                 new User{Id="kema7e42-6e53-4696-b350-ke56Or2c79fa",FirstName="Semanur", LastName="Yıldırım", UserName="semanur", NormalizedUserName="SEMANUR", Email="semanur@gmail.com", NormalizedEmail="SEMANUR@GMAIL.COM", DateOfBirth=new DateTime(1978,5,2), EmailConfirmed=true,NormalizedName="SEMANURYILDIRIM" ,Type=0},
            	#endregion
            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion

            #region Customer
            List<Customer> customers = new List<Customer>
            {
                new Customer { Id = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Ahmet", Url = "ahmet-hasta", userId = users[10].Id ,Address="Armağan evler mahallesi 23 Nisan Caddesi no:37 Daire:4"},

                new Customer { Id = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Ömer", Url = "omer-hasta", userId = users[11].Id, Address = "Güzelbahçe mahallesi Kumsal sokak no:13" },

                new Customer { Id = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Mehmet", Url = "mehmet-hasta", userId = users[12].Id, Address = "Karşıyaka mahallesi Yalı Caddesi no:27 Daire:5"}
            };
            modelBuilder.Entity<Customer>().HasData(customers);

            #endregion
            #region Psychologist
            List<Psychologist> psychologists = new List<Psychologist>
            {
                 new Psychologist { Id = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = false, Name = "Selvi",  Price = 450, Url = "Selvi-psikolog", Gender="Kadın",userId= users[0].Id },

                 new Psychologist { Id = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = false, Name = "Zeynep", Price = 350, Url = "zeynep-psikolog", Gender="Kadın",userId= users[1].Id },

                new Psychologist { Id = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = false, Name = "Merve", Price = 400, Url = "merve-psikolog", Gender="Kadın",userId=users[2].Id },

                new Psychologist { Id = 4, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = false, Name = "Aslı", Price = 450, Url = "asli-psikolog", Gender="Kadın",userId= users[3].Id },

                new Psychologist { Id = 5, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = false, Name = "Aylin", Price = 350, Url = "aylin-psikolog", Gender="Kadın",userId= users[4].Id },


                new Psychologist { Id = 6, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = false, Name = "Ali", Price = 500, Url = "ali-psikolog", Gender="Erkek",userId= users[5].Id},
                new Psychologist { Id = 7, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Cem", Price = 400, Url = "cem-psikolog", Gender="Erkek",userId= users[6].Id },
                new Psychologist { Id = 8, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Ahmet", Price = 350, Url = "ahmet-psikolog", Gender="Erkek",userId= users[7].Id },
                 new Psychologist { Id = 9, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Emre", Price = 350, Url = "emre-psikolog", Gender="Erkek",userId= users[8].Id },
                 new Psychologist { Id = 10, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Barış", Price = 350, Url = "barıs-psikolog", Gender="Erkek",userId= users[9].Id }

            };
            modelBuilder.Entity<Psychologist>().HasData(psychologists);

            #endregion

            #region Parola İşlemleri
            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[1].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[2].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[3].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[4].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[5].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[6].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[7].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[8].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[9].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[10].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[11].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[12].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[13].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            #endregion

            #region Rol Atama İşlemleri
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>{ UserId=users[0].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Psychologist").Id},
                new IdentityUserRole<string>{ UserId=users[1].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Psychologist").Id},
                new IdentityUserRole<string>{ UserId=users[2].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Psychologist").Id},
                new IdentityUserRole<string>{ UserId=users[3].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Psychologist").Id},
                new IdentityUserRole<string>{ UserId=users[4].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Psychologist").Id},
                new IdentityUserRole<string>{ UserId=users[5].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Psychologist").Id},
                new IdentityUserRole<string>{ UserId=users[6].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Psychologist").Id},
                new IdentityUserRole<string>{ UserId=users[7].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Psychologist").Id},
                new IdentityUserRole<string>{ UserId=users[8].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Psychologist").Id},
                new IdentityUserRole<string>{ UserId=users[9].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Psychologist").Id},

                new IdentityUserRole<string>{ UserId=users[10].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Customer").Id},
                new IdentityUserRole<string>{ UserId=users[11].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Customer").Id},
                new IdentityUserRole<string>{ UserId=users[12].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Customer").Id},

                new IdentityUserRole<string>{ UserId=users[13].Id, RoleId=roles.FirstOrDefault(r=>r.Name=="Admin").Id}
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion

            #region Alışveriş Sepeti İşlemleri
            List<Cart> carts = new List<Cart>
            {
                new Cart{Id=1, UserId=users[0].Id},
                new Cart{Id=2, UserId=users[1].Id},
                new Cart{Id=3, UserId=users[2].Id},
                new Cart{Id=4, UserId=users[3].Id},
                new Cart{Id=5, UserId=users[4].Id},
                new Cart{Id=6, UserId=users[5].Id},
                new Cart{Id=7, UserId=users[6].Id},
                new Cart{Id=8, UserId=users[7].Id},
                new Cart{Id=9, UserId=users[8].Id},
                new Cart{Id=10, UserId=users[9].Id},
                new Cart{Id=11, UserId=users[10].Id},
                new Cart{Id=12, UserId=users[11].Id},
                new Cart{Id=13, UserId=users[12].Id},
                new Cart{Id=14, UserId=users[13].Id}
            };
            modelBuilder.Entity<Cart>().HasData(carts);
            #endregion

        }
    }
}
