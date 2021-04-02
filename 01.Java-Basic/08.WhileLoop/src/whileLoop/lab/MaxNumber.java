package whileLoop.lab;

import java.util.Scanner;

public class MaxNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int max = Integer.MIN_VALUE;
        String input = scanner.nextLine();
        while (!input.equals("Stop")) {
            int number = Integer.parseInt(input);
            if (number > max) {
                max = number;
            }

            input = scanner.nextLine();
        }

        System.out.println(max);
    }
}
