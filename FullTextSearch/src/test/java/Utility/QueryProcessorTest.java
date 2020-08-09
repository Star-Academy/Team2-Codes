package Utility;

import static org.junit.jupiter.api.Assertions.assertEquals;

import java.util.*;


import Model.Document;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

public class QueryProcessorTest {
    private QueryProcessor queryProcessor;
    
    @BeforeEach
    public void initialize() {
        List<Document> documents = makeSampleDocuments();
        Tokenizer.tokenizeAllDocuments(documents);
        queryProcessor = new QueryProcessor(documents);
    }

    private ArrayList<Document> makeSampleDocuments() {
        ArrayList<Document> documents = new ArrayList<>();
        documents.add(new Document("1.txt", "hello"));
        documents.add(new Document("2.txt", "hello may"));
        documents.add(new Document("3.txt", "hello world"));
        documents.add(new Document("4.txt", "albnyvms world may"));
        return documents;
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