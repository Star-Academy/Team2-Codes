package SetOperators;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

import static org.assertj.core.api.Assertions.*;

import static org.junit.jupiter.api.Assertions.*;

class AndSetOperatorTest {
    @Test
    public void simpleAndFunctionalityTest() {
        Set<String> result = new HashSet<>();
        Set<String> andMask = new HashSet<>();
        result.addAll(Arrays.asList("a", "b", "c"));
        andMask.addAll(Arrays.asList("a", "b"));
        new AndSetOperator().specificOperation(result, andMask);
        org.assertj.core.api.Assertions.assertThat(result).containsOnly("a", "b");
    }

}