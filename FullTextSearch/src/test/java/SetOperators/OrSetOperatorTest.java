package SetOperators;

import org.junit.jupiter.api.Test;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

import static org.junit.jupiter.api.Assertions.*;

class OrSetOperatorTest {

    @Test
    public void notEmptyInitialSetCommonElementTest() {
        Set<String> result = new HashSet<>(Arrays.asList("a", "b", "c"));
        Set<String> orMask = new HashSet<>(Arrays.asList("a", "b"));
        new OrSetOperator().specificOperation(result, orMask);
        org.assertj.core.api.Assertions.assertThat(result).containsOnly("a", "b", "c");
    }

    @Test
    public void notEmptyInitialSetNonCommonElementTest() {
        Set<String> result = new HashSet<>(Arrays.asList("a", "b", "c"));
        Set<String> orMask = new HashSet<>(Arrays.asList("d", "e"));
        new OrSetOperator().specificOperation(result, orMask);
        org.assertj.core.api.Assertions.assertThat(result).containsOnly("a", "b", "c", "d", "e");
    }

    @Test
    public void EmptyInitialSetTest() {
        Set<String> result = new HashSet<>();
        Set<String> orMask = new HashSet<>(Arrays.asList("z", "y"));
        new OrSetOperator().specificOperation(result, orMask);
        org.assertj.core.api.Assertions.assertThat(result).containsOnly("z", "y");
    }
}