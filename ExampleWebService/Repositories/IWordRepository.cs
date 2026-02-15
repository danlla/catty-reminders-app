namespace ExampleWebService.Repositories;

public interface IWordRepository
{
    IEnumerable<string> GetAll();
    void Add(string word);
}
