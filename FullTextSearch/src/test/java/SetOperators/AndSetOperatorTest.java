package SetOperators;

import Model.InvertedIndex;
import Utility.InputProcessor;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.*;

import static org.assertj.core.api.Assertions.*;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;

class AndSetOperatorTest {
    private static Map<String, Set<String>> indexMap;

    @BeforeAll
    public static void initialize() {
        indexMap = new HashMap<>();
        Set<String> helloIndex = new HashSet<>(Arrays.asList("1", "2", "3", "4"));
        Set<String> worldIndex = new HashSet<>(Arrays.asList("2", "3"));
        Set<String> hiIndex = new HashSet<>(Arrays.asList("2", "4"));
        indexMap.put("hello", helloIndex);
        indexMap.put("world", worldIndex);
        indexMap.put("hi", hiIndex);
    }

    @Test
    public void simpleAndFunctionalityTest() {
        Set<String> result = new HashSet<>(Arrays.asList("a", "b", "c"));
        Set<String> andMask = new HashSet<>(Arrays.asList("a", "b"));
        new AndSetOperator().specificOperation(result, andMask);
        org.assertj.core.api.Assertions.assertThat(result).containsOnly("a", "b");
    }

    @Test
    public void testFullFunctionalityOfAndOnInvertedIndex() {
        InvertedIndex invertedIndex = mock(InvertedIndex.class);

        when(invertedIndex.getIndices()).thenReturn(indexMap);

        Set<String> initial = indexMap.get("hello");
        Set<String> result= new AndSetOperator().operate(initial , Arrays.asList("hi" , "world") , invertedIndex);
        org.assertj.core.api.Assertions.assertThat(result).containsOnly("2");


    }

}