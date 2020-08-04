package View;

import java.util.Collections;
import java.util.List;

public class DocPresenter {

    public static void showSortedDocIds(List<String> docIds)
    {
        Collections.sort(docIds);
        System.out.println(docIds);
    }

}
