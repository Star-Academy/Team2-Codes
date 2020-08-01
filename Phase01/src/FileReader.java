import java.io.File;
import java.util.ArrayList;

public class FileReader {

    private String folderAddress;

    private ArrayList<String> namesOfFiles;

    public FileReader(String address) {
        setFolderAddress(address);
        setNamesOfFiles(new ArrayList<>());
    }

    public void listAllFilesInFolder() {
        File folder = new File(folderAddress);
        File[] allFiles = folder.listFiles();
        for (File file : allFiles) {
            if (file.isFile()) {
                getNamesOfFiles().add(file.getName());
            }
        }
    }

    public void readOneFile(String address){
        File file = new File(address);
        

    }

    public ArrayList<String> getNamesOfFiles() {
        return this.namesOfFiles;
    }

    public void setNamesOfFiles(ArrayList<String> namesOfFiles) {
        this.namesOfFiles = namesOfFiles;
    }

    public String getFolderAddress() {
        return this.folderAddress;
    }

    public void setFolderAddress(String folderAddress) {
        this.folderAddress = folderAddress;
    }

}