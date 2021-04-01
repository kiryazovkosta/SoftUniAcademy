package forLoop.moreExercise;

import java.util.Scanner;

public class GameOfIntervals {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int moves = Integer.parseInt(scanner.nextLine());
        double points = 0;
        int p1 = 0;
        int p2 = 0;
        int p3 = 0;
        int p4 = 0;
        int p5 = 0;
        int p6 = 0;
        for (int i = 0; i < moves; i++) {
            int number = Integer.parseInt(scanner.nextLine());
            if (number >= 0 && number <= 9) {
                p1++;
                points += number * 0.2;
            } else if (number >= 10 && number <= 19) {
                p2++;
                points += number * 0.3;
            } else if (number >= 20 && number <= 29) {
                p3++;
                points += number * 0.4;
            } else if (number >= 30 && number <= 39) {
                p4++;
                points += 50;
            } else if (number >= 40 && number <= 50) {
                p5++;
                points += 100;
            } else {
                p6++;
                points /= 2;
            }
        }

        System.out.printf("%.2f\n", points);
        System.out.printf("From 0 to 9: %.2f%%\n", (p1*1.0)/moves * 100.00);
        System.out.printf("From 10 to 19: %.2f%%\n", (p2*1.0)/moves * 100.00);
        System.out.printf("From 20 to 29: %.2f%%\n", (p3*1.0)/moves * 100.00);
        System.out.printf("From 30 to 39: %.2f%%\n", (p4*1.0)/moves * 100.00);
        System.out.printf("From 40 to 50: %.2f%%\n", (p5*1.0)/moves * 100.00);
        System.out.printf("Invalid numbers: %.2f%%\n", (p6*1.0)/moves * 100.00);

    }
}
