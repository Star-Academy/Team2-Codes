package SetOperators;

import java.util.Set;

public class AndSetOperator extends SetOperator {
    @Override
    public void specificOperation(Set<String> result, final Set<String> wordSet) {
        result.retainAll(wordSet);
    }
}