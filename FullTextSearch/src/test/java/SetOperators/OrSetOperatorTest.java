package SetOperators;

import Model.InvertedIndex;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import java.util.*;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

class OrSetOperatorTest {
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

    @Test
    public void testFullFunctionalityOfOrOnInvertedIndex() {
        InvertedIndex invertedIndex = mock(InvertedIndex.class);

        when(invertedIndex.getIndices()).thenReturn(indexMap);

        Set<String> initial = indexMap.get("hello");
        Set<String> result= new OrSetOperator().operate(initial , Arrays.asList("hi" , "world") , invertedIndex);
        org.assertj.core.api.Assertions.assertThat(result).containsOnly("1","2","3","4","5");


    }
}