package forLoop.exercise;

import java.util.Scanner;

public class OddEvenPosition {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double oddSum = 0;
        double oddMin = Integer.MAX_VALUE;
        double oddMax = Integer.MIN_VALUE;
        double evenSum = 0;
        double evenMin = Integer.MAX_VALUE;;
        double evenMax = Integer.MIN_VALUE;

        int size = Integer.parseInt(scanner.nextLine());
        for (int i = 1; i <= size ; i++) {
            double number = Double.parseDouble(scanner.nextLine());
            if (i % 2 != 0) {
                oddSum += number;
                if (number < oddMin) {
                    oddMin = number;
                }
                if (number > oddMax) {
                    oddMax = number;
                }
            } else {
                evenSum += number;
                if (number < evenMin) {
                    evenMin = number;
                }
                if (number > evenMax) {
                    evenMax = number;
                }
            }
        }

        System.out.printf("OddSum=%.2f,\n", oddSum);
        if (size > 0) {
            System.out.printf("OddMin=%.2f,\n", oddMin);
            System.out.printf("OddMax=%.2f,\n", oddMax);
        } else {
            System.out.printf("OddMin=No,\n", oddMin);
            System.out.printf("OddMax=No,\n", oddMax);
        }

        System.out.printf("EvenSum=%.2f,\n", evenSum);
        if (size > 1) {
            System.out.printf("EvenMin=%.2f,\n", evenMin);
            System.out.printf("EvenMax=%.2f", evenMax);
        } else {
            System.out.printf("EvenMin=No,\n", oddMin);
            System.out.printf("EvenMax=No", oddMax);
        }
    }

}
