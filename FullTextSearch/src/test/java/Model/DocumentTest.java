package Model;

import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

import static org.junit.jupiter.api.Assertions.*;

class DocumentTest {

    @Test
    public void getSetIdTest() {
        String id = "10";
        String id2 = "testingId";
        Document document = new Document(id, "ignore");
        assertEquals(id, document.getId());
        document.setId(id2);
        assertEquals(id2, document.getId());
    }

    @Test
    public void findDocumentByIdExistingTest() {
        Document document = new Document("1", "test1");
        Document document2 = new Document("2", "test1");
        Document document3 = new Document("3", "test1");

        Document answer = Document.findDocumentById("2",
                new ArrayList<>(Arrays.asList(document, document2, document3)));

        assertEquals(document2,answer);
    }

    @Test
    public void findDocumentByIdNonExistingTest() {
        Document document = new Document("1", "test1");
        Document document2 = new Document("2", "test1");
        Document document3 = new Document("3", "test1");

        Document answer = Document.findDocumentById("4",
                new ArrayList<>(Arrays.asList(document, document2, document3)));

        assertNull(answer);
    }

    @Test
    public void getSetContent() {
        String content = "hello world";
        String content2 = "hello world\n\nit is a test message";
        Document document = new Document("id", content);
        assertEquals(content, document.getContent());
        document.setContent(content2);
        assertEquals(content2, document.getContent());
    }

    @Test
    public void getSetTokenizedWords() {
        Document document = new Document("id", "ignore");
        Set<String> tokenizedTest = new HashSet<>(Arrays.asList("1", "2", "3"));
        document.setTokenizedWords(tokenizedTest);
        assertEquals(tokenizedTest, document.getTokenizedWords());
    }

    @Test
    public void toStringTest() {
        String id = "myId";
        String content = "This is my Content \n Hello World";
        Document document = new Document(id, content);
        String expected = "Model.Document{" + "id='" + id + '\'' + ", content='" + content + '\'' + '}';
        assertEquals(expected, document.toString());
    }

    @Test
    public void equalityTestWithOtherObject() {
        Document document = new Document("id", "content");
        Object objectOfOtherType = new Object();
        assertNotEquals(document, objectOfOtherType);
    }

    @Test
    public void equalityTestWithCompleteSameDocument() {
        Document document = new Document("id", "content");
        Document document2 = new Document("id", "content");
        assertEquals(document, document2);
    }

    @Test
    public void equalityTestWithDifferentId() {
        Document document = new Document("id", "content");
        Document document2 = new Document("id2", "content");
        assertNotEquals(document, document2);
    }

    @Test
    public void equalityTestWithDifferentContet() {
        Document document = new Document("id", "content");
        Document document2 = new Document("id", "content2");
        assertNotEquals(document, document2);
    }


}