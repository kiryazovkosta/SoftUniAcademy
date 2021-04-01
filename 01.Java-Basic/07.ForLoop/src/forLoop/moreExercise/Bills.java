package forLoop.moreExercise;

import java.util.Locale;
import java.util.Scanner;

public class Bills {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double eTotalPrice = 0;
        double wTotalPrice = 0;
        double iTotalPrice = 0;
        double oTotalPrice = 0;
        double totalPrice = 0;
        int months = Integer.parseInt(scanner.nextLine());
        for (int i = 0; i < months; i++) {
            double ePrice = Double.parseDouble(scanner.nextLine());
            eTotalPrice += ePrice;
            double wPrice = 20;
            wTotalPrice += wPrice;
            double iPrice = 15;
            iTotalPrice += iPrice;
            double oPrice =  (ePrice + wPrice + iPrice ) + (ePrice + wPrice + iPrice) * 0.2;
            oTotalPrice += oPrice;
            totalPrice += (ePrice + wPrice + iPrice + oPrice);
        }

        System.out.printf("Electricity: %.2f lv\n", eTotalPrice);
        System.out.printf("Water: %.2f lv\n", wTotalPrice);
        System.out.printf("Internet: %.2f lv\n", iTotalPrice);
        System.out.printf("Other: %.2f lv\n", oTotalPrice);
        System.out.printf("Average: %.2f lv\n", totalPrice/months);
    }
}
