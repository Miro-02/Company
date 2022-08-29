using CompanyNemetschek.Data;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyNemetschek.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //using (var context = new CompanyNemetschekContext(
            //    serviceProvider.GetRequiredService<
            //        DbContextOptions<CompanyNemetschekContext>>()))
            //{
            //    //if (context.Human.Any())
            //    //{
            //    //    return;   
            //    //}

            //    context.Human.AddRange(
            //        new Human("Miro", "Mirchev", "miro@gmail.com", new DateTime(2022, 11, 11), 0, 2000, "Sredetc", 1)

            //    );
            //    context.SaveChanges();
            //}
        }
    }
}
