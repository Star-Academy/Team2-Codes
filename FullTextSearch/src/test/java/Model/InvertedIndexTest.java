package Model;

import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import java.util.*;

import static org.junit.jupiter.api.Assertions.*;

class InvertedIndexTest {

    private static List<Document> documentList;
    private static InvertedIndex invertedIndex;

    @BeforeAll
    public static void initialize() {
        Document document = new Document("1", "hello world");
        Document document2 = new Document("2", "hello man");
        Document document3 = new Document("3", "man world");
        invertedIndex = new InvertedIndex();
        documentList = new ArrayList<>(Arrays.asList(document, document2, document3));
    }

    @Test
    public void addWordTest() {
        invertedIndex.addWord("hello", documentList.get(0));
        org.assertj.core.api.Assertions.
                assertThat(invertedIndex.getIndices().get("hello")).containsOnly("1");
    }

    @Test
    public void addWordTestOfNonExistingWord() {
        invertedIndex.addWord("hello", documentList.get(0));
        assertNull(invertedIndex.getIndices().get("man"));
    }

    @Test
    public void addWordsOfADocumentTest() {
        invertedIndex.addAllWordsOfADocument(documentList.get(0));
        org.assertj.core.api.Assertions.
                assertThat(invertedIndex.getIndices().get("hello")).containsOnly("1");
        org.assertj.core.api.Assertions.
                assertThat(invertedIndex.getIndices().get("world")).containsOnly("1");
        assertNull(invertedIndex.getIndices().get("man"));
    }

    @Test
    public void addWordsOfMultipleDocuments() {
        invertedIndex.addWordsOfMultipleDocuments(documentList);
        org.assertj.core.api.Assertions.
                assertThat(invertedIndex.getIndices().get("hello")).containsOnly("1", "2");
        org.assertj.core.api.Assertions.
                assertThat(invertedIndex.getIndices().get("world")).containsOnly("1", "3");
        org.assertj.core.api.Assertions.
                assertThat(invertedIndex.getIndices().get("man")).containsOnly("2", "3");


    }


    @Test
    public void getSetIndicesTest() {
        Map<String, Set<String>> map = new HashMap<>();
        map.put("Hello", new HashSet<>(Arrays.asList("1", "2")));
        invertedIndex.setIndices(map);
        assertEquals(map, invertedIndex.getIndices());
    }

}