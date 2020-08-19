using Learning.AnalysisSettings.Names;
using Nest;

namespace Learning.AnalysisSettings
{
    internal static class AnalyzerConfigurator
    {

      
        public static IPromise<IAnalyzers> MakeAnalyzer(AnalyzersDescriptor analyzer)
        {
            return analyzer
                .Custom(AnalyzerNames.NGramAnalyzerMin3Max13,
                    s => s.Tokenizer("standard").Filters("lowercase", TokenFiltersNames.NgramTokenizerMin3Max13))
                .Custom(AnalyzerNames.EmailAnalyzer, s => s.Tokenizer(TokenizerNames.EmailTokenizer).Filters("lowercase"));
        }

        public static IPromise<ITokenizers> MakeTokenizers(TokenizersDescriptor s)
        {
            return s.UaxEmailUrl(TokenizerNames.EmailTokenizer, s => s);
        }

        public static IPromise<ITokenFilters> MakeTokenFilters(TokenFiltersDescriptor s)
        {
            return s.NGram(TokenFiltersNames.NgramTokenizerMin3Max13, s => s.MinGram(3)
                .MaxGram(13));
        }
    }
}
