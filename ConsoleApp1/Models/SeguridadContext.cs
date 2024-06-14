using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Models;

public partial class SeguridadContext : DbContext
{
    public SeguridadContext()
    {
    }

    public SeguridadContext(DbContextOptions<SeguridadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PermissionsProfilesWebModule> PermissionsProfilesWebModules { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<TypesModule> TypesModules { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<UserState> UserStates { get; set; }

    public virtual DbSet<WebModule> WebModules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=seguridad;Username=postgres;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PermissionsProfilesWebModule>(entity =>
        {
            entity.HasKey(e => e.PermissionProfileWebModuleId).HasName("permissions_profiles_web_modules_pkey");

            entity.ToTable("permissions_profiles_web_modules");

            entity.Property(e => e.PermissionProfileWebModuleId)
                .HasDefaultValueSql("nextval('permissions_profiles_web_modu_permission_profile_web_module_seq'::regclass)")
                .HasColumnName("permission_profile_web_module_id");
            entity.Property(e => e.PermissionProfileWebModuleAccess)
                .HasDefaultValue(false)
                .HasColumnName("permission_profile_web_module_access");
            entity.Property(e => e.PermissionProfileWebModuleCreate)
                .HasDefaultValue(false)
                .HasColumnName("permission_profile_web_module_create");
            entity.Property(e => e.PermissionProfileWebModuleDelete)
                .HasDefaultValue(false)
                .HasColumnName("permission_profile_web_module_delete");
            entity.Property(e => e.PermissionProfileWebModuleDownload)
                .HasDefaultValue(false)
                .HasColumnName("permission_profile_web_module_download");
            entity.Property(e => e.PermissionProfileWebModuleUpdate)
                .HasDefaultValue(false)
                .HasColumnName("permission_profile_web_module_update");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.WebModuleId).HasColumnName("web_module_id");

            entity.HasOne(d => d.Profile).WithMany(p => p.PermissionsProfilesWebModules)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_profile_id");

            entity.HasOne(d => d.WebModule).WithMany(p => p.PermissionsProfilesWebModules)
                .HasForeignKey(d => d.WebModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_web_module_id");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("profiles_pkey");

            entity.ToTable("profiles");

            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.ProfileName)
                .HasMaxLength(100)
                .HasColumnName("profile_name");
        });

        modelBuilder.Entity<TypesModule>(entity =>
        {
            entity.HasKey(e => e.TypeModuleId).HasName("types_modules_pkey");

            entity.ToTable("types_modules");

            entity.Property(e => e.TypeModuleId).HasColumnName("type_module_id");
            entity.Property(e => e.TypeModuleName)
                .HasMaxLength(100)
                .HasColumnName("type_module_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserAttempts)
                .HasDefaultValue(0)
                .HasColumnName("user_attempts");
            entity.Property(e => e.UserDateCreate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("user_date_create");
            entity.Property(e => e.UserDateExpPassword)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("user_date_exp_password");
            entity.Property(e => e.UserDateUpdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("user_date_update");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(100)
                .HasColumnName("user_email");
            entity.Property(e => e.UserFirstLogin)
                .HasDefaultValue(false)
                .HasColumnName("user_first_login");
            entity.Property(e => e.UserLogin)
                .HasMaxLength(100)
                .HasColumnName("user_login");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(100)
                .HasColumnName("user_password");
            entity.Property(e => e.UserStateId).HasColumnName("user_state_id");

            entity.HasOne(d => d.UserState).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_user_state_id_fkey");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.UserProfileId).HasName("user_profiles_pkey");

            entity.ToTable("user_profiles");

            entity.Property(e => e.UserProfileId).HasColumnName("user_profile_id");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Profile).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("user_profiles_profile_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_profiles_user_id_fkey");
        });

        modelBuilder.Entity<UserState>(entity =>
        {
            entity.HasKey(e => e.UserStateId).HasName("user_states_pkey");

            entity.ToTable("user_states");

            entity.Property(e => e.UserStateId).HasColumnName("user_state_id");
            entity.Property(e => e.UserStateName)
                .HasMaxLength(100)
                .HasColumnName("user_state_name");
        });

        modelBuilder.Entity<WebModule>(entity =>
        {
            entity.HasKey(e => e.WebModuleId).HasName("web_modules_pkey");

            entity.ToTable("web_modules");

            entity.Property(e => e.WebModuleId).HasColumnName("web_module_id");
            entity.Property(e => e.TypeModuleId).HasColumnName("type_module_id");
            entity.Property(e => e.WebModuleCreateDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("web_module_create_date");
            entity.Property(e => e.WebModuleDescription)
                .HasMaxLength(100)
                .HasColumnName("web_module_description");
            entity.Property(e => e.WebModuleFather).HasColumnName("web_module_father");
            entity.Property(e => e.WebModuleIcon)
                .HasMaxLength(100)
                .HasColumnName("web_module_icon");
            entity.Property(e => e.WebModuleIndex).HasColumnName("web_module_index");
            entity.Property(e => e.WebModuleTitle)
                .HasMaxLength(100)
                .HasColumnName("web_module_title");
            entity.Property(e => e.WebModuleUrl)
                .HasMaxLength(100)
                .HasColumnName("web_module_url");

            entity.HasOne(d => d.TypeModule).WithMany(p => p.WebModules)
                .HasForeignKey(d => d.TypeModuleId)
                .HasConstraintName("web_modules_type_module_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
