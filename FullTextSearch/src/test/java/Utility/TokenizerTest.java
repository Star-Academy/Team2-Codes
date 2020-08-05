package Utility;

import static org.junit.jupiter.api.Assertions.assertEquals;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import org.junit.Test;

import Model.Document;
import Utility.Tokenizer;

public class TokenizerTest {
    
    @Test
    public void testTokenizeContent() {
        String content = "hello, this text is going to get tokenized";
        String[] tokens = new String[]{"hello", "this", "text", "is", "going", "to", "get", "tokenized" };
        Set<String> expectedTokens = new HashSet<>(Arrays.asList(tokens));

        Set<String> actualTokens = Tokenizer.tokenizeContent(content);

        assertEquals(expectedTokens, actualTokens);
    }

    @Test
    public void testTokenizeAllDocuments() {
        List<Document> documents = new ArrayList<>();
        Document document1 = new Document("1", "hello test tokenizer");
        Document document2 = new Document("2", "this is second doc");
        documents.add(document1);
        documents.add(document2);

        Tokenizer.tokenizeAllDocuments(documents);

        Set<String> firstDocTokens = document1.getTokenizedWords();
        Set<String> expectedTokensOfDoc1 = new HashSet<>(Arrays.asList("hello", "test", "tokenizer"));
        assertEquals(expectedTokensOfDoc1, firstDocTokens);

        Set<String> secondDocTokens = document2.getTokenizedWords();
        Set<String> expectedTokensOfDoc2 = new HashSet<>(Arrays.asList("this", "is", "second", "doc"));
        assertEquals(expectedTokensOfDoc2, secondDocTokens);
    }
}