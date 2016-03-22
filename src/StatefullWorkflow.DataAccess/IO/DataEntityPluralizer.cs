using System;

//using System.Data.Entity.Design.PluralizationServices;

namespace StatefullWorkflow.DataAccess
{
    public class DataEntityPluralizer : IPluralizer
    {
        //public PluralizationService Pluralizer { get; set; }

        public DataEntityPluralizer()
        {
            //Pluralizer = PluralizationService.CreateService(CultureInfo.CurrentCulture);
        }

        public string Pluralize(string word)
        {
            return word;
            //return Pluralizer.Pluralize(word);
        }
    }
}

