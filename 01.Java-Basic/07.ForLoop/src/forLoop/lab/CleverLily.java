package forLoop.lab;

import java.util.Scanner;

public class CleverLily {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int age = Integer.parseInt(scanner.nextLine());
        double washingPrice = Double.parseDouble(scanner.nextLine());
        double toyPrice = Double.parseDouble(scanner.nextLine());

        double giftsSum = 0.0;
        for (int i = 1; i <= age; i++) {
            if (i % 2 == 0) {
                giftsSum += (i * 5) - 1;
            } else {
                giftsSum += toyPrice;
            }
        }

        if (giftsSum >= washingPrice) {
            System.out.printf("Yes! %.2f", giftsSum-washingPrice);
        } else {
            System.out.printf("No! %.2f", washingPrice-giftsSum);
        }
    }
}
