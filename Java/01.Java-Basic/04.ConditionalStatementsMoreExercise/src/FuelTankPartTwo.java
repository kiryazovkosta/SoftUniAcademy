import java.util.Scanner;

public class FuelTankPartTwo {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String fuel = scanner.nextLine().toLowerCase();
        double quantity = Double.parseDouble(scanner.nextLine());
        String hasDiscount = scanner.nextLine().toLowerCase();

        double dieselPrice = 2.33;
        double gasolinePrice = 2.22;
        double gasPrice = 0.93;
        if (hasDiscount.equals("yes")) {
            dieselPrice -= 0.12;
            gasolinePrice -= 0.18;
            gasPrice -= 0.08;
        }

        double fuelPrice = 0.0;
        if (fuel.equals("diesel")) {
            fuelPrice = quantity * dieselPrice;
        } else if (fuel.equals("gasoline")) {
            fuelPrice = quantity * gasolinePrice;
        } else if (fuel.equals("gas")) {
            fuelPrice = quantity * gasPrice;
        }

        if (quantity > 25) {
            fuelPrice = fuelPrice - (fuelPrice * 0.1);
        } else if (quantity >= 20) {
            fuelPrice = fuelPrice - (fuelPrice * 0.08);
        }

        System.out.printf("%.2f lv.", fuelPrice);
    }
}
