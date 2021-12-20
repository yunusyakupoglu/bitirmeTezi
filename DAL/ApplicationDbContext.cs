using DAL.Configurations;
using Microsoft.EntityFrameworkCore;
using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ObjAppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ObjAppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ObjAppUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ObjAppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ObjBlogAppUserStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ObjBlogConfiguration());
            modelBuilder.ApplyConfiguration(new ObjVideoConfiguration());
            modelBuilder.ApplyConfiguration(new ObjAdvertisementConfiguration());
            modelBuilder.ApplyConfiguration(new ObjPresentationConfiguration());
            modelBuilder.ApplyConfiguration(new ObjDocumentaryConfiguration());
            modelBuilder.ApplyConfiguration(new ObjBreadCrumbConfiguration());
            modelBuilder.ApplyConfiguration(new ObjCounterConfiguration());
            modelBuilder.ApplyConfiguration(new ObjLinkConfiguration());
        }

        public DbSet<ObjAppRole> objAppRoles { get; set; }
        public DbSet<ObjAppUser> objAppUsers { get; set; }
        public DbSet<ObjAppUserRole> objAppUserRoles { get; set; }
        public DbSet<ObjBlog> objBlogs { get; set; }
        public DbSet<ObjBlogAppUser> blogAppUsers { get; set; }
        public DbSet<ObjBlogAppUserStatus> blogAppUserStatuses { get; set; }
        public DbSet<ObjVideo> objVideos { get; set; }
        public DbSet<ObjAdvertisement> objAdvertisements { get; set; }
        public DbSet<ObjPresentation> objPresentations { get; set; }
        public DbSet<ObjDocumentary> objDocumentaries { get; set; }
        public DbSet<ObjBreadCrumb> objBreadCrumbs { get; set; }
        public DbSet<ObjCounter> objCounters { get; set; }
        public DbSet<ObjLink> objLinks { get; set; }
    }
}
