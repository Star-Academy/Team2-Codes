package SetOperators;

import java.util.Set;

public class OrSetOperator extends SetOperator {
    @Override
    public void specificOperation(Set<String> result, final Set<String> wordSet) {
        result.addAll(wordSet);
    }
}