package whileLoop.lab;

import java.util.Scanner;

public class AccountBalance {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double total = 0;
        String input = scanner.nextLine();
        while (!input.equals("NoMoreMoney")) {
            Double value = Double.parseDouble(input);
            if (value < 0) {
                System.out.println("Invalid operation!");
                break;
            }

            total += value;
            System.out.printf("Increase: %.2f\n", value);
            input = scanner.nextLine();
        }

        System.out.printf("Total: %.2f", total);
    }
}
