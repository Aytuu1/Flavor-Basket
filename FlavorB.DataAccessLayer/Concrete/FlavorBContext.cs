using FlavorB.EntityLayer.Entities;
using FlavorBasketAPI.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlavorB.DataAccessLayer.Concrete
{
  public class FlavorBContext :IdentityDbContext<AppUser,AppRole,int>
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=DESKTOP-EGM53VS\\SQLAYTU; initial Catalog=FlavorBDB; integrated Security=true");
    }
    public DbSet<About>? Abouts { get; set; }
    public DbSet<Booking>? Bookings { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Contact>? Contacts { get; set; }
    public DbSet<Discount>? Discounts { get; set; }
    public DbSet<Feature>? Features { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<SocialMedya>? SocialMedias { get; set; }
    public DbSet<Testimonial>? Testimonials { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<OrderDetail>? OrderDetails { get; set; }
    public DbSet<MoneyCase> MoneyCases { get; set; }
    public DbSet<MenuTable> MenuTables { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Message> Messages { get; set; }

  }
}
