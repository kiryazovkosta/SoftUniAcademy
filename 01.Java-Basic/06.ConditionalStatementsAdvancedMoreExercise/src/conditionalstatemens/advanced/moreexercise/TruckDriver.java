package conditionalstatemens.advanced.moreexercise;

import java.util.Scanner;

public class TruckDriver {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String season = scanner.nextLine();
        double kilometersPerMonth = Double.parseDouble(scanner.nextLine());
        double pricePerKilometer = 0.0;
        if (kilometersPerMonth <= 5000) {
            switch (season) {
                case "Spring":
                case  "Autumn":
                    pricePerKilometer = 0.75;
                    break;
                case "Summer":
                    pricePerKilometer = 0.90;
                    break;
                case "Winter":
                    pricePerKilometer = 1.05;
                    break;
                default:
                    break;
            }
        } else if (kilometersPerMonth > 5000 && kilometersPerMonth <= 10000) {
            switch (season) {
                case "Spring":
                case "Autumn":
                    pricePerKilometer = 0.95;
                    break;
                case "Summer":
                    pricePerKilometer = 1.10;
                    break;
                case "Winter":
                    pricePerKilometer = 1.25;
                    break;
                default:
                    break;
            }
        } else if (kilometersPerMonth > 10000 && kilometersPerMonth <= 20000) {
            pricePerKilometer = 1.45;
        }

        double salary = 4 * (kilometersPerMonth * pricePerKilometer);
        salary -= salary * 0.1;
        System.out.printf("%.2f", salary);
    }
}
