import java.util.Scanner;

public class Harvest {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int loze = Integer.parseInt(scanner.nextLine());
        double grozdePerSquareMeter = Double.parseDouble(scanner.nextLine());
        int wantedWine = Integer.parseInt(scanner.nextLine());
        int workers = Integer.parseInt(scanner.nextLine());

        double totalGrozde = loze * grozdePerSquareMeter;
        double totalGrozdeForWine = totalGrozde * 0.4;
        double wine = totalGrozdeForWine / 2.5;
        if (wine >= wantedWine) {
            double totalWine = Math.floor(wine);
            System.out.printf("Good harvest this year! Total wine: %.0f liters.%n", totalWine);
            double wineLeft = Math.ceil(wine - wantedWine);
            double wineForWorker = Math.ceil(wineLeft / workers);
            System.out.printf("%.0f liters left -> %.0f liters per person.%n", wineLeft, wineForWorker);
        } else {
            System.out.printf("It will be a tough winter! More %.0f liters wine needed.", Math.floor(wantedWine-wine));
        }
    }
}
