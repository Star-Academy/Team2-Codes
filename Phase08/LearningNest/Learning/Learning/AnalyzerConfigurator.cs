using System;
using System.Collections.Generic;
using System.Text;
using Learning.AnalysisSettings;
using Nest;

namespace Learning
{
    internal static class AnalyzerConfigurator
    {

      
        public static IPromise<IAnalyzers> MakeAnalyzer(AnalyzersDescriptor analyzer)
        {
            return analyzer
                .Custom(AnalyzerNames.NGramAnalyzer3_13,
                    s => s.Tokenizer("standard").Filters("lowercase", TokenFiltersNames.NgramTokenizer_3_13))
                .Custom(AnalyzerNames.EmailAnalyzer, s => s.Tokenizer(TokenizerNames.EmailTokenizer));
        }

        public static IPromise<ITokenizers> MakeTokenizers(TokenizersDescriptor s)
        {
            return s.UaxEmailUrl(TokenizerNames.EmailTokenizer, s => s);
        }

        public static IPromise<ITokenFilters> MakeTokenFilters(TokenFiltersDescriptor s)
        {
            return s.NGram(TokenFiltersNames.NgramTokenizer_3_13, s => s.MinGram(3)
                .MaxGram(13));
        }
    }
}
