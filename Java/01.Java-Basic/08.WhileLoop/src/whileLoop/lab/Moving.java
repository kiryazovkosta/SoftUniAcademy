package whileLoop.lab;

import java.util.Scanner;

public class Moving {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int a = Integer.parseInt(scanner.nextLine());
        int b = Integer.parseInt(scanner.nextLine());
        int h = Integer.parseInt(scanner.nextLine());
        int free = a * b * h;

        String input = scanner.nextLine();
        while (!input.equals("Done")) {
            int boxes = Integer.parseInt(input);
            free -= boxes;
            if (free <= 0) {
                break;
            }
            input = scanner.nextLine();
        }

        if (free >= 0) {
            System.out.printf("%d Cubic meters left.\n", free);
        } else {
            System.out.printf("No more free space! You need %d Cubic meters more.", Math.abs(free));
        }
    }
}
