package whileLoop.exercise;

import java.util.Scanner;

public class Cake {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int a = Integer.parseInt(scanner.nextLine());
        int b = Integer.parseInt(scanner.nextLine());
        int size = a * b;
        String input = scanner.nextLine();
        while (!input.equals("STOP")) {
            int pieces = Integer.parseInt(input);
            size -= pieces;
            if (size < 0) {
                break;
            }

            input = scanner.nextLine();
        }

        if (size >= 0) {
            System.out.printf("%d pieces are left.", size);
        } else {
            System.out.printf("No more cake left! You need %d pieces more.", Math.abs(size));
        }
    }
}
