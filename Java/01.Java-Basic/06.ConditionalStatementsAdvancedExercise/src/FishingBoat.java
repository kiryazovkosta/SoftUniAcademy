import java.util.Scanner;

public class FishingBoat {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int budget = Integer.parseInt(scanner.nextLine());
        String season = scanner.nextLine();
        int fishermanNumber = Integer.parseInt(scanner.nextLine());

        double boatPrice = 0.0;
        switch (season) {
            case "Spring":
                boatPrice = 3000;
                break;

            case  "Summer":
            case  "Autumn":
                boatPrice = 4200;
                break;

            case  "Winter":
                boatPrice = 2600;
                break;

            default:
                break;
        }

        if (fishermanNumber <= 6) {
            boatPrice -= (boatPrice * 0.1);
        } else if (fishermanNumber >= 7 && fishermanNumber <= 11) {
            boatPrice -= (boatPrice * 0.15);
        } else if (fishermanNumber >= 12) {
            boatPrice -= (boatPrice * 0.25);
        }

        if (fishermanNumber % 2 == 0 && !season.equals("Autumn")) {
            boatPrice -= (boatPrice * 0.05);
        }

        if (budget >= boatPrice) {
            System.out.printf("Yes! You have %.2f leva left.", budget-boatPrice);
        } else {
            System.out.printf("Not enough money! You need %.2f leva.", boatPrice-budget);
        }
    }
}
