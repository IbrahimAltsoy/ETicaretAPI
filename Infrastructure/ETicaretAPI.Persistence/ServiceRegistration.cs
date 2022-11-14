using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql("User ID=postgres;Password=Altsoy65.;Host=localhost;Port=5433;Database=ETicaretAPIDb;Pooling=true;Connection Lifetime=0;"));
            // 
            //User ID=postgres;Password=123456;Host=localhost;Port=5433;Database=ETicaretAPIDb;
        }
    }
}
