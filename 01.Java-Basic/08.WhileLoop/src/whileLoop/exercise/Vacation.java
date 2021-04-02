package whileLoop.exercise;

import java.util.Scanner;

public class Vacation {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int days = 0;
        Boolean isSpend = false;
        int daysSpend = 0;
        double tripPrice = Double.parseDouble(scanner.nextLine());
        double money = Double.parseDouble(scanner.nextLine());
        while (money < tripPrice) {
            String operation = scanner.nextLine();
            double price = Double.parseDouble(scanner.nextLine());
            days++;
            if (operation.equals("spend")) {
                daysSpend++;
                money -= price;
                if (money < 0) {
                    money = 0;
                }

                if (daysSpend == 5) {
                    isSpend = true;
                    break;
                }

            } else {
                daysSpend = 0;
                money += price;
            }
        }

        if (isSpend) {
            System.out.printf("You can't save the money.\n%d", days);
        } else {
            System.out.printf("You saved the money for %d days.", days);
        }
    }
}
