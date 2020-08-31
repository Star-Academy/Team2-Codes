using Learning.AnalysisSettings.Names;
using Learning.Model;
using Nest;

namespace Learning.Mapping
{
    internal static class PersonFieldsConfigurator
    {
        public static PropertiesDescriptor<Person> AddPersonNameMapping(this PropertiesDescriptor<Person> pr)
        {
            return pr.Text(t =>
                t.Name(n => n.Name)
                    .Fields(AddNgramFieldWithKeyword));
        }

        public static PropertiesDescriptor<Person> AddPersonCompanyMapping(this PropertiesDescriptor<Person> pr)
        {
            return pr.Text(t =>
                t.Name(n => n.Company)
                    .Fields(AddNgramFieldWithKeyword));
        }

        public static PropertiesDescriptor<Person> AddPersonEyeColorMapping(this PropertiesDescriptor<Person> pr)
        {
            return pr.Text(t =>
                t.Name(n => n.EyeColor)
                    .Fields(AddNgramFieldWithKeyword));
        }


        public static PropertiesDescriptor<Person> AddPersonAddressMapping(this PropertiesDescriptor<Person> pr)
        {
            return pr.Text(t =>
                t.Name(n => n.Address)
                    .Fields(AddNgramFieldWithKeyword));
        }

        public static PropertiesDescriptor<Person> AddPersonAboutMapping(this PropertiesDescriptor<Person> pr)
        {
            return pr.Text(t =>
                t.Name(n => n.About)
                    .Fields(AddNgramFieldWithKeyword));
        }

        public static PropertiesDescriptor<Person> AddPersonPhoneMapping(this PropertiesDescriptor<Person> pr)
        {
            return pr.Text(t =>
                t.Name(n => n.Phone)
                    .Fields(AddNgramFieldWithKeyword));
        }

        public static PropertiesDescriptor<Person> AddPersonGenderMapping(this PropertiesDescriptor<Person> pr)
        {
            return pr.Text(t =>
                t.Name(n => n.Gender));
        }

        public static PropertiesDescriptor<Person> AddPersonAgeMapping(this PropertiesDescriptor<Person> pr)
        {
            return pr.Number(t => t.Name(n => n.Age).Type(NumberType.Integer));
        }

        public static PropertiesDescriptor<Person> AddPersonLocationMapping(this PropertiesDescriptor<Person> pr)
        {
            return pr.GeoPoint(t => t.Name(n => n.Location));
        }

        public static PropertiesDescriptor<Person> AddPersonEmailMapping(this PropertiesDescriptor<Person> pr)
        {
            return pr.Text(t =>
                t.Name(n => n.Email)
                    .Fields(AddEmailField));
        }

        private static IPromise<IProperties> AddEmailField(PropertiesDescriptor<Person> f)
        {
            return f.Text(ng => ng.Name("email").Analyzer(AnalyzerNames.EmailAnalyzer));
        }

        private static IPromise<IProperties> AddNgramFieldWithKeyword(PropertiesDescriptor<Person> f)
        {
            return f.Text(ng => ng.Name("ngram").Analyzer(AnalyzerNames.NGramAnalyzerMin3Max13)).Keyword(s=> s.Name("keyword"));
        }

        public static PropertiesDescriptor<Person> AddPersonRegistrationDateMapping(this PropertiesDescriptor<Person> pr)
        {
            return pr.Date(t =>
                t.Name(n => n.RegistrationDate).Format("yyyy-MM-dd'T'HH:mm:ss"));
        }
    }
}


