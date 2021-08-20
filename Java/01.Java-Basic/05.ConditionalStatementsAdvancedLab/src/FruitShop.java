import java.util.Scanner;

public class FruitShop {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String fruit = scanner.nextLine();
        String day = scanner.nextLine();
        double quantity = scanner.nextDouble();

        double fruitPrice = 0.0;
        switch (day) {
            case "Monday":
            case "Tuesday":
            case "Wednesday":
            case "Thursday":
            case "Friday":
                if (fruit.equals("banana")) {
                    fruitPrice = 2.5;
                } else if (fruit.equals("apple")) {
                    fruitPrice = 1.2;
                } else if (fruit.equals("orange")) {
                    fruitPrice = 0.85;
                } else if (fruit.equals("grapefruit")) {
                    fruitPrice = 1.45;
                } else if (fruit.equals("kiwi")) {
                    fruitPrice = 2.7;
                } else if (fruit.equals("pineapple")) {
                    fruitPrice = 5.5;
                } else if (fruit.equals("grapes")) {
                    fruitPrice = 3.85;
                }
                break;
            case "Saturday":
            case "Sunday":
                if (fruit.equals("banana")) {
                    fruitPrice = 2.7;
                } else if (fruit.equals("apple")) {
                    fruitPrice = 1.25;
                } else if (fruit.equals("orange")) {
                    fruitPrice = 0.9;
                } else if (fruit.equals("grapefruit")) {
                    fruitPrice = 1.6;
                } else if (fruit.equals("kiwi")) {
                    fruitPrice = 3.0;
                } else if (fruit.equals("pineapple")) {
                    fruitPrice = 5.6;
                } else if (fruit.equals("grapes")) {
                    fruitPrice = 4.2;
                }
                break;
            default:
                break;
        }

        if (fruitPrice == 0) {
            System.out.println("error");
        } else {
            System.out.printf("%.2f", quantity * fruitPrice);
        }
    }
}
