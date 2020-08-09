

import Model.Document;
import Utility.FileReader;
import Utility.QueryProcessor;
import Utility.Tokenizer;
import View.DocPresenter;

import java.util.*;


public class Main {


    public static void main(String[] args) {

        String address = "./EnglishData";
        QueryProcessor queryProcessor = preparingData(address);
        Scanner scanner = new Scanner(System.in);
        while (true) {
            String query = scanner.nextLine().toLowerCase();
            List<String> docIds = queryProcessor.advancedQuery(query);
            DocPresenter.showSortedDocIds(docIds);
        }
    }

    public static QueryProcessor preparingData(String address) {
        FileReader fileReader = new FileReader(address);
        List<Document> documents = fileReader.getDocuments();
        Tokenizer.tokenizeAllDocuments(documents);
        return new QueryProcessor(documents);
    }
}