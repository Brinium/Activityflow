using System;
using System.Runtime;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Inflector;

//using NsInflector = Inflector;

namespace StatefullWorkflow.DataAccess
{
    public class InflectorPluralizer : IPluralizer
    {
        public Inflector.Inflector PluralizerService { get; set; }

        public InflectorPluralizer()
        {
            PluralizerService = new Inflector.Inflector(CultureInfo.CurrentCulture);
        }

        public string Pluralize(string word)
        {
            return PluralizerService.Pluralize(word);
        }
    }
}

