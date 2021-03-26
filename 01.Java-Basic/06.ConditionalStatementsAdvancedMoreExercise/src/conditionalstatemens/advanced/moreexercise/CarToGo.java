package conditionalstatemens.advanced.moreexercise;

import java.util.Scanner;

public class CarToGo {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double budget = Double.parseDouble(scanner.nextLine());
        String season = scanner.nextLine();

        String category = "";
        String vehicle = "Jeep";
        double price = 0.0;

        if (budget <= 100) {
            category = "Economy class";
            if (season.equals("Summer")) {
                vehicle = "Cabrio";
                price = budget * 0.35;
            } else {
                price = budget * 0.65;
            }
        } else if (budget > 100 && budget <= 500) {
            category = "Compact class";
            if (season.equals("Summer")) {
                vehicle = "Cabrio";
                price = budget * 0.45;
            } else {
                price = budget * 0.80;
            }
        } else if (budget > 500) {
            category = "Luxury class";
            price = budget * 0.9;
        }

        System.out.printf("%s%n", category);
        System.out.printf("%s - %.2f", vehicle, price);
    }
}
