import java.util.Scanner;

public class NewHouse {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String flowersType = scanner.nextLine();
        int flowersNumber = Integer.parseInt(scanner.nextLine());
        int budget = Integer.parseInt(scanner.nextLine());
        double flowerPrice = 0;
        switch (flowersType) {
            case "Roses":
                flowerPrice = 5;
                break;

            case  "Dahlias":
                flowerPrice = 3.8;
                break;

            case "Tulips":
                flowerPrice = 2.8;
                break;

            case  "Narcissus":
                flowerPrice = 3;
                break;

            case  "Gladiolus":
                flowerPrice = 2.5;
                break;

            default:
                break;
        }

        double totalPrice = flowersNumber * flowerPrice;
        if (flowersType.equals("Roses") && flowersNumber > 80) {
            totalPrice -= (totalPrice * 0.1);
        } else if (flowersType.equals("Dahlias") && flowersNumber > 90) {
            totalPrice -= (totalPrice * 0.15);
        } else if (flowersType.equals("Tulips") && flowersNumber > 80) {
            totalPrice -= (totalPrice * 0.15);
        } else if (flowersType.equals("Narcissus") && flowersNumber < 120) {
            totalPrice += (totalPrice * 0.15);
        } else if (flowersType.equals("Gladiolus") && flowersNumber < 80) {
            totalPrice += (totalPrice * 0.2);
        }

        if (budget >= totalPrice) {
            System.out.printf("Hey, you have a great garden with %d %s and %.2f leva left.", flowersNumber, flowersType, budget-totalPrice);
        } else {
            System.out.printf("Not enough money, you need %.2f leva more.", totalPrice-budget);
        }
    }
}
