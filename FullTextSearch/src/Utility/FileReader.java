package Utility;

import Model.Document;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class FileReader {

    private String folderAddress;

    private List<String> namesOfFiles;


    public FileReader(final String address) {
        setFolderAddress(address);
        setNamesOfFiles(new ArrayList<>());
        listAllFilesInFolder();
    }

    public void listAllFilesInFolder() {
        final File folder = new File(getFolderAddress());
        final File[] allFiles = folder.listFiles();
        if (allFiles != null) {
            for (final File file : allFiles) {
                if (file.isFile()) {
                    getNamesOfFiles().add(file.getName());
                }
            }
        }
    }

    public List<Document> getDocuments() {
        final List<Document> documents = new ArrayList<>();
        if (getNamesOfFiles().isEmpty()) {
            listAllFilesInFolder();
        }
        for (final String filename : getNamesOfFiles()) {
            final String fileContent = readOneFile(filename);
            final Document document = new Document(filename, fileContent);
            documents.add(document);
        }
        return documents;
    }

    public String readOneFile(final String address) {
        final StringBuilder stringBuilder = new StringBuilder("");
        try {
            final File file = new File(getFolderAddress() + "/" + address);
            final Scanner fileReader = new Scanner(file);
            while (fileReader.hasNext()) {
                final String data = fileReader.nextLine();
                stringBuilder.append(data.toLowerCase());
            }
            fileReader.close();
        } catch (final FileNotFoundException e) {
            System.err.println("File Not Found");
            e.printStackTrace();
        }
        return stringBuilder.toString();

    }

    public List<String> getNamesOfFiles() {
        return this.namesOfFiles;
    }

    public void setNamesOfFiles(final List<String> namesOfFiles) {
        this.namesOfFiles = namesOfFiles;
    }

    public String getFolderAddress() {
        return this.folderAddress;
    }

    public void setFolderAddress(final String folderAddress) {
        this.folderAddress = folderAddress;
    }

}