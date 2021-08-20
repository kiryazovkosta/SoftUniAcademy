package conditionalstatemens.advanced.moreexercise;

import java.util.Scanner;

public class MultiplyByTwo {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double number = Double.parseDouble(scanner.nextLine());
        while (number >= 0) {
            System.out.printf("Result: %.2f%n", number * 2);
            number = Double.parseDouble(scanner.nextLine());
        }

        System.out.println("Negative number!");
    }
}
