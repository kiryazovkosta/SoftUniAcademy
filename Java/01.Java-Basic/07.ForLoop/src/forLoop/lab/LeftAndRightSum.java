package forLoop.lab;

import java.util.Scanner;

public class LeftAndRightSum {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int size = Integer.parseInt(scanner.nextLine());
        int leftSum = 0;
        for (int i = 0; i < size; i++) {
            int number = Integer.parseInt(scanner.nextLine());
            leftSum += number;
        }
        int rightSum = 0;
        for (int i = 0; i < size; i++) {
            int number = Integer.parseInt(scanner.nextLine());
            rightSum += number;
        }

        if (leftSum == rightSum) {
            System.out.printf("Yes, sum = %d%n", leftSum);
        } else {
            System.out.printf("No, diff = %d%n", Math.abs(leftSum-rightSum));
        }
    }
}
