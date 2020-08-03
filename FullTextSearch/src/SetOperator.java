import java.util.List;
import java.util.Set;

public abstract class SetOperator {
    public void operate(Set<String> result, final List<String> queryWords, InvertedIndex invertedIndex) {
        if (queryWords != null && !queryWords.isEmpty()) {
            for (final String word : queryWords) {
                final Set<String> wordSet = invertedIndex.getIndices().get(word);
                if (wordSet != null && !wordSet.isEmpty()) {
                    specificOpeartion(result, wordSet);
                }
            }
        }
    }

    protected abstract void specificOpeartion(Set<String> result, final Set<String> wordSet);
}








