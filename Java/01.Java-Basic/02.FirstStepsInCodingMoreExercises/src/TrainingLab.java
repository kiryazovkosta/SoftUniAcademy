import java.util.Scanner;

public class TrainingLab {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double w = Double.parseDouble(scanner.nextLine());
        double h = Double.parseDouble(scanner.nextLine());

        int wCentimeters = (int)(w * 100);
        int hCentimeters = (int)(h * 100);

        int wCount = wCentimeters / 120;
        int hCount = (hCentimeters - 100) / 70;
        int total = (wCount * hCount) - 3;
        System.out.println(total);
    }
}
