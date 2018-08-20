using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Wbod.Models.DB
{
    public partial class WbodContext : IdentityDbContext<AppUser>
    {
        public virtual DbSet<Aspnetroleclaims> Aspnetroleclaims { get; set; }
        public virtual DbSet<Aspnetroles> Aspnetroles { get; set; }
        public virtual DbSet<Aspnetuserclaims> Aspnetuserclaims { get; set; }
        public virtual DbSet<Aspnetuserlogins> Aspnetuserlogins { get; set; }
        public virtual DbSet<Aspnetuserroles> Aspnetuserroles { get; set; }
        public virtual DbSet<Aspnetusers> Aspnetusers { get; set; }
        public virtual DbSet<Aspnetusertokens> Aspnetusertokens { get; set; }
        public virtual DbSet<Audit> Audit { get; set; }
        public virtual DbSet<Citizenshiptable> Citizenshiptable { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Companylists> Companylists { get; set; }
        public virtual DbSet<Companysectors> Companysectors { get; set; }
        public virtual DbSet<Companytypes> Companytypes { get; set; }
        public virtual DbSet<Currentdirpositionone> Currentdirpositionone { get; set; }
        public virtual DbSet<Currentdirpositiontwo> Currentdirpositiontwo { get; set; }
        public virtual DbSet<Cweacadtable> Cweacadtable { get; set; }
        public virtual DbSet<Cwegovtable> Cwegovtable { get; set; }
        public virtual DbSet<Cwenonplctable> Cwenonplctable { get; set; }
        public virtual DbSet<Cweplctable> Cweplctable { get; set; }
        public virtual DbSet<Directoraudit> Directoraudit { get; set; }
        public virtual DbSet<Directornom> Directornom { get; set; }
        public virtual DbSet<Directorrenum> Directorrenum { get; set; }
        public virtual DbSet<Directoresos> Directoresos { get; set; }
        public virtual DbSet<Directorrisk> Directorrisk { get; set; }
        public virtual DbSet<Directorexec> Directorexec { get; set; }
        public virtual DbSet<Directortender> Directortender { get; set; }
        public virtual DbSet<Directorfinance> Directorfinance { get; set; }
        public virtual DbSet<Directors> Directors { get; set; }
        public virtual DbSet<Directorship> Directorship { get; set; }
        public virtual DbSet<Dshipraw> Dshipraw { get; set; }
        public virtual DbSet<Educationlevel> Educationlevel { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Ethnicitytable> Ethnicitytable { get; set; }
        public virtual DbSet<Familytiesonetable> Familytiesonetable { get; set; }
        public virtual DbSet<Familytiestwotable> Familytiestwotable { get; set; }
        public virtual DbSet<Fieldofstudiestable> Fieldofstudiestable { get; set; }
        public virtual DbSet<Fieldofstudiestable2> Fieldofstudiestable2 { get; set; }
        public virtual DbSet<Gendertable> Gendertable { get; set; }
        public virtual DbSet<Glcstatus> Glcstatus { get; set; }
        public virtual DbSet<Placeofeducationtable> Placeofeducationtable { get; set; }
        public virtual DbSet<Professionalbodytable> Professionalbodytable { get; set; }
        public virtual DbSet<Sectortable> Sectortable { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<Titletable> Titletable { get; set; }
        public virtual DbSet<Voluntarybodytable> Voluntarybodytable { get; set; }

        public WbodContext(DbContextOptions<WbodContext> options)
: base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Aspnetroleclaims>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetroles>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<Aspnetuserclaims>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserlogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserroles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusers>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Aspnetusertokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.ToTable("aspnetusertokens");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Audit>(entity =>
            {
                entity.ToTable("audit");

                entity.Property(e => e.AuditId)
                    .HasColumnName("AuditID")
                    .HasColumnType("char(16)");

                entity.Property(e => e.AreaAccessed).HasMaxLength(100);

                entity.Property(e => e.Ipaddress)
                    .HasColumnName("IPAddress")
                    .HasMaxLength(100);

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<Citizenshiptable>(entity =>
            {
                entity.ToTable("citizenshiptable");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Citizentype)
                    .IsRequired()
                    .HasColumnName("citizentype")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.ToTable("companies");

                entity.HasIndex(e => e.Companylist)
                    .HasName("FK_companylist");

                entity.HasIndex(e => e.Companysector)
                    .HasName("FK_companysector");

                entity.HasIndex(e => e.Companytype)
                    .HasName("FK_companytype");

                entity.HasIndex(e => e.Isglc)
                    .HasName("FK_glc");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Companyboardsize)
                    .HasColumnName("companyboardsize")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Companyisactive)
                    .HasColumnName("companyisactive")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Companylist)
                    .HasColumnName("companylist")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasColumnName("companyname")
                    .HasMaxLength(450);

                entity.Property(e => e.Companysector)
                    .HasColumnName("companysector")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Companytype)
                    .HasColumnName("companytype")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Isglc)
                    .HasColumnName("isglc")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CompanylistNavigation)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.Companylist)
                    .HasConstraintName("FK_companylist");

                entity.HasOne(d => d.CompanysectorNavigation)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.Companysector)
                    .HasConstraintName("FK_companysector");

                entity.HasOne(d => d.CompanytypeNavigation)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.Companytype)
                    .HasConstraintName("FK_companytype");

                entity.HasOne(d => d.IsglcNavigation)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.Isglc)
                    .HasConstraintName("FK_glc");
            });

            modelBuilder.Entity<Companylists>(entity =>
            {
                entity.ToTable("companylists");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Companylistsname)
                    .IsRequired()
                    .HasColumnName("companylistsname")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Companysectors>(entity =>
            {
                entity.ToTable("companysectors");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Sectornames)
                    .IsRequired()
                    .HasColumnName("sectornames")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Companytypes>(entity =>
            {
                entity.ToTable("companytypes");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Typenames)
                    .IsRequired()
                    .HasColumnName("typenames")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Currentdirpositionone>(entity =>
            {
                entity.ToTable("currentdirpositionone");

                entity.HasIndex(e => e.Id)
                    .HasName("currentdirpositionone_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Positiontype)
                    .IsRequired()
                    .HasColumnName("positiontype")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Currentdirpositiontwo>(entity =>
            {
                entity.ToTable("currentdirpositiontwo");

                entity.HasIndex(e => e.Id)
                    .HasName("currentdirpositiontwo_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Positiontype)
                    .IsRequired()
                    .HasColumnName("positiontype")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Cweacadtable>(entity =>
            {
                entity.ToTable("cweacadtable");

                entity.HasIndex(e => e.Id)
                    .HasName("cweacad_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Positiontype)
                    .IsRequired()
                    .HasColumnName("positiontype")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Cwegovtable>(entity =>
            {
                entity.ToTable("cwegovtable");

                entity.HasIndex(e => e.Id)
                    .HasName("cwegovt_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Positiontype)
                    .IsRequired()
                    .HasColumnName("positiontype")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Cwenonplctable>(entity =>
            {
                entity.ToTable("cwenonplctable");

                entity.HasIndex(e => e.Id)
                    .HasName("cwenonplc_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Positiontype)
                    .IsRequired()
                    .HasColumnName("positiontype")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Cweplctable>(entity =>
            {
                entity.ToTable("cweplctable");

                entity.HasIndex(e => e.Id)
                    .HasName("cweplc_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Positiontype)
                    .IsRequired()
                    .HasColumnName("positiontype")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Directoraudit>(entity =>
            {
                entity.ToTable("directoraudit");

                entity.HasIndex(e => e.Id)
                    .HasName("directoraudit_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Positiontype)
                    .IsRequired()
                    .HasColumnName("positiontype")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Directornom>(entity =>
            {
                entity.ToTable("directornom");

                entity.HasIndex(e => e.Id)
                    .HasName("directoraudit_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Positiontype)
                    .IsRequired()
                    .HasColumnName("positiontype")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Directorrenum>(entity =>
            {
                entity.ToTable("directorrenum");

                entity.HasIndex(e => e.Id)
                    .HasName("directoraudit_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Positiontype)
                    .IsRequired()
                    .HasColumnName("positiontype")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Directoresos>(entity =>
            {
                entity.ToTable("directoresos");
                

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Positiontype)
                    .IsRequired()
                    .HasColumnName("positiontype")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Directorrisk>(entity =>
            {
                entity.ToTable("directorrisk");


                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Positiontype)
                    .IsRequired()
                    .HasColumnName("positiontype")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Directorexec>(entity =>
            {
                entity.ToTable("directorexec");


                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Positiontype)
                    .IsRequired()
                    .HasColumnName("positiontype")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Directortender>(entity =>
            {
                entity.ToTable("directortender");


                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Positiontype)
                    .IsRequired()
                    .HasColumnName("positiontype")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Directorfinance>(entity =>
            {
                entity.ToTable("directorfinance");


                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Positiontype)
                    .IsRequired()
                    .HasColumnName("positiontype")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Directors>(entity =>
            {
                entity.ToTable("directors");

                entity.HasIndex(e => e.Citizenship)
                    .HasName("FK_citizen");

                entity.HasIndex(e => e.Cweacademic)
                    .HasName("FK_cweacad");

                entity.HasIndex(e => e.Cwegovt)
                    .HasName("FK_cwegovt");

                entity.HasIndex(e => e.Cwenonplc)
                    .HasName("FK_cwenonplc");

                entity.HasIndex(e => e.Cweplc)
                    .HasName("FK_cweplc");

                entity.HasIndex(e => e.Educationlevel)
                    .HasName("FK_educationlevel");

                entity.HasIndex(e => e.Ethnicity)
                    .HasName("FK_ethnicity");

                entity.HasIndex(e => e.Familytiesone)
                    .HasName("FK_familytiesone");

                entity.HasIndex(e => e.Familytiestwo)
                    .HasName("FK_familytiestwo");

                entity.HasIndex(e => e.Fieldofstudies)
                    .HasName("FK_fieldofstudies");

                entity.HasIndex(e => e.Gender)
                    .HasName("FK_gender");

                entity.HasIndex(e => e.Placeofeducation)
                    .HasName("FK_placeofeducation");

                entity.HasIndex(e => e.Professionalbody)
                    .HasName("FK_professionalbody");

                entity.HasIndex(e => e.Titledarjah)
                    .HasName("FK_title");

                entity.HasIndex(e => e.Voluntarybody)
                    .HasName("FK_voluntarybody");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Age)
                    .HasColumnName("age")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Citizenship)
                    .HasColumnName("citizenship")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cweacademic)
                    .HasColumnName("cweacademic")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cwegovt)
                    .HasColumnName("cwegovt")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cwenonplc)
                    .HasColumnName("cwenonplc")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cweplc)
                    .HasColumnName("cweplc")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Educationlevel)
                    .HasColumnName("educationlevel")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ethnicity)
                    .HasColumnName("ethnicity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Familytiesone)
                    .HasColumnName("familytiesone")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Familytiestwo)
                    .HasColumnName("familytiestwo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fieldofstudies)
                    .HasColumnName("fieldofstudies")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fieldofstudies2)
                    .HasColumnName("fieldofstudies2")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Info)
                    .HasColumnName("info")
                    .HasColumnType("varchar(10000)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(450);

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasMaxLength(750);

                entity.Property(e => e.Placeofeducation)
                    .HasColumnName("placeofeducation")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Professionalbody)
                    .HasColumnName("professionalbody")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Titledarjah)
                    .HasColumnName("titledarjah")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Voluntarybody)
                    .HasColumnName("voluntarybody")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Yearofbirth)
                    .HasColumnName("yearofbirth")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CitizenshipNavigation)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.Citizenship)
                    .HasConstraintName("FK_citizen");

                entity.HasOne(d => d.CweacademicNavigation)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.Cweacademic)
                    .HasConstraintName("FK_cweacad");

                entity.HasOne(d => d.CwegovtNavigation)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.Cwegovt)
                    .HasConstraintName("FK_cwegovt");

                entity.HasOne(d => d.CwenonplcNavigation)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.Cwenonplc)
                    .HasConstraintName("FK_cwenonplc");

                entity.HasOne(d => d.CweplcNavigation)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.Cweplc)
                    .HasConstraintName("FK_cweplc");

                entity.HasOne(d => d.EducationlevelNavigation)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.Educationlevel)
                    .HasConstraintName("FK_educationlevel");

                entity.HasOne(d => d.EthnicityNavigation)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.Ethnicity)
                    .HasConstraintName("FK_ethnicity");

                entity.HasOne(d => d.FamilytiesoneNavigation)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.Familytiesone)
                    .HasConstraintName("FK_familytiesone");

                entity.HasOne(d => d.FamilytiestwoNavigation)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.Familytiestwo)
                    .HasConstraintName("FK_familytiestwo");

                entity.HasOne(d => d.FieldofstudiesNavigation)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.Fieldofstudies)
                    .HasConstraintName("FK_fieldofstudies");

                entity.HasOne(d => d.FieldofstudiesNavigation2)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.Fieldofstudies2)
                    .HasConstraintName("FK_fieldofstudies2");

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.Gender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_gender");

                entity.HasOne(d => d.PlaceofeducationNavigation)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.Placeofeducation)
                    .HasConstraintName("FK_placeofeducation");

                entity.HasOne(d => d.ProfessionalbodyNavigation)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.Professionalbody)
                    .HasConstraintName("FK_professionalbody");

                entity.HasOne(d => d.TitledarjahNavigation)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.Titledarjah)
                    .HasConstraintName("FK_title");

                entity.HasOne(d => d.VoluntarybodyNavigation)
                    .WithMany(p => p.Directors)
                    .HasForeignKey(d => d.Voluntarybody)
                    .HasConstraintName("FK_voluntarybody");
            });

            modelBuilder.Entity<Directorship>(entity =>
            {
                entity.ToTable("directorship");

                entity.HasIndex(e => e.Cdp1)
                    .HasName("directorship___cdp1");

                entity.HasIndex(e => e.Cdp2)
                    .HasName("directorship___cdp2");

                entity.HasIndex(e => e.Companyid)
                    .HasName("directorship___company");

                entity.HasIndex(e => e.Daudit)
                    .HasName("directorship___diraudit");

                entity.HasIndex(e => e.Directorid)
                    .HasName("directorship___director");

                entity.HasIndex(e => e.Dnom)
                    .HasName("directorship___dirnom");

                entity.HasIndex(e => e.Drenum)
                    .HasName("directorship___dirrenum");

                entity.HasIndex(e => e.SessionId)
                    .HasName("directorship___session");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Cdp1)
                    .HasColumnName("cdp1")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Cdp2)
                    .HasColumnName("cdp2")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Companyid)
                    .HasColumnName("companyid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Daudit)
                    .HasColumnName("daudit")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Directorid)
                    .HasColumnName("directorid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Dnom)
                    .HasColumnName("dnom")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Drenum)
                    .HasColumnName("drenum")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SessionId)
                    .HasColumnName("sessionId")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Cdp1Navigation)
                    .WithMany(p => p.Directorship)
                    .HasForeignKey(d => d.Cdp1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("directorship___cdp1");

                entity.HasOne(d => d.Cdp2Navigation)
                    .WithMany(p => p.Directorship)
                    .HasForeignKey(d => d.Cdp2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("directorship___cdp2");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Directorship)
                    .HasForeignKey(d => d.Companyid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("directorship___company");

                entity.HasOne(d => d.DauditNavigation)
                    .WithMany(p => p.Directorship)
                    .HasForeignKey(d => d.Daudit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("directorship___diraudit");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Directorship)
                    .HasForeignKey(d => d.Directorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("directorship___director");

                entity.HasOne(d => d.DnomNavigation)
                    .WithMany(p => p.Directorship)
                    .HasForeignKey(d => d.Dnom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("directorship___dirnom");

                entity.HasOne(d => d.DrenumNavigation)
                    .WithMany(p => p.Directorship)
                    .HasForeignKey(d => d.Drenum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("directorship___dirrenum");

                entity.HasOne(d => d.DesosNavigation)
                    .WithMany(p => p.Directorship)
                    .HasForeignKey(d => d.Desos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("directorship___diresos");

                entity.HasOne(d => d.DriskNavigation)
                                    .WithMany(p => p.Directorship)
                                    .HasForeignKey(d => d.Drisk)
                                    .OnDelete(DeleteBehavior.ClientSetNull)
                                    .HasConstraintName("directorship___dirrisk");

                entity.HasOne(d => d.DexecNavigation)
                                    .WithMany(p => p.Directorship)
                                    .HasForeignKey(d => d.Dexec)
                                    .OnDelete(DeleteBehavior.ClientSetNull)
                                    .HasConstraintName("directorship___direxec");

                entity.HasOne(d => d.DtenderNavigation)
                                    .WithMany(p => p.Directorship)
                                    .HasForeignKey(d => d.Dtender)
                                    .OnDelete(DeleteBehavior.ClientSetNull)
                                    .HasConstraintName("directorship___dirtender");

                entity.HasOne(d => d.DfinanceNavigation)
                                    .WithMany(p => p.Directorship)
                                    .HasForeignKey(d => d.Dfinance)
                                    .OnDelete(DeleteBehavior.ClientSetNull)
                                    .HasConstraintName("directorship___dirfinance");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Directorship)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("directorship___session");
            });

            modelBuilder.Entity<Dshipraw>(entity =>
            {
                entity.ToTable("dshipraw");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Cdp1)
                    .HasColumnName("cdp1")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Cdp2)
                    .HasColumnName("cdp2")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Companyid)
                    .HasColumnName("companyid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Coname)
                    .IsRequired()
                    .HasColumnName("coname")
                    .HasMaxLength(450);

                entity.Property(e => e.Daudit)
                    .HasColumnName("daudit")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Directorid)
                    .HasColumnName("directorid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Dirname)
                    .IsRequired()
                    .HasColumnName("dirname")
                    .HasMaxLength(200);

                entity.Property(e => e.Dnom)
                    .HasColumnName("dnom")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Drenum)
                    .HasColumnName("drenum")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SessionId)
                    .HasColumnName("sessionId")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Educationlevel>(entity =>
            {
                entity.ToTable("educationlevel");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Edulevel)
                    .IsRequired()
                    .HasColumnName("edulevel")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(95);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Ethnicitytable>(entity =>
            {
                entity.ToTable("ethnicitytable");

                entity.HasIndex(e => e.Id)
                    .HasName("ethnicity_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Race)
                    .IsRequired()
                    .HasColumnName("race")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Familytiesonetable>(entity =>
            {
                entity.ToTable("familytiesonetable");

                entity.HasIndex(e => e.Id)
                    .HasName("familytiesonetable_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Tiestype)
                    .HasColumnName("tiestype")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Familytiestwotable>(entity =>
            {
                entity.ToTable("familytiestwotable");

                entity.HasIndex(e => e.Id)
                    .HasName("familytiestwotable_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Tiestype)
                    .HasColumnName("tiestype")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Fieldofstudiestable>(entity =>
            {
                entity.ToTable("fieldofstudiestable");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Fieldname)
                    .IsRequired()
                    .HasColumnName("fieldname")
                    .HasMaxLength(55);
            });

            modelBuilder.Entity<Fieldofstudiestable2>(entity =>
            {
                entity.ToTable("fieldofstudiestable2");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Fieldname)
                    .IsRequired()
                    .HasColumnName("fieldname")
                    .HasMaxLength(55);
            });

            modelBuilder.Entity<Gendertable>(entity =>
            {
                entity.ToTable("gendertable");

                entity.HasIndex(e => e.Id)
                    .HasName("gendertable_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Gendertype)
                    .IsRequired()
                    .HasColumnName("gendertype")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Glcstatus>(entity =>
            {
                entity.ToTable("glcstatus");

                entity.HasIndex(e => e.Id)
                    .HasName("glcstatus_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Isglcstatus)
                    .IsRequired()
                    .HasColumnName("isglcstatus")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Placeofeducationtable>(entity =>
            {
                entity.ToTable("placeofeducationtable");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasColumnName("place")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Professionalbodytable>(entity =>
            {
                entity.ToTable("professionalbodytable");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Organizationtype)
                    .HasColumnName("organizationtype")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Sectortable>(entity =>
            {
                entity.ToTable("sectortable");

                entity.HasIndex(e => e.Id)
                    .HasName("sectortable_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Sectorname)
                    .IsRequired()
                    .HasColumnName("sectorname")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Sessions>(entity =>
            {
                entity.ToTable("sessions");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Sessionyear)
                    .IsRequired()
                    .HasColumnName("sessionyear")
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<Titletable>(entity =>
            {
                entity.ToTable("titletable");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Titletype)
                    .HasColumnName("titletype")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Voluntarybodytable>(entity =>
            {
                entity.ToTable("voluntarybodytable");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Organizationtype)
                    .HasColumnName("organizationtype")
                    .HasMaxLength(100);
            });
        }

        public DbSet<Wbod.Models.SimpleDirectorship> SimpleDirectorship { get; set; }

        public DbSet<Wbod.Models.SessionRecordsVM> SessionRecordsVM { get; set; }
    }
}
