﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nikita.DataAccess.EF.Test
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PermissionEntities : DbContext
    {
        public PermissionEntities()
            : base("name=PermissionEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bse_AccountUser> Bse_AccountUser { get; set; }
        public virtual DbSet<Bse_Exception> Bse_Exception { get; set; }
        public virtual DbSet<Bse_Log> Bse_Log { get; set; }
        public virtual DbSet<Bse_Mene_Shortcut> Bse_Mene_Shortcut { get; set; }
        public virtual DbSet<Bse_Menu> Bse_Menu { get; set; }
        public virtual DbSet<Bse_Organize> Bse_Organize { get; set; }
        public virtual DbSet<Bse_Role> Bse_Role { get; set; }
        public virtual DbSet<Bse_Role_Menu> Bse_Role_Menu { get; set; }
        public virtual DbSet<Bse_SetInfo> Bse_SetInfo { get; set; }
        public virtual DbSet<Bse_SetOrd> Bse_SetOrd { get; set; }
        public virtual DbSet<Bse_SetOrd_Tree> Bse_SetOrd_Tree { get; set; }
        public virtual DbSet<Bse_Shortcut> Bse_Shortcut { get; set; }
        public virtual DbSet<Bse_System> Bse_System { get; set; }
        public virtual DbSet<Bse_User> Bse_User { get; set; }
        public virtual DbSet<Bse_User_Organize> Bse_User_Organize { get; set; }
        public virtual DbSet<Bse_User_Role> Bse_User_Role { get; set; }
        public virtual DbSet<Bse_Version_UpdateLog> Bse_Version_UpdateLog { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tb> tb { get; set; }
        public virtual DbSet<Bse_City> Bse_City { get; set; }
        public virtual DbSet<Bse_Config> Bse_Config { get; set; }
        public virtual DbSet<Bse_District> Bse_District { get; set; }
        public virtual DbSet<Bse_Province> Bse_Province { get; set; }
    }
}
