package test;

import static org.junit.jupiter.api.Assertions.assertEquals;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.List;

import org.junit.Before;
import org.junit.Test;

import Utility.InputProcessor;

public class InputProcessorTest {
    private final String input = "hello +word +test -may JUnit";
    private List<String> expectedAndStrings;
    private List<String> expectedOrStrings;
    private List<String> expectedSubStrings;
    private InputProcessor processor;

    @Before
    public void initialize() {
        expectedAndStrings = new ArrayList<>(Arrays.asList(new String[] {"hello", "JUnit"}));
        expectedOrStrings = new ArrayList<>(Arrays.asList(new String[] {"word", "test"}));
        expectedSubStrings = new ArrayList<>(Arrays.asList(new String[] {"may"}));

        processor = new InputProcessor(input);
    }

    @Test
    public void testProcessInput() {
        assertEquals(expectedAndStrings, processor.getAndStrings());
        assertEquals(expectedOrStrings, processor.getOrStrings());
        assertEquals(expectedSubStrings, processor.getSubtractString());
    }

    @Test
    public void testExtractAllQueryWords() {
        List<String> expectedAllWords = new ArrayList<>();
        expectedAllWords.addAll(expectedAndStrings);
        expectedAllWords.addAll(expectedOrStrings);
        expectedAllWords.addAll(expectedSubStrings);

        List<String> actualAllWords = processor.extractAllQueryWords();

        assertEquals(new HashSet<>(expectedAllWords), new HashSet<>(actualAllWords));
    }
}