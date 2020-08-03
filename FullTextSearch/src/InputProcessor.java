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
        final List<String> and = extractAllQueryWords(getInputString());
        final List<String> or = extractOrStatement(getInputString());
        final List<String> subs = extractSubStatement(getInputString());
        and.removeAll(or);
        and.removeAll(subs);
        setAndStrings(and);
        setOrStrings(or);
        setSubtractString(subs);
    }

    public static List<String> wordExtarctor(final Matcher matcher) {
        final List<String> result = new ArrayList<>();
        while (matcher.find()) {
            result.add(matcher.group(1));
        }
        return result;
    }

    public static List<String> extractAllQueryWords(final String input) {
        final Pattern pattern = Pattern.compile("(\\w+)");
        final Matcher matcher = pattern.matcher(input);
        return wordExtarctor(matcher);
    }

    public static List<String> extractOrStatement(final String input) {
        final Pattern pattern = Pattern.compile("\\+(\\w+)");
        final Matcher matcher = pattern.matcher(input);
        return wordExtarctor(matcher);
    }

    public static List<String> extractSubStatement(final String input) {
        final Pattern pattern = Pattern.compile("-(\\w+)");
        final Matcher matcher = pattern.matcher(input);
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
