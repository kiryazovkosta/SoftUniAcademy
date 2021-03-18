import java.util.Scanner;

public class ToyShop {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double tripPrice = Double.parseDouble(scanner.nextLine());
        int puzzels = Integer.parseInt(scanner.nextLine());
        int dolls = Integer.parseInt(scanner.nextLine());
        int bears = Integer.parseInt(scanner.nextLine());
        int minions = Integer.parseInt(scanner.nextLine());
        int trucks = Integer.parseInt(scanner.nextLine());

        int toysNumber = puzzels + dolls + bears + minions + trucks;
        double toysPrice = (puzzels * 2.6)
                + (dolls * 3)
                + (bears * 4.1)
                + (minions * 8.2)
                + (trucks * 2);

        if (toysNumber >= 50) {
            toysPrice = toysPrice - ( toysPrice * 0.25);
        }

        toysPrice = toysPrice - (toysPrice * 0.1);
        if (toysPrice >= tripPrice) {
            System.out.printf("Yes! %.2f lv left.", toysPrice - tripPrice);
        } else {
            System.out.printf("Not enough money! %.2f lv needed.", tripPrice- toysPrice);
        }
    }
}
