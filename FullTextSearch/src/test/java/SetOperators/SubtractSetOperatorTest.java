package SetOperators;

import org.junit.jupiter.api.Test;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

import static org.junit.jupiter.api.Assertions.*;

class SubtractSetOperatorTest {

    @Test
    public void notEmptyInitialSetCommonElementTest() {
        Set<String> result = new HashSet<>(Arrays.asList("a", "b", "c"));
        Set<String> subMask = new HashSet<>(Arrays.asList("a", "b"));
        new SubtractSetOperator().specificOperation(result, subMask);
        org.assertj.core.api.Assertions.assertThat(result).containsOnly("c");
    }

    @Test
    public void notEmptyInitialSetSubtractNothing() {
        Set<String> result = new HashSet<>(Arrays.asList("a", "b", "c"));
        Set<String> subMask = new HashSet<>(Arrays.asList());
        new SubtractSetOperator().specificOperation(result, subMask);
        org.assertj.core.api.Assertions.assertThat(result).containsOnly("a", "b", "c");
    }

    @Test
    public void notEmptyInitialSetSubtractNotCommon() {
        Set<String> result = new HashSet<>(Arrays.asList("a", "b", "c"));
        Set<String> subMask = new HashSet<>(Arrays.asList("d", "e"));
        new SubtractSetOperator().specificOperation(result, subMask);
        org.assertj.core.api.Assertions.assertThat(result).containsOnly("a", "b", "c");
    }

    @Test
    public void EmptyInitialSetTest() {
        Set<String> result = new HashSet<>();
        Set<String> subMask = new HashSet<>(Arrays.asList("z", "y"));
        new SubtractSetOperator().specificOperation(result, subMask);
        org.assertj.core.api.Assertions.assertThat(result).doesNotContainSequence("z", "y");
    }

}