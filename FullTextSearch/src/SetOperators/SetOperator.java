package SetOperators;

import Model.InvertedIndex;

import java.util.HashSet;
import java.util.List;
import java.util.Set;

public abstract class SetOperator {
    public Set<String> operate(Set<String> result, final List<String> queryWords, InvertedIndex invertedIndex) {
        Set<String> answer = new HashSet<>(result);
        if (queryWords != null && !queryWords.isEmpty()) {
            for (final String word : queryWords) {
                final Set<String> wordSet = invertedIndex.getIndices().get(word);
                if (wordSet != null && !wordSet.isEmpty()) {
                    specificOperation(answer, wordSet);
                }
            }
        }
        return answer;
    }

    protected abstract void specificOperation(Set<String> result, final Set<String> wordSet);
}
