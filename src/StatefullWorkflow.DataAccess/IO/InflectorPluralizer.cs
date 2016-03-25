using System.Globalization;
using NsInflector = Inflector;

namespace StatefullWorkflow.DataAccess
{
    public class InflectorPluralizer : IPluralizer
    {
        public NsInflector.Inflector PluralizerService { get; set; }

        public InflectorPluralizer()
        {
            PluralizerService = new NsInflector.Inflector(CultureInfo.CurrentCulture);
        }

        public string Pluralize(string word)
        {
            return PluralizerService.Pluralize(word);
        }
    }
}

