package Utility;

import static org.junit.jupiter.api.Assertions.assertEquals;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.List;



import Utility.InputProcessor;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

public class InputProcessorTest {
    private final String input = "hello +word +test -may -have JUnit";
    private List<String> expectedAndStrings;
    private List<String> expectedOrStrings;
    private List<String> expectedSubStrings;
    private InputProcessor processor;

    @BeforeEach
    public void initialize() {
        expectedAndStrings = new ArrayList<>(Arrays.asList("hello", "JUnit"));
        expectedOrStrings = new ArrayList<>(Arrays.asList("word", "test"));
        expectedSubStrings = new ArrayList<>(Arrays.asList("may", "have"));

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