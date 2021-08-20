import java.util.Scanner;

public class MetricConverter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double number = Double.parseDouble(scanner.nextLine());
        String input = scanner.nextLine();
        String output = scanner.nextLine();

        if (input.equals("mm")) {
            number = number * 1;
        } else if (input.equals("cm")) {
            number = number * 10;
        } else {
            number = number * 1000;
        }

        if (output.equals("mm")) {
            number = number / 1;
        } else if (output.equals("cm")) {
            number = number / 10;
        } else {
            number = number / 1000;
        }

        System.out.printf("%.3f", number);
    }
}
