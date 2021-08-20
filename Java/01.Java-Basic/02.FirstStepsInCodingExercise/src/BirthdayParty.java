import java.util.Scanner;

public class BirthdayParty {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int hallPrice = Integer.parseInt(scanner.nextLine());
        double cakePrice = hallPrice * 0.2;
        double drinksPrice = cakePrice - (cakePrice * 0.45);
        double animatorPrice = hallPrice / 3;
        double totalPrice = hallPrice + cakePrice + drinksPrice + animatorPrice;
        System.out.printf("%f", totalPrice);
    }
}
