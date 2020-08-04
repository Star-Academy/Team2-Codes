package SetOperators;

import java.util.Set;

public class SubtractSetOperator extends SetOperator {
    @Override
    public void specificOperation(Set<String> result, final Set<String> wordSet) {
        result.removeAll(wordSet);
    }
}
