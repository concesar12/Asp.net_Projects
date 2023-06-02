﻿using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace CRUDTests
{
    public class CustomWebApplicationFactory :WebApplicationFactory<Program> //based in our program class// accessing the program referenced in program.cs
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            //Call configure webhost
            base.ConfigureWebHost(builder);

            //Set environment
            builder.UseEnvironment("Test");

            //Override configure services to configure our own services to be tested
            builder.ConfigureServices(services => {
                var descripter = services.SingleOrDefault(temp => temp.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

                if (descripter != null)
                {
                    services.Remove(descripter);
                }
                //Add the Db Context to use inmemory 
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("DatbaseForTesting");
                });
            });
        }
    }
}
