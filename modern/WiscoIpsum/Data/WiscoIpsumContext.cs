using Microsoft.EntityFrameworkCore;
using WiscoIpsum.Models;

namespace WiscoIpsum.Data
{
    public class WiscoIpsumContext : DbContext
    {
        public DbSet<Phrase> Phrases { get; set; }

        public WiscoIpsumContext(DbContextOptions<WiscoIpsumContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            var phrases = new Phrase[] {
                new Phrase { Id=1, Text= "Ope" },
                new Phrase { Id=2, Text="Where-Abouts" },
                new Phrase { Id=3, Text="Spotted Cow" },
                new Phrase { Id=4, Text="Brandy Old Fashioned" },
                new Phrase { Id=5, Text="Stop-and-go-lights" },
                new Phrase { Id=6, Text="Fleet Farm" },
                new Phrase { Id=7, Text="Cheesehead" },
                new Phrase { Id=8, Text="Fish Fry" },
                new Phrase { Id=9, Text="Bubbler" },
                new Phrase { Id=10, Text="Aw Geez" },
                new Phrase { Id=11, Text="For Cripes Sakes" },
                new Phrase { Id=12, Text="Up Nort" },
                new Phrase { Id=13, Text="Uff-Da" },
                new Phrase { Id=14, Text="Ya Know?" },
                new Phrase { Id=15, Text="Believe You Me" },
                new Phrase { Id=16, Text="You betcha" }
            };

            modelBuilder.Entity<Phrase>().ToTable("Phrase").HasData(phrases);
        }
    }
}
