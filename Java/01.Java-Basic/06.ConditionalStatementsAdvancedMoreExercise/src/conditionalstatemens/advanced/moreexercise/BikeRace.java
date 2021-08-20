package conditionalstatemens.advanced.moreexercise;

import java.util.Scanner;

public class BikeRace {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int juniors = Integer.parseInt(scanner.nextLine());
        int seniors = Integer.parseInt(scanner.nextLine());
        String category = scanner.nextLine();

        double juniorPrice = 0.0;
        double seniorPrice = 0.0;
        switch (category) {
            case "cross-country":
                juniorPrice = 8.00;
                seniorPrice = 9.50;
                if (juniors + seniors >= 50) {
                    juniorPrice -= juniorPrice * 0.25;
                    seniorPrice -= seniorPrice * 0.25;
                }
                break;

            case "trail":
                juniorPrice = 5.50;
                seniorPrice = 7.00;
                break;

            case "downhill":
                juniorPrice = 12.25;
                seniorPrice = 13.75;
                break;

            case "road":
                juniorPrice = 20.00;
                seniorPrice = 21.50;
                break;
        }

        double tax = (juniors * juniorPrice) + (seniors * seniorPrice);
        double profit = tax - (tax * 0.05);
        System.out.printf("%.2f", profit);
    }
}
