package whileLoop.lab;

import java.util.Scanner;

public class GraduationPartTwo {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String name = scanner.nextLine();
        int cls = 1;
        int minCounter = 0;
        double total = 0;
        while ( cls <= 12) {
            double grade = Double.parseDouble(scanner.nextLine());
            if (grade < 4.00) {
                minCounter++;
            }

            if (minCounter >= 2) {
                System.out.printf("%s has been excluded at %d grade", name, cls -1);
                break;
            }

            total += grade;
            cls++;
        }

        if (minCounter < 2) {
            System.out.printf("%s graduated. Average grade: %.2f\n", name, total /12);
        }
    }
}
