using ExampleWebService.Repositories;

namespace ExampleTestProject;

public class InMemoryWordRepositoryTests
{
    [Fact]
    public void CountTest()
    {
        const int expectedCount = 3;
        var repository = new InMemoryWordRepository();

        var words = repository.GetAll();
        var actualCount = words.Count();
        Assert.Equal(expectedCount, actualCount);
    }

    [Fact]
    public void WordsTest()
    {
        var expected = new List<string>
        {
            "Whisperleaf",
            "Misthorn",
            "Glowspore"
        };
        var repository = new InMemoryWordRepository();

        var words = repository.GetAll();

        Assert.Equal(expected, words);
    }
}