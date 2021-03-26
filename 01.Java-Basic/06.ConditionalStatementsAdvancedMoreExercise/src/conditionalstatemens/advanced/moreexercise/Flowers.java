package conditionalstatemens.advanced.moreexercise;

import java.util.Scanner;

public class Flowers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int chrysanthemums = Integer.parseInt(scanner.nextLine());
        int roses = Integer.parseInt(scanner.nextLine());
        int tulips = Integer.parseInt(scanner.nextLine());
        String season = scanner.nextLine();
        String holiday = scanner.nextLine();

        double chrysanthemumPrice = 0.0;
        double rosePrice = 0.0;
        double tulipPrice = 0.0;

        switch (season) {
            case "Spring":
            case "Summer":
                chrysanthemumPrice = 2.0;
                rosePrice = 4.1;
                tulipPrice = 2.5;
                break;

            case "Autumn":
            case "Winter":
                chrysanthemumPrice = 3.75;
                rosePrice = 4.5;
                tulipPrice = 4.15;
                break;
        }

        double flowerPrice = (chrysanthemums * chrysanthemumPrice)
                + (roses * rosePrice)
                + (tulips * tulipPrice);
        if (holiday.equals("Y")) {
            flowerPrice += flowerPrice * 0.15;
        }

        if (season.equals("Spring") && tulips > 7) {
            flowerPrice -= flowerPrice * 0.05;
        }

        if (season.equals("Winter") && roses >= 10) {
            flowerPrice -= flowerPrice * 0.1;
        }

        if (chrysanthemums + roses + tulips > 20) {
            flowerPrice -= flowerPrice * 0.2;
        }

        flowerPrice += 2;
        System.out.printf("%.2f", flowerPrice);
    }
}
