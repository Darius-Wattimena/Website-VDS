using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NederlandsWebsiteVDS.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public DateTime DataAdded { get; set; }
        public DateTime DateEdit { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(): base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Categorie> Categorie { get; set; } 
        public DbSet<Onderwerp> Onderwerp { get; set; }
        public DbSet<Opdracht> Opdracht { get; set; }
        public DbSet<Uitleg> Uitleg { get; set; }
        public DbSet<Link> Link { get; set; }
        public DbSet<Vraag> Vraag { get; set; }
        public DbSet<Antwoord> Antwoord { get; set; } 

    }
}