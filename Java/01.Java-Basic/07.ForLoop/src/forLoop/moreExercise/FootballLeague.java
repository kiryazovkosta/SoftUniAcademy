package forLoop.moreExercise;

import java.util.Scanner;

public class FootballLeague {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double p1 = 0;
        double p2 = 0;
        double p3 = 0;
        double p4 = 0;
        int capacity = Integer.parseInt(scanner.nextLine());
        int fans = Integer.parseInt(scanner.nextLine());
        for (int i = 0; i < fans; i++) {
            String sector = scanner.nextLine();
            switch (sector) {
                case "A":
                    p1++;
                    break;
                case "B":
                    p2++;
                    break;
                case "V":
                    p3++;
                    break;
                case "G":
                    p4++;
                    break;
                default:
                    break;
            }
        }

        double total = p1 + p2 + p3 + p4;
        System.out.printf("%.2f%%\n", (p1 / total) * 100);
        System.out.printf("%.2f%%\n", (p2 / total) * 100);
        System.out.printf("%.2f%%\n", (p3 / total) * 100);
        System.out.printf("%.2f%%\n", (p4 / total) * 100);
        System.out.printf("%.2f%%\n", (total / capacity) * 100);
    }
}
