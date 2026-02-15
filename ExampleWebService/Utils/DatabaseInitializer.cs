using ExampleWebService.Models;

namespace ExampleWebService.Utils
{
    public class DatabaseInitializer(AppDbContext context)
    {
        private readonly Word[] _initialWords =
        [
            new Word { Text = "Whisperleaf" },
            new Word { Text = "Misthorn" },
            new Word { Text = "Glowspore" }
        ];

        public async Task InitializeAsync()
        {
            var created = await context.Database.EnsureCreatedAsync();

            if (created)
            {
                await context.Words.AddRangeAsync(_initialWords);
                await context.SaveChangesAsync();
            }
        }
    }
}
