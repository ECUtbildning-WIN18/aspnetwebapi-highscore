using System;
using System.Collections.Generic;
using System.Text;
using Highscore.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Highscore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Score> Scores { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        // Override this method to further configure the model that was discovered by convention from the entity types exposed in DbSet<TEntity> properties on your derived context. The resulting model may be cached and re-used for subsequent instances of your derived context.
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            // modelBuilder - the builder used to construct the model for this 
            // context. Databases (and other extensions) typically define 
            // extension methods on this ojbect that allow you to configure 
            // aspects of the model that are specifc for a given database.
            
            // We have to invoke base or we get exception
            // "The entity type 'IdentityUserLogin<string>' requires a primary key to be defined."
            base.OnModelCreating(modelBuilder);
        }
    }
}
