import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class InvertedIndex {

    HashSet<String> tokens; //actually not used
    HashMap<String, HashSet<String>> indices;

    public InvertedIndex() {
        setIndices(new HashMap<>());
        setTokens(new HashSet<>());

    }

    public void makeTokensFromDocuments(ArrayList<Document> documents) {
        for (Document doc : documents) {
            if (doc != null) {
                getTokens().addAll(doc.getTokenizedWords());
            }
        }
    }

    public static ArrayList<String> allStringMatches(Matcher matcher) {
        ArrayList<String> result = new ArrayList<>();
        while (matcher.find()) {
            result.add(matcher.group(1));
        }
        return result;
    }

    public static ArrayList<String> extractAndStatement(String input) {
        Pattern pattern = Pattern.compile("(\\w+)");
        Matcher matcher = pattern.matcher(input);
        ArrayList<String> all = allStringMatches(matcher);
        ArrayList<String> or = extractOrStatement(input);
        ArrayList<String> subs = extractSubStatement(input);
        all.removeAll(or);
        all.removeAll(subs);
        return all;
    }


    public static ArrayList<String> extractOrStatement(String input) {
        Pattern pattern = Pattern.compile("\\+(\\w+)");
        Matcher matcher = pattern.matcher(input);
        return allStringMatches(matcher);
    }


    public static ArrayList<String> extractSubStatement(String input) {
        Pattern pattern = Pattern.compile("-(\\w+)");
        Matcher matcher = pattern.matcher(input);
        return allStringMatches(matcher);
    }

    private HashSet<String> undestructiveOr(HashSet<String> base, HashSet<String> extended) {
        HashSet<String> result = new HashSet<>(base);
        result.addAll(extended);
        return result;
    }

    private HashSet<String> undestructiveAnd(HashSet<String> base, HashSet<String> extended) {
        HashSet<String> result = new HashSet<>(base);
        result.retainAll(extended);
        return result;
    }

    private HashSet<String> undestructiveSubtract(HashSet<String> base, HashSet<String> extended) {
        HashSet<String> result = new HashSet<>(base);
        result.removeAll(extended);
        return result;
    }


    public ArrayList<String> advancedQuery(String input) {

        ArrayList<String> orStrings = extractOrStatement(input);
        ArrayList<String> andStrings = extractAndStatement(input);
        ArrayList<String> subtractStrings = extractSubStatement(input);
        HashSet<String> result = new HashSet<>();


        if (andStrings != null && !andStrings.isEmpty()) {
            result = getIndices().get(andStrings.get(0));
            ;
            for (String andStr : andStrings) {
                HashSet<String> andHashSet = getIndices().get(andStr);
                if (andHashSet != null && !andHashSet.isEmpty()) {
                    result = undestructiveAnd(result, andHashSet);
                }
            }
        }

        if (subtractStrings != null && !subtractStrings.isEmpty()) {
            for (String subtractStr : subtractStrings) {
                HashSet<String> subtractHashSet = getIndices().get(subtractStr);
                if (subtractHashSet != null && !subtractHashSet.isEmpty()) {
                    result = undestructiveSubtract(result, subtractHashSet);
                }
            }
        }

        if (orStrings != null && !orStrings.isEmpty()) {
            for (String orStr : orStrings) {
                HashSet<String> orHashSet = getIndices().get(orStr);
                if (orHashSet != null && !orHashSet.isEmpty()) {
                    result = undestructiveOr(result, orHashSet);
                }
            }
        }
        if (result != null) {
            return new ArrayList<>(result);
        }
        return new ArrayList<>();
    }


    public ArrayList<String> simpleQueryAsSortedArrayList(String oneWord) {
        HashSet<String> answerHashSet = getIndices().get(oneWord);
        ArrayList<String> docIds = new ArrayList<>();
        if (answerHashSet != null && !answerHashSet.isEmpty()) {
            docIds.addAll(answerHashSet);
        }
        Collections.sort(docIds);
        return docIds;
    }

    public void addWordsOfMultipleDocuments(ArrayList<Document> documents) {
        if (documents != null) {
            for (Document document : documents) {
                if (document != null) {
                    addAllWordsOfADocument(document);
                }
            }
        }
        makeTokensFromDocuments(documents); //actually not used :)
    }

    public void addAllWordsOfADocument(Document document) {
        if (document.getTokenizedWords() == null) {
            document.tokenizeContent();
        }
        for (String word : document.getTokenizedWords()) {
            addWord(word, document);
        }

    }


    public void addWord(String word, Document document) {
        if (getIndices().get(word) != null) {
            getIndices().get(word).add(document.getId());
        } else {
            getIndices().put(word, new HashSet<>());
            getIndices().get(word).add(document.getId());
        }
    }

    public HashSet<String> getTokens() {
        return tokens;
    }

    public void setTokens(HashSet<String> tokens) {
        this.tokens = tokens;
    }

    public HashMap<String, HashSet<String>> getIndices() {
        return indices;
    }

    public void setIndices(HashMap<String, HashSet<String>> indices) {
        this.indices = indices;
    }
}
