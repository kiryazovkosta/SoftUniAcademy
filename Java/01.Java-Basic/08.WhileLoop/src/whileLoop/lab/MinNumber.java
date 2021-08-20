package whileLoop.lab;

import java.util.Scanner;

public class MinNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int min = Integer.MAX_VALUE;
        String input = scanner.nextLine();
        while (!input.equals("Stop")) {
            int value = Integer.parseInt(input);
            if (value < min) {
                min = value;
            }

            input = scanner.nextLine();
        }

        System.out.println(min);
    }
}
