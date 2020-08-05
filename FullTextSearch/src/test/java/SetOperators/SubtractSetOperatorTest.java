package SetOperators;

import Model.InvertedIndex;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import java.util.*;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

class SubtractSetOperatorTest {
    private static Map<String, Set<String>> indexMap;

    @BeforeAll
    public static void initialize() {
        indexMap = new HashMap<>();
        Set<String> helloIndex = new HashSet<>(Arrays.asList("1", "2", "3", "4"));
        Set<String> worldIndex = new HashSet<>(Arrays.asList("2", "5"));
        Set<String> hiIndex = new HashSet<>(Arrays.asList("2", "4"));
        indexMap.put("hello", helloIndex);
        indexMap.put("world", worldIndex);
        indexMap.put("hi", hiIndex);
    }

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

    @Test
    public void testFullFunctionalityOfSubtractOnInvertedIndex() {
        InvertedIndex invertedIndex = mock(InvertedIndex.class);

        when(invertedIndex.getIndices()).thenReturn(indexMap);

        Set<String> initial = indexMap.get("hello");
        Set<String> result= new SubtractSetOperator().operate(initial , Arrays.asList("hi" , "world") , invertedIndex);
        org.assertj.core.api.Assertions.assertThat(result).containsOnly("1","3");


    }

}