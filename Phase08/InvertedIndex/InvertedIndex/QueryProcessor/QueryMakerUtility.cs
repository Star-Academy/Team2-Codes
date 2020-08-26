using System.Linq;
using Nest;

namespace InvertedIndex.QueryProcessor
{
    internal static class QueryMakerUtility
    {
        internal static BoolQuery AddMinusWords(this BoolQuery query, string subtractStrings)
        {
            if (!string.IsNullOrEmpty(subtractStrings))
            {
                query.MustNot = query.MustNot.Append(new MatchQuery()
                {
                    Field = "content",
                    Query = subtractStrings
                });
            }

            return query;
        }

        internal static BoolQuery AddPlusWords(this BoolQuery query, string orStrings)
        {
            if (!string.IsNullOrEmpty(orStrings))
            {
                query.Should = query.Should.Append(new MatchQuery()
                {
                    Field = "content",
                    Query = orStrings
                });
            }

            return query;
        }

        internal static BoolQuery AddNonSignedWords(this BoolQuery query, string andStrings)
        {
            if (!string.IsNullOrEmpty(andStrings))
            {
                query.Should = query.Should.Append(new MatchQuery()
                {
                    Field = "content",
                    Query = andStrings,
                    Operator = Operator.And
                });
            }

            return query;
        }
    }
}