import java.util.ArrayList;

public class Main {

    public static void main(String[] args) {
        String address = "./EnglishData";
        FileReader fileReader = new FileReader(address);
        fileReader.listAllFilesInFolder();
        System.out.println(fileReader.getNamesOfFiles());
        ArrayList<Document> documents = fileReader.createDocumentFromFolder();
        Document.setAllDocumnets(documents);
        documents.get(0).tokenizeContent();
        System.out.println(documents.get(0).getTokenizedWords());

    }
}