import java.util.ArrayList;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class InputProcessor {
    private List<String> andStrings;
    private List<String> orStrings;
    private List<String> subtractString;
    private String inputString;

    public InputProcessor(final String inputString) {
        setInputString(inputString);
        processInput();
    }

    public void processInput() {
        final List<String> and = extractAllQueryWords();
        final List<String> or = extractOrStatement();
        final List<String> subs = extractSubStatement();
        and.removeAll(or);
        and.removeAll(subs);
        setAndStrings(and);
        setOrStrings(or);
        setSubtractString(subs);
    }

    public List<String> wordExtarctor(final Matcher matcher) {
        final List<String> result = new ArrayList<>();
        while (matcher.find()) {
            result.add(matcher.group(1));
        }
        return result;
    }

    public List<String> extractAllQueryWords() {
        final Pattern pattern = Pattern.compile("(\\w+)");
        final Matcher matcher = pattern.matcher(getInputString());
        return wordExtarctor(matcher);
    }

    public List<String> extractOrStatement() {
        final Pattern pattern = Pattern.compile("\\+(\\w+)");
        final Matcher matcher = pattern.matcher(getInputString());
        return wordExtarctor(matcher);
    }

    public List<String> extractSubStatement() {
        final Pattern pattern = Pattern.compile("-(\\w+)");
        final Matcher matcher = pattern.matcher(getInputString());
        return wordExtarctor(matcher);
    }

    public List<String> getAndStrings() {
        return andStrings;
    }

    public void setAndStrings(final List<String> andStrings) {
        this.andStrings = andStrings;
    }

    public List<String> getOrStrings() {
        return orStrings;
    }

    public void setOrStrings(final List<String> orStrings) {
        this.orStrings = orStrings;
    }

    public List<String> getSubtractString() {
        return subtractString;
    }

    public void setSubtractString(final List<String> subtractString) {
        this.subtractString = subtractString;
    }

    public String getInputString() {
        return inputString;
    }

    public void setInputString(final String inputString) {
        this.inputString = inputString;
    }
}
