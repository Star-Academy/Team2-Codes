import java.util.ArrayList;
import java.util.StringTokenizer;

public class Document {

    private static ArrayList<Document> allDocumnets = new ArrayList<>();
    private String id;
    private String content;
    private ArrayList<String> tokenizedWords;

    public Document(String id, String content) {
        setId(id);
        setContent(content);
        setTokenizedWords(new ArrayList<>());
    }

    public void tokenizeContent() {
        StringTokenizer stringTokenizer = new StringTokenizer(getContent(), " ,.;-'()\"");
        while (stringTokenizer.hasMoreTokens()) {
            getTokenizedWords().add(stringTokenizer.nextToken());
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

    public ArrayList<String> getTokenizedWords() {
        return tokenizedWords;
    }

    public void setTokenizedWords(ArrayList<String> tokenizedWords) {
        this.tokenizedWords = tokenizedWords;
    }

    @Override
    public String toString() {
        return "Document{" +
                "id='" + id + '\'' +
                ", content='" + content + '\'' +
                '}';
    }
}