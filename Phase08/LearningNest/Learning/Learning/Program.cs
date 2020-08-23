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
            var client = ElasticClientFactory.CreateElasticClient();
            // CreateIndex(); //-> For Creating index, uncomment this
            // SendPersonFileToElasticSearch(); //-> for bulk sending peoples.json, uncomment this.

            var sampleQuery = new SampleQueries(client , IndexName);
            
            var response1 = sampleQuery.BoolQuerySample1();
            var response2 = sampleQuery.MatchQueryWithFuzzinessSample();
            var response3 = sampleQuery.TermQuerySample();
            var response4 = sampleQuery.TermsQuerySample();
            var response5 = sampleQuery.GeoDistanceSampleQuery(); //response5 must include Person with Name Deanne Garrison
            var response6 = sampleQuery.FuzzyQuerySample();
            var response7 = sampleQuery.DateRangeSampleQuery();
            var response8 = sampleQuery.MultiMatchQuerySample();
            var response9 = sampleQuery.TermsAggregation();



        }

        private static void SendPersonFileToElasticSearch()
        {
            JsonFileReader<Person> jsonFileReader = new JsonFileReader<Person> {Path = PeoplesPath};
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