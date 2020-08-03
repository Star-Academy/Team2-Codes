import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class QueryProcessor {

    private List<Document> documents;
    private InvertedIndex invertedIndex;

    public QueryProcessor(final List<Document> documents) {
        setDocuments(documents);
        final InvertedIndex invertedIndex = new InvertedIndex();
        invertedIndex.addWordsOfMultipleDocuments(getDocuments());
        setInvertedIndex(invertedIndex);
    }

    public List<String> advancedQuery(final String input) {

        final InputProcessor inputProcessor = new InputProcessor(input);
        final List<String> orStrings = inputProcessor.getOrStrings();
        final List<String> andStrings = inputProcessor.getAndStrings();
        final List<String> subtractStrings = inputProcessor.getSubtractString();
        Set<String> result = new HashSet<>();

        if (andStrings != null && !andStrings.isEmpty()) {
            result = getInvertedIndex().getIndices().get(andStrings.get(0));
            // because if we have multiple ands, the first one must not be empty.
        }
        if (result == null) {
            result = new HashSet<>();
        }

        // Operation Precedence: AND (Without Signs) -> OR (+ Signs) -> Subtract (-
        // Signs)
        result = operationPerformerOnSet(result, andStrings, SetOperationType.AND);
        result = operationPerformerOnSet(result, orStrings, SetOperationType.OR);
        result = operationPerformerOnSet(result, subtractStrings, SetOperationType.SUBTRACT);

        return new ArrayList<>(result);
    }

    private Set<String> operationPerformerOnSet(final Set<String> base, final List<String> queryWords,
            final SetOperationType operationType) {
        final Set<String> result = new HashSet<>(base);
        if (queryWords != null && !queryWords.isEmpty()) {

            for (final String word : queryWords) {
                final Set<String> wordSet = getInvertedIndex().getIndices().get(word);
                if (wordSet != null && !wordSet.isEmpty()) {
                    switch (operationType) {
                        case OR:
                            result.addAll(wordSet);
                            break;
                        case AND:
                            result.retainAll(wordSet);
                            break;
                        case SUBTRACT:
                            result.removeAll(wordSet);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        return result;
    }

    private List<Document> getDocuments() {
        return documents;
    }

    private void setDocuments(final List<Document> documents) {
        this.documents = documents;
    }

    private InvertedIndex getInvertedIndex() {
        return invertedIndex;
    }

    private void setInvertedIndex(final InvertedIndex invertedIndex) {
        this.invertedIndex = invertedIndex;
    }

}

enum SetOperationType {
    AND, OR, SUBTRACT
}
