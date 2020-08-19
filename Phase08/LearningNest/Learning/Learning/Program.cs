using Learning.FileReader;
using Learning.Model;


namespace Learning
{
    class Program
    {
        const string PeoplesPath = "../../../resources/peoples.json";
        static void Main(string[] args)
        {
            var client = ElasticClientFactory.CreateElasticClient();
            var response = client.Ping();

            
            JsonFileReader<Person> jsonFileReader = new JsonFileReader<Person> {Path = PeoplesPath};
            jsonFileReader.GetList();
        }
    }
}
