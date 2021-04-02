package whileLoop.exercise;

import java.util.Scanner;

public class OldBooks {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int counter = 0;
        Boolean isFound = false;
        String myBook = scanner.nextLine();
        String input = scanner.nextLine();
        while (!input.equals("No More Books")) {
            if (input.equals(myBook)) {
                isFound = true;
                break;
            }

            counter++;
            input = scanner.nextLine();
        }

        if (isFound) {
            System.out.printf("You checked %d books and found it.\n", counter);
        } else {
            System.out.printf("The book you search is not here!\n");
            System.out.printf("You checked %d books.", counter);
        }
    }
}
