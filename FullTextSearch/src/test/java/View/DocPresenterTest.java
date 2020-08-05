package View;

import org.junit.jupiter.api.AfterAll;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import java.io.ByteArrayOutputStream;
import java.io.PrintStream;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

class DocPresenterTest {

    private static final ByteArrayOutputStream outContent = new ByteArrayOutputStream();
    private static final PrintStream originalOut = System.out;

    @BeforeAll
    public static void initialize() {
        System.setOut(new PrintStream(outContent));
    }

    @Test
    public void showSortedDocIdsTest() {
        List<String> stringList = new ArrayList<>(Arrays.asList("hello", "abc", "man", "z"));
        DocPresenter.showSortedDocIds(stringList);
        assertEquals("[abc, hello, man, z]", outContent.toString().trim());
    }

    @AfterAll
    public static void restoreStreams() {
        System.setOut(originalOut);
    }
}