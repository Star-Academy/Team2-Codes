import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

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

    public ArrayList<Document> createDocumentFromFolder() {
        ArrayList<Document> documents = new ArrayList<>();
        if (namesOfFiles.isEmpty()) {
            listAllFilesInFolder();
        }
        for (String filename : getNamesOfFiles()) {
            String fileContent = readOneFile(filename);
            Document document = new Document(filename, fileContent);
            documents.add(document);
        }
        return documents;
    }

    public String readOneFile(String address) {
        try {
            File file = new File(getFolderAddress() + "/" + address);
            Scanner fileReader = new Scanner(file);
            StringBuilder stringBuilder = new StringBuilder();
            while (fileReader.hasNext()) {
                String data = fileReader.nextLine();
                stringBuilder.append(data.toLowerCase());
            }
            fileReader.close();
            return stringBuilder.toString();
        } catch (FileNotFoundException e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
        }
        return "";

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