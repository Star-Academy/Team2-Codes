

public class Main {

    public static void main(String[] args) {
        String address = "./EnglishData";
        FileReader fileReader = new FileReader(address);
        fileReader.listAllFilesInFolder();
        System.out.println(fileReader.getNamesOfFiles());


    }
}