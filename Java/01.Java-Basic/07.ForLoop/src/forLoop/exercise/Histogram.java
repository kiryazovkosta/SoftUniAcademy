package forLoop.exercise;

import java.util.Scanner;

public class Histogram {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int p1 = 0;
        int p2 = 0;
        int p3 = 0;
        int p4 = 0;
        int p5 = 0;
        int size = Integer.parseInt(scanner.nextLine());
        for (int i = 0; i < size ; i++) {
            int number = Integer.parseInt(scanner.nextLine());
            if (number < 200) {
                p1++;
            } else if (number >= 200 && number <= 399) {
                p2++;
            } else if (number >= 400 && number <= 599) {
                p3++;
            } else if (number >= 600 && number <= 799) {
                p4++;
            } else {
                p5++;
            }
        }

        double p1p = ((p1*1.0/size)*100);
        double p2p = ((p2*1.0/size)*100);
        double p3p = ((p3*1.0/size)*100);
        double p4p = ((p4*1.0/size)*100);
        double p5p = ((p5*1.0/size)*100);
        System.out.printf("%.2f%%\n", p1p);
        System.out.printf("%.2f%%\n", p2p);
        System.out.printf("%.2f%%\n", p3p);
        System.out.printf("%.2f%%\n", p4p);
        System.out.printf("%.2f%%\n", p5p);
    }
}
