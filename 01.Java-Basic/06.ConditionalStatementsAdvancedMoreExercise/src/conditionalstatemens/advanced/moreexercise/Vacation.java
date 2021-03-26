package conditionalstatemens.advanced.moreexercise;

import java.util.Scanner;

public class Vacation {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double budget = Double.parseDouble(scanner.nextLine());
        String season = scanner.nextLine();

        String category = "";
        String destination = "Alaska";
        double price = 0.0;
        if (budget <= 1000) {
            category = "Camp";
            if (season.equals("Summer")) {
                price = budget * 0.65;
            } else if (season.equals("Winter")) {
                destination = "Morocco";
                price = budget * 0.45;
            }
        } else if (budget > 1000 && budget <= 3000) {
            category = "Hut";
            if (season.equals("Summer")) {
                price = budget * 0.80;
            } else if (season.equals("Winter")) {
                destination = "Morocco";
                price = budget * 0.60;
            }
        } else if (budget > 3000) {
            category = "Hotel";
            price = budget * 0.9;
            if (season.equals("Winter")) {
                destination = "Morocco";
            }
        }

        System.out.printf("%s - %s - %.2f", destination, category, price);
    }
}
