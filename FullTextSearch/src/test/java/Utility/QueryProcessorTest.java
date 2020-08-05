package Utility;

import static org.junit.jupiter.api.Assertions.assertEquals;

import java.util.Arrays;
import java.util.HashSet;
import java.util.List;
import java.util.Set;



import Model.Document;
import Utility.FileReader;
import Utility.QueryProcessor;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

public class QueryProcessorTest {
    private final String path = "./SmallEnglishData";
    private QueryProcessor queryProcessor;
    
    @BeforeEach
    public void initialize() {
        FileReader fileReader = new FileReader(path);
        List<Document> documents = fileReader.getDocuments();
        Tokenizer.tokenizeAllDocuments(documents);
        queryProcessor = new QueryProcessor(documents);
    }

    @Test
    public void testAdvanceQuery() {
        String input = "hello";
        Set<String> expectedDocIds = new HashSet<>(Arrays.asList("1.txt", "2.txt", "3.txt"));
        
        Set<String> actualDocIds = new HashSet<>(queryProcessor.advancedQuery(input));
        
        assertEquals(expectedDocIds, actualDocIds);

        //another test with minus sign
        input = "hello -may";
        expectedDocIds = new HashSet<>(Arrays.asList("1.txt", "3.txt"));

        actualDocIds = new HashSet<>(queryProcessor.advancedQuery(input));
        
        assertEquals(expectedDocIds, actualDocIds);
    }

    @Test
    public void testAdvanceQueryWithNoResult() {
        String input = "nothing";
        assertEquals(0, queryProcessor.advancedQuery(input).size());
    }
     
}