import java.util.Scanner;

public class SkiTrip {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int days = Integer.parseInt(scanner.nextLine());
        String room = scanner.nextLine();
        String rating = scanner.nextLine();

        int nights = days - 1;
        double nightPrice = 0;
        double discountPercentages = 0;
        switch (room) {
            case "room for one person":
                nightPrice = 18;
                break;
            case "apartment":
                nightPrice = 25;
                if (nights < 10) {
                    discountPercentages = 0.3;
                } else if (nights >= 10 && nights <= 15) {
                    discountPercentages = 0.35;
                } else {
                    discountPercentages = 0.5;
                }
                break;

            case "president apartment":
                nightPrice = 35;
                if (nights < 10) {
                    discountPercentages = 0.1;
                } else if (nights >= 10 && nights <= 15) {
                    discountPercentages = 0.15;
                } else {
                    discountPercentages = 0.2;
                }
                break;

            default:
                break;
        }

        double price = nights * nightPrice;
        if (discountPercentages > 0) {
            price = price - (price * discountPercentages);
        }

        if (rating.equals("positive")) {
            price = price + (price * 0.25);
        } else if (rating.equals("negative")) {
            price = price - (price * 0.1);
        }

        System.out.printf("%.2f", price);
    }
}
