package forLoop.moreExercise;

import java.util.Scanner;

public class EqualPairs {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int prevDiff = 0;
        int maxDiff = 0;
        int firstSum = 0;

        int size = Integer.parseInt(scanner.nextLine());
        for (int i = 0; i < size; i++) {
            int a = Integer.parseInt(scanner.nextLine());
            int b = Integer.parseInt(scanner.nextLine());
            int sum = a + b;

            if (i == 0) {
                firstSum = sum;
                prevDiff = sum;
                maxDiff = sum;
            } else {
                if (sum != prevDiff)
                {
                    maxDiff = Math.abs(sum - prevDiff);
                }

                prevDiff = sum;
            }
        }

        if (maxDiff == firstSum) {
            System.out.printf("Yes, value=%d", maxDiff);
        }
        else {
            System.out.printf("No, maxdiff=%d", maxDiff);
        }
    }
}
