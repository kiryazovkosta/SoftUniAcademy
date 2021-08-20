package forLoop.exercise;

import java.util.Scanner;

public class HalfSumElement {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int size = Integer.parseInt(scanner.nextLine());

        int max = Integer.MIN_VALUE;
        int sum = 0;
        for (int i = 0; i < size; i++) {
            int number = Integer.parseInt(scanner.nextLine());
            sum += number;
            if (number > max) {
                max = number;
            }
        }

        if (sum - max == max) {
            System.out.printf("Yes\nSum = %d\n", max);
        } else {
            System.out.printf("No\nDiff = %d\n", Math.abs(max - (sum - max)));
        }
    }
}
