import java.util.Set;

class AndSetOperator extends SetOperator {
    @Override
    public void specificOpeartion(Set<String> result, final Set<String> wordSet) {
        result.retainAll(wordSet);
    }
}