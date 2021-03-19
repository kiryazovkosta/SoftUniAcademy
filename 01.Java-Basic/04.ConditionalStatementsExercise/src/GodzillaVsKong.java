import java.util.Scanner;

public class GodzillaVsKong {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double budget = Double.parseDouble(scanner.nextLine());
        int extras = Integer.parseInt(scanner.nextLine());
        double dressPrice = Double.parseDouble(scanner.nextLine());

        double decorPrice = budget * 0.1;
        double extrasDressesPrice = extras * dressPrice;
        if (extras > 150) {
            extrasDressesPrice = extrasDressesPrice - (extrasDressesPrice * 0.1);
        }
        double fimlPrice = decorPrice + extrasDressesPrice;
        if (fimlPrice > budget) {
            System.out.println("Not enough money!");
            System.out.printf("Wingard needs %.2f leva more.", fimlPrice-budget);
        } else {
            System.out.println("Action!");
            System.out.printf("Wingard starts filming with %.2f leva left.", budget-fimlPrice);
        }

    }
}
