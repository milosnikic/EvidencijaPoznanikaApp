using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EvidencijaPoznanika.API.Models
{
    public partial class EvidencijaPoznanikaContext : DbContext
    {
        public EvidencijaPoznanikaContext()
        {
        }

        public EvidencijaPoznanikaContext(DbContextOptions<EvidencijaPoznanikaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CaptureOutputLog> CaptureOutputLog { get; set; }
        public virtual DbSet<Osoba> Osoba { get; set; }
        public virtual DbSet<PrivateAssertEqualsTableSchemaActual> PrivateAssertEqualsTableSchemaActual { get; set; }
        public virtual DbSet<PrivateAssertEqualsTableSchemaExpected> PrivateAssertEqualsTableSchemaExpected { get; set; }
        public virtual DbSet<PrivateConfigurations> PrivateConfigurations { get; set; }
        public virtual DbSet<PrivateExpectException> PrivateExpectException { get; set; }
        public virtual DbSet<PrivateNewTestClassList> PrivateNewTestClassList { get; set; }
        public virtual DbSet<PrivateNullCellTable> PrivateNullCellTable { get; set; }
        public virtual DbSet<PrivateRenamedObjectLog> PrivateRenamedObjectLog { get; set; }
        public virtual DbSet<PrivateSysIndexes> PrivateSysIndexes { get; set; }
        public virtual DbSet<PrivateSysTypes> PrivateSysTypes { get; set; }
        public virtual DbSet<Punoletni> Punoletni { get; set; }
        public virtual DbSet<RunLastExecution> RunLastExecution { get; set; }
        public virtual DbSet<Smederevci> Smederevci { get; set; }
        public virtual DbSet<TestClasses> TestClasses { get; set; }
        public virtual DbSet<TestMessage> TestMessage { get; set; }
        public virtual DbSet<TestResult> TestResult { get; set; }
        public virtual DbSet<Tests> Tests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DEV-MILOSNI;Database=EvidencijaPoznanika;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaptureOutputLog>(entity =>
            {
                entity.ToTable("CaptureOutputLog", "tSQLt");
            });

            modelBuilder.Entity<Osoba>(entity =>
            {
                entity.HasIndex(e => e.MaticniBroj)
                    .HasName("Maticni_broj_Unique")
                    .IsUnique();

                entity.Property(e => e.Adresa).HasMaxLength(50);

                entity.Property(e => e.BojaOciju)
                    .HasColumnName("Boja_ociju")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaticniBroj)
                    .IsRequired()
                    .HasColumnName("Maticni_broj")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prebivaliste)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rodjendan)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Telefon).HasMaxLength(50);
            });

            modelBuilder.Entity<PrivateAssertEqualsTableSchemaActual>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Private_AssertEqualsTableSchema_Actual", "tSQLt");

                entity.Property(e => e.CollationName)
                    .HasColumnName("collation_name")
                    .HasMaxLength(256);

                entity.Property(e => e.IsIdentity).HasColumnName("is_identity");

                entity.Property(e => e.IsNullable).HasColumnName("is_nullable");

                entity.Property(e => e.MaxLength).HasColumnName("max_length");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(256);

                entity.Property(e => e.Precision).HasColumnName("precision");

                entity.Property(e => e.RankColumnId).HasColumnName("RANK(column_id)");

                entity.Property(e => e.Scale).HasColumnName("scale");

                entity.Property(e => e.SystemTypeId).HasColumnName("system_type_id");

                entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");
            });

            modelBuilder.Entity<PrivateAssertEqualsTableSchemaExpected>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Private_AssertEqualsTableSchema_Expected", "tSQLt");

                entity.Property(e => e.CollationName)
                    .HasColumnName("collation_name")
                    .HasMaxLength(256);

                entity.Property(e => e.IsIdentity).HasColumnName("is_identity");

                entity.Property(e => e.IsNullable).HasColumnName("is_nullable");

                entity.Property(e => e.MaxLength).HasColumnName("max_length");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(256);

                entity.Property(e => e.Precision).HasColumnName("precision");

                entity.Property(e => e.RankColumnId).HasColumnName("RANK(column_id)");

                entity.Property(e => e.Scale).HasColumnName("scale");

                entity.Property(e => e.SystemTypeId).HasColumnName("system_type_id");

                entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");
            });

            modelBuilder.Entity<PrivateConfigurations>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Private___737584F7916AED58");

                entity.ToTable("Private_Configurations", "tSQLt");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Value).HasColumnType("sql_variant");
            });

            modelBuilder.Entity<PrivateExpectException>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Private_ExpectException", "tSQLt");

                entity.Property(e => e.I).HasColumnName("i");
            });

            modelBuilder.Entity<PrivateNewTestClassList>(entity =>
            {
                entity.HasKey(e => e.ClassName)
                    .HasName("PK__Private___F8BF561A59D634C5");

                entity.ToTable("Private_NewTestClassList", "tSQLt");
            });

            modelBuilder.Entity<PrivateNullCellTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Private_NullCellTable", "tSQLt");
            });

            modelBuilder.Entity<PrivateRenamedObjectLog>(entity =>
            {
                entity.ToTable("Private_RenamedObjectLog", "tSQLt");

                entity.Property(e => e.OriginalName).IsRequired();
            });

            modelBuilder.Entity<PrivateSysIndexes>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Private_SysIndexes", "tSQLt");

                entity.Property(e => e.AllowPageLocks).HasColumnName("allow_page_locks");

                entity.Property(e => e.AllowRowLocks).HasColumnName("allow_row_locks");

                entity.Property(e => e.AutoCreated).HasColumnName("auto_created");

                entity.Property(e => e.CompressionDelay).HasColumnName("compression_delay");

                entity.Property(e => e.DataSpaceId).HasColumnName("data_space_id");

                entity.Property(e => e.FillFactor).HasColumnName("fill_factor");

                entity.Property(e => e.FilterDefinition).HasColumnName("filter_definition");

                entity.Property(e => e.HasFilter).HasColumnName("has_filter");

                entity.Property(e => e.IgnoreDupKey).HasColumnName("ignore_dup_key");

                entity.Property(e => e.IndexId).HasColumnName("index_id");

                entity.Property(e => e.IsDisabled).HasColumnName("is_disabled");

                entity.Property(e => e.IsHypothetical).HasColumnName("is_hypothetical");

                entity.Property(e => e.IsIgnoredInOptimization).HasColumnName("is_ignored_in_optimization");

                entity.Property(e => e.IsPadded).HasColumnName("is_padded");

                entity.Property(e => e.IsPrimaryKey).HasColumnName("is_primary_key");

                entity.Property(e => e.IsUnique).HasColumnName("is_unique");

                entity.Property(e => e.IsUniqueConstraint).HasColumnName("is_unique_constraint");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(128);

                entity.Property(e => e.ObjectId).HasColumnName("object_id");

                entity.Property(e => e.SuppressDupKeyMessages).HasColumnName("suppress_dup_key_messages");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.TypeDesc)
                    .HasColumnName("type_desc")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<PrivateSysTypes>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Private_SysTypes", "tSQLt");

                entity.Property(e => e.CollationName)
                    .HasColumnName("collation_name")
                    .HasMaxLength(128);

                entity.Property(e => e.DefaultObjectId).HasColumnName("default_object_id");

                entity.Property(e => e.IsAssemblyType).HasColumnName("is_assembly_type");

                entity.Property(e => e.IsNullable).HasColumnName("is_nullable");

                entity.Property(e => e.IsTableType).HasColumnName("is_table_type");

                entity.Property(e => e.IsUserDefined).HasColumnName("is_user_defined");

                entity.Property(e => e.MaxLength).HasColumnName("max_length");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(128);

                entity.Property(e => e.Precision).HasColumnName("precision");

                entity.Property(e => e.PrincipalId).HasColumnName("principal_id");

                entity.Property(e => e.RuleObjectId).HasColumnName("rule_object_id");

                entity.Property(e => e.Scale).HasColumnName("scale");

                entity.Property(e => e.SchemaId).HasColumnName("schema_id");

                entity.Property(e => e.SystemTypeId).HasColumnName("system_type_id");

                entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");
            });

            modelBuilder.Entity<Punoletni>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PUNOLETNI");

                entity.Property(e => e.Adresa).HasMaxLength(50);

                entity.Property(e => e.BojaOciju)
                    .HasColumnName("Boja_ociju")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaticniBroj)
                    .IsRequired()
                    .HasColumnName("Maticni_broj")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prebivaliste)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rodjendan).HasColumnType("datetime");

                entity.Property(e => e.Telefon).HasMaxLength(50);
            });

            modelBuilder.Entity<RunLastExecution>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Run_LastExecution", "tSQLt");

                entity.Property(e => e.LoginTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Smederevci>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SMEDEREVCI");

                entity.Property(e => e.Adresa).HasMaxLength(50);

                entity.Property(e => e.BojaOciju)
                    .HasColumnName("Boja_ociju")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaticniBroj)
                    .IsRequired()
                    .HasColumnName("Maticni_broj")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prebivaliste)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rodjendan).HasColumnType("datetime");

                entity.Property(e => e.Telefon).HasMaxLength(50);
            });

            modelBuilder.Entity<TestClasses>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TestClasses", "tSQLt");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<TestMessage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TestMessage", "tSQLt");
            });

            modelBuilder.Entity<TestResult>(entity =>
            {
                entity.ToTable("TestResult", "tSQLt");

                entity.Property(e => e.Class).IsRequired();

                entity.Property(e => e.Name)
                    .HasMaxLength(517)
                    .HasComputedColumnSql("((quotename([Class])+'.')+quotename([TestCase]))");

                entity.Property(e => e.TestCase).IsRequired();

                entity.Property(e => e.TestEndTime).HasColumnType("datetime");

                entity.Property(e => e.TestStartTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TranName).IsRequired();
            });

            modelBuilder.Entity<Tests>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Tests", "tSQLt");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.TestClassName)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
