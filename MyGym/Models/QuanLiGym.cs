namespace MyGym.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class QuanLiGym : DbContext
    {
        // Your context has been configured to use a 'QuanLiGym' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MyGym.Models.QuanLiGym' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QuanLiGym' 
        // connection string in the application configuration file.

        public DbSet<HoiVien> HoiViens { get; set; }
        public DbSet<GoiTap> GoiTaps { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<PhongTap> PhongTaps { get; set; }
        public DbSet<TrangThietBi> TrangThietBis { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }

        public QuanLiGym()
            : base("name=QuanLiGym")
        {
            Database.SetInitializer<QuanLiGym>(new InitializerDB());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}