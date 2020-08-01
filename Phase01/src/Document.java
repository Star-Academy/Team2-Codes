public class Document {

    private int id;
    private String content;

    public Document(int id, String content) {
        setId(id);
        setContent(content);
    }

    public int getId() {
        return this.id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getContent() {
        return this.content;
    }

    public void setContent(String content) {
        this.content = content;
    }

}