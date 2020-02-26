namespace DatabaseEntity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Reflection.Emit;

    public partial class dbs : DbContext
    {
        public dbs()
            : base("dbconn")
        {
        }

        public virtual DbSet<Tenent> Tenents { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Lookup> Lookups { get; set; }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Tenent>()
                .HasIndex(u => u.ClientId)
                .IsUnique();
        }
    }
}
