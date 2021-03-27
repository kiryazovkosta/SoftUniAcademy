package forLoop.lab;

import java.util.Scanner;

public class OddEvenSum {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int size = Integer.parseInt(scanner.nextLine());
        int oddSum = 0;
        int evenSum = 0;
        for (int i = 1; i <= size; i++) {
            int number = Integer.parseInt(scanner.nextLine());
            if (i % 2 == 0) {
                evenSum += number;
            } else {
                oddSum += number;
            }
        }

        if (oddSum == evenSum) {
            System.out.printf("Yes\nSum = %d\n", oddSum);
        } else {
            System.out.printf("No\nDiff = %d\n", Math.abs(oddSum-evenSum));
        }
    }
}
