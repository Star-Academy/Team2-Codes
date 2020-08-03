import java.util.Set;

class SubtractSetOperator extends SetOperator {
    @Override
    public void specificOperation(Set<String> result, final Set<String> wordSet) {
        result.removeAll(wordSet);
    }
}
