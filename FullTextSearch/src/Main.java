import java.util.*;


public class Main {


    public static void main(String[] args) {
        //Test Input Output:
        // hello -world -may -> 59463, 59055, 59583, 59134, 59381, 59295, 59615, 58815, 58814
        // hello -world -may +albnyvms -> 59615, 59463, 58077, 59055, 59583, 59134, 58815, 59381, 58814, 58050, 59384, 59295

        String address = "./EnglishData";
        FileReader fileReader = new FileReader(address);
        List<Document> documents = fileReader.createDocumentFromFolder();
        Document.tokenizeAllDocuments(documents);
        QueryProcessor queryProcessor = new QueryProcessor(documents);
        Scanner scanner = new Scanner(System.in);
        while (true) {
            String query = scanner.nextLine().toLowerCase();
            List<String> docIds = queryProcessor.advancedQuery(query);
            System.out.println(docIds);
        }
    }
}