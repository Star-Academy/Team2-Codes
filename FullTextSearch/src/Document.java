import java.util.*;

public class Document {

    private String id;
    private String content;
    private Set<String> tokenizedWords;

    public Document(final String id, final String content) {
        setId(id);
        setContent(content);
        setTokenizedWords(new HashSet<>());
    }

    public static Document findDocumentById(final String id, final List<Document> documents) {
        Document document = null;
        for (final Document doc : documents) {
            if (doc != null && doc.getId().equals(id)) {
                document = doc;
                break;
            }
        }
        return document;
    }


    public String getId() {
        return this.id;
    }

    public void setId(final String id) {
        this.id = id;
    }

    public String getContent() {
        return this.content;
    }

    public void setContent(final String content) {
        this.content = content;
    }

    public Set<String> getTokenizedWords() {
        return tokenizedWords;
    }

    public void setTokenizedWords(final Set<String> tokenizedWords) {
        this.tokenizedWords = tokenizedWords;
    }

    @Override
    public String toString() {
        return "Document{" + "id='" + id + '\'' + ", content='" + content + '\'' + '}';
    }
}