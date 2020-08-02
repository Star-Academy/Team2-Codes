import java.util.ArrayList;
import java.util.HashSet;
import java.util.StringTokenizer;

public class Document {

    private static ArrayList<Document> allDocumnets = new ArrayList<>();
    private String id;
    private String content;
    private HashSet<String> tokenizedWords;

    public Document(String id, String content) {
        setId(id);
        setContent(content);
        setTokenizedWords(new HashSet<>());
    }




    public static Document findDocumentById(String id) {
        for (Document doc : getAllDocumnets()) {
            if (doc != null && doc.getId().equals(id)) {
                return doc;

            }
        }
        return null;
    }

    public void tokenizeContent() {
        StringTokenizer stringTokenizer = new StringTokenizer(getContent(), " ,.;-'()\"@[]><");
        while (stringTokenizer.hasMoreTokens()) {
            getTokenizedWords().add(stringTokenizer.nextToken());
        }
    }

    public static void tokenizeAllDocuments() {
        for (Document doc : getAllDocumnets()) {
            doc.tokenizeContent();
        }
    }

    public String getId() {
        return this.id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getContent() {
        return this.content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    public static ArrayList<Document> getAllDocumnets() {
        return allDocumnets;
    }

    public static void setAllDocumnets(ArrayList<Document> allDocumnets) {
        Document.allDocumnets = allDocumnets;
    }

    public HashSet<String> getTokenizedWords() {
        return tokenizedWords;
    }

    public void setTokenizedWords(HashSet<String> tokenizedWords) {
        this.tokenizedWords = tokenizedWords;
    }

    @Override
    public String toString() {
        return "Document{" + "id='" + id + '\'' + ", content='" + content + '\'' + '}';
    }
}