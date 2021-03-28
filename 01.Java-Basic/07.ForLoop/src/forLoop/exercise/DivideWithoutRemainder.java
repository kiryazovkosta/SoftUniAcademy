package forLoop.exercise;

import java.util.Scanner;

public class DivideWithoutRemainder {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int p1 = 0;
        int p2 = 0;
        int p3 = 0;
        int size = Integer.parseInt(scanner.nextLine());
        for (int i = 0; i < size ; i++) {
            int number = Integer.parseInt(scanner.nextLine());
            if (number % 2 == 0) {
                p1++;
            }
            if (number % 3 == 0) {
                p2++;
            }
            if (number % 4 == 0) {
                p3++;
            }
        }

        double p1p = ((p1*1.0/size)*100);
        double p2p = ((p2*1.0/size)*100);
        double p3p = ((p3*1.0/size)*100);
        System.out.printf("%.2f%%\n", p1p);
        System.out.printf("%.2f%%\n", p2p);
        System.out.printf("%.2f%%\n", p3p);
    }
}
