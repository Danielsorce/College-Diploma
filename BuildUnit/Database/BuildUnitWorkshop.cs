using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BuildUnit
{
    public partial class BuildUnitWorkshop : DbContext
    {
        public BuildUnitWorkshop()
            : base("name=BuildUnitInWorkshop")
        {
        }

        public virtual DbSet<Build> Builds { get; set; }
        public virtual DbSet<ConstructionDocument> ConstructionDocuments { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<ImagePath> ImagePaths { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ShiftAndDailyTask> ShiftAndDailyTasks { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TypeOfWork> TypeOfWorks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImagePath>()
                .HasMany(e => e.ConstructionDocuments)
                .WithOptional(e => e.ImagePath)
                .HasForeignKey(e => e.blueprintImage)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.ShiftAndDailyTasks)
                .WithRequired(e => e.Staff)
                .HasForeignKey(e => e.Employeer);

            modelBuilder.Entity<Task>()
                .HasOptional(e => e.ShiftAndDailyTask)
                .WithRequired(e => e.Task)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TypeOfWork>()
                .HasMany(e => e.ShiftAndDailyTasks)
                .WithRequired(e => e.TypeOfWork1)
                .HasForeignKey(e => e.typeOfWork);
        }
    }
}
