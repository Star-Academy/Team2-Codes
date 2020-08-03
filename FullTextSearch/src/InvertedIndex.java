import java.util.*;

public class InvertedIndex {
    private Map<String, Set<String>> indices;

    public InvertedIndex() {
        setIndices(new HashMap<>());
    }

    public void addWordsOfMultipleDocuments(final List<Document> documents) {
        if (documents != null) {
            for (final Document document : documents) {
                if (document != null) {
                    addAllWordsOfADocument(document);
                }
            }
        }
    }

    public void addAllWordsOfADocument(final Document document) {
        if (document.getTokenizedWords() == null) {
            document.tokenizeContent();
        }
        for (final String word : document.getTokenizedWords()) {
            addWord(word, document);
        }

    }

    public void addWord(final String word, final Document document) {
        getIndices().computeIfAbsent(word, k -> new HashSet<>());
        getIndices().get(word).add(document.getId());
    }

    public Map<String, Set<String>> getIndices() {
        return indices;
    }

    public void setIndices(final Map<String, Set<String>> indices) {
        this.indices = indices;
    }
}
