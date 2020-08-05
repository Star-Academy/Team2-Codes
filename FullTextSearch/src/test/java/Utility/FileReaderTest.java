package Utility;

import static org.junit.jupiter.api.Assertions.assertEquals;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import org.junit.Before;
import org.junit.Test;

import Model.Document;

public class FileReaderTest {
    private final String path = "./SmallEnglishData";
    private final String unavailableFileName = "10.txt";
    private final String availableFileName = "1.txt";
    private FileReader fileReader;
    
    @Before
    @Test
    public void initialize() {
        fileReader = new FileReader(path);
        assertEquals(path, fileReader.getFolderAddress());
    }
    
    @Test
    public void testListAllFilesInFolder() {
        List<String> expectedFileName = new ArrayList<>(Arrays.asList("1.txt", "2.txt", "3.txt", "4.txt"));

        List<String> actualFileName = fileReader.getNamesOfFiles();

        assertEquals(expectedFileName, actualFileName);
    }

    @Test
    public void testGetDocuments() {
        List<Document> expectedDocuments = new ArrayList<>();
        expectedDocuments.add(new Document("1.txt", "hello"));
        expectedDocuments.add(new Document("2.txt", "hello may"));
        expectedDocuments.add(new Document("3.txt", "hello world"));
        expectedDocuments.add(new Document("4.txt", "albnyvms world may"));

        List<Document> actualDocuments = fileReader.getDocuments();

        assertEquals(expectedDocuments, actualDocuments);
    }

    @Test
    public void testReadOneFile() {
        //file doesn't exist, readOneFile() return ""
        String actualContent = fileReader.readOneFile(unavailableFileName);
        assertEquals("", actualContent);

        actualContent = fileReader.readOneFile(availableFileName);
        assertEquals("hello", actualContent);
    }
}