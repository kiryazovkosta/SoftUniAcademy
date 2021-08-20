import java.util.Scanner;

public class FuelTank {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String fuel = scanner.nextLine().toLowerCase();
        double quantity = Double.parseDouble(scanner.nextLine());

        if (fuel.equals("diesel")
            || fuel.equals("gasoline")
            || fuel.equals("gas")) {
            if (quantity >= 25) {
                System.out.printf("You have enough %s.", fuel);
            } else {
                System.out.printf("Fill your tank with %s!", fuel);
            }
        } else {
            System.out.println("Invalid fuel!");
        }
    }
}