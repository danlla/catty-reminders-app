using ExampleWebService.Models;

namespace ExampleWebService.Repositories;

public class PostgresWordRepository(AppDbContext dbContext) : IWordRepository
{
    public IEnumerable<string> GetAll() => dbContext.Words.Select(w => w.Text);

    public void Add(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            return;

        dbContext.Add(new Word { Text = word.Trim() });
        dbContext.SaveChanges();
    }
}
