import java.util.HashSet;
import java.util.List;
import java.util.Set;
import java.util.StringTokenizer;

public class Tokenizer {

    private Tokenizer() {
        // Because this class don't need to be instanced and is an utility class,
        // we added a private constructor to make it uninstantiable from outside.
    }

    private static final String DELIMITER_SYMBOLS = " ,.;-'()\"@[]><\t\n";

    public static Set<String> tokenizeContent(String content) {
        final StringTokenizer stringTokenizer = new StringTokenizer(content, DELIMITER_SYMBOLS);
        Set<String> tokenizedWords = new HashSet<>();
        while (stringTokenizer.hasMoreTokens()) {
            tokenizedWords.add(stringTokenizer.nextToken());
        }
        return tokenizedWords;
    }

    public static void tokenizeAllDocuments(final List<Document> documents) {
        for (final Document doc : documents) {
            doc.setTokenizedWords(Tokenizer.tokenizeContent(doc.getContent()));
        }
    }

}
