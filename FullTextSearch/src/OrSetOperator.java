import java.util.Set;

class OrSetOperator extends SetOperator {
    @Override
    public void specificOperation(Set<String> result, final Set<String> wordSet) {
        result.addAll(wordSet);
    }
}