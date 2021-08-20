import java.util.Scanner;

public class Journey {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double budget = Double.parseDouble(scanner.nextLine());
        String season = scanner.nextLine();

        String destination = "";
        double price = 0.0;
        String type = "Hotel";
        if (budget <= 100) {
            destination = "Bulgaria";
            if (season.equals("summer")) {
                 price = budget * 0.3;
                 type = "Camp";
            } else if (season.equals("winter")) {
                price = budget * 0.7;
            }
        } else if (budget <= 1000) {
            destination = "Balkans";
            if (season.equals("summer")) {
                price = budget * 0.4;
                type = "Camp";
            } else if (season.equals("winter")) {
                price = budget * 0.8;
            }
        } else if (budget > 1000) {
            destination = "Europe";
            price = budget * 0.9;
        }

        System.out.printf("Somewhere in %s%n", destination);
        System.out.printf("%s - %.2f %n", type, price);
    }
}
