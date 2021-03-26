package conditionalstatemens.advanced.moreexercise;

import java.util.Scanner;

public class MatchTickets {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double budget = Double.parseDouble(scanner.nextLine());
        String category = scanner.nextLine();
        int fans = Integer.parseInt(scanner.nextLine());

        double tripPrice = budget;
        if (fans >= 1 && fans <= 4) {
            tripPrice = tripPrice * 0.75;
        } else if (fans >= 5 && fans <= 9) {
            tripPrice = tripPrice * 0.6;
        } else if (fans >= 10 && fans <= 24) {
            tripPrice = tripPrice * 0.5;
        } else if (fans >= 25 && fans <= 49) {
            tripPrice = tripPrice * 0.4;
        } else if (fans >= 50) {
            tripPrice = tripPrice * 0.25;
        }

        double ticketsPrice = 0;
        if (category.equals("VIP")) {
            ticketsPrice = fans * 499.99;
        } else if (category.equals("Normal")) {
            ticketsPrice = fans * 249.99;
        }

        double free = budget - tripPrice;
        if (free >= ticketsPrice) {
            System.out.printf("Yes! You have %.2f leva left.", free-ticketsPrice);
        }else {
            System.out.printf("Not enough money! You need %.2f leva.", ticketsPrice-free);
        }
    }
}
