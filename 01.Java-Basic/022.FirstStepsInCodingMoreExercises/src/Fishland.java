import java.util.Scanner;

public class Fishland {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double skumriaPriceKg = Double.parseDouble(scanner.nextLine());
        double cacaPriceKg = Double.parseDouble(scanner.nextLine());
        double palamudKg = Double.parseDouble(scanner.nextLine());
        double safridKg = Double.parseDouble(scanner.nextLine());
        int midiKg = Integer.parseInt(scanner.nextLine());

        double palamudPriceKg = skumriaPriceKg + (skumriaPriceKg * 0.6);
        double safridPriceKg = cacaPriceKg + ( cacaPriceKg * 0.8);

        double palamudTotalPrice = palamudKg * palamudPriceKg;
        double safridTotalPrice = safridKg * safridPriceKg;
        double midiTotalPrice = midiKg * 7.5;
        double totalPrice = palamudTotalPrice + safridTotalPrice + midiTotalPrice;
        System.out.printf("%.2f", totalPrice);
    }
}
