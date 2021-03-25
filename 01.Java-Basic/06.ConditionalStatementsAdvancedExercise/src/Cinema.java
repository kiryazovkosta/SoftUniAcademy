package ConditionalStatementsAdvancedExercise;

import java.util.Scanner;

public class Cinema {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String type = scanner.nextLine();
        int rows = scanner.nextInt();
        int cols = scanner.nextInt();

        double income = 0.0;
        if (type.equals("Premiere")) {
            income = rows * cols * 12.0;
        } else if (type.equals("Normal")) {
            income = rows * cols * 7.5;
        } else if (type.equals("Discount")) {
            income = rows * cols * 5;
        }

        System.out.printf("%.2f", income);
    }
}
