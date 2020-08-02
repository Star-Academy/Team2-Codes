import java.util.ArrayList;
import java.util.Collections;
import java.util.HashSet;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Main {



    public static void main(String[] args) {

        // hello -world -may -> 59463, 59055, 59583, 59134, 59381, 59295, 59615, 58815, 58814
        //
        // hello -world -may +albnyvms -> 59615, 59463, 58077, 59055, 59583, 59134, 58815, 59381, 58814, 58050, 59384, 59295
        //
        //
        String address = "./EnglishData";
        FileReader fileReader = new FileReader(address);
        fileReader.listAllFilesInFolder();
        System.out.println(fileReader.getNamesOfFiles());
        ArrayList<Document> documents = fileReader.createDocumentFromFolder();
        Document.setAllDocumnets(documents);
        Document.tokenizeAllDocuments();
        InvertedIndex invertedIndex = new InvertedIndex();
        invertedIndex.addWordsOfMultipleDocuments(Document.getAllDocumnets());
        Scanner scanner = new Scanner(System.in);
        while (true) {
            String query = scanner.nextLine();
            ArrayList<String> docIds = invertedIndex.advancedQuery(query);
            System.out.println(docIds);
        }


    }
}