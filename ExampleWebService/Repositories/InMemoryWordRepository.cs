namespace ExampleWebService.Repositories;

public class InMemoryWordRepository : IWordRepository
{
    private static readonly List<string> _words =
    [
        "Whisperleaf",
        "Misthorn",
        "Glowspore"
    ];

    public IEnumerable<string> GetAll() => _words;

    public void Add(string word)
    {
        if (!string.IsNullOrWhiteSpace(word))
            _words.Add(word.Trim());
    }
}