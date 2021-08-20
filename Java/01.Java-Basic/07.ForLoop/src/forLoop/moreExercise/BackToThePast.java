package forLoop.moreExercise;

import java.util.Scanner;

public class BackToThePast {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double heritage = Double.parseDouble(scanner.nextLine());
        int maxYear = Integer.parseInt(scanner.nextLine());
        int age = 18;
        for (int year = 1800; year<= maxYear; year++) {
            if (year % 2 == 0) {
                heritage -= 12000;
            } else {
                heritage -= 12000 + 50 * age;
            }
            age++;
        }

        if (heritage >= 0) {
            System.out.printf("Yes! He will live a carefree life and will have %.2f dollars left.", heritage);
        } else {
            System.out.printf("He will need %.2f dollars to survive.", Math.abs((heritage)));
        }
    }
}
