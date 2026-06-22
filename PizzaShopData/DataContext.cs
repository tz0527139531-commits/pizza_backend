using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaShopCore.Entities;


namespace PizzaShopData
{
    public class DataContext:DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Pizza> pizzas { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Order> orders { get; set; }
        public DataContext(IConfiguration configuration)
        {
            this._configuration = configuration;
    
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //זה לא התחבר לי
            // optionsBuilder.UseSqlServer(@"Server=DESKTOP-L9S4R74;Database=sample_DB");
            //ה-gpt אמר לי להוסיף TrustServerCertificate=True את זה למחרוזת החיבור 
            var conectionS = _configuration["ConnectionString"]; 
            optionsBuilder.UseSqlServer(conectionS);
            Console.WriteLine("the connectionString" + _configuration["ConnectionString"]);
        }
        

       
    }
}
