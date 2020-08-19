using Learning.FileReader;
using Learning.Model;


namespace Learning
{
    class Program
    {
        const string PeoplesPath = "../../../resources/peoples.json";
        private const string IndexName = "person_nest";

        static void Main(string[] args)
        {
            var client= ElasticClientFactory.CreateElasticClient();
            // CreateIndex(); -> For Creating index, uncomment this
            // SendPersonFileToElasticSearch(); -> for bulk sending peoples.json, uncomment this.

            // var response = SampleQueries.BoolQuerySample1(client , IndexName);
            // var response = SampleQueries.MatchQueryWithFuzzinessSample(client , IndexName);
            // var response = SampleQueries.TermQuerySample(client , IndexName);
            // var response = SampleQueries.TermsQuerySample(client , IndexName);
            var response = SampleQueries.GeoDistanceSampleQuerry(client , IndexName); //Output Should be Person with Name Deanne Garrison


        }

        private static void SendPersonFileToElasticSearch()
        {
            JsonFileReader<Person> jsonFileReader = new JsonFileReader<Person> { Path = PeoplesPath };
            var persons = jsonFileReader.GetIEnumerable();

            var importer = new Importer<Person>();
            var response = importer.SendBulk(persons, IndexName);
        } 


        private static void CreateIndex()
        {
            var indexMaker = new IndexMaker();
            var response = indexMaker.MakeIndex(IndexName);
        }
    }
}