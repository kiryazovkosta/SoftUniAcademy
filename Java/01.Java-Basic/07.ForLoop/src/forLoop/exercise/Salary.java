package forLoop.exercise;

import java.util.Scanner;

public class Salary {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int facebookPrice = 150;
        int instagramPrice = 100;
        int redditPrice = 50;

        int tabsSize = Integer.parseInt(scanner.nextLine());
        double salary = Double.parseDouble(scanner.nextLine());
        for (int i = 0; i < tabsSize; i++) {
            String site = scanner.nextLine();
            switch (site) {
                case "Facebook":
                    salary -= facebookPrice;
                    break;
                case "Instagram":
                    salary -= instagramPrice;
                    break;
                case "Reddit":
                    salary -= redditPrice;
                    break;
                default:
                    break;
            }

            if (salary <= 0) {
                System.out.println("You have lost your salary.");
                break;
            }
        }

        if (salary > 0) {
            System.out.printf("%.0f", salary);
        }
    }
}
