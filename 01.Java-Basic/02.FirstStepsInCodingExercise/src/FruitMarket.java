import java.util.Scanner;

public class FruitMarket {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double yagodiPrice = Double.parseDouble(scanner.nextLine());
        double banani = Double.parseDouble(scanner.nextLine());
        double portokali = Double.parseDouble(scanner.nextLine());
        double malini = Double.parseDouble(scanner.nextLine());
        double yagoddi = Double.parseDouble(scanner.nextLine());

        double maliniPrice = yagodiPrice / 2;
        double portokaliPrice = maliniPrice - (maliniPrice * 0.4);
        double bananiPrice = maliniPrice - (maliniPrice * 0.8);

        double yagodiTotalPrice = yagoddi * yagodiPrice;
        double maliniTotalPrice = malini * maliniPrice;
        double bananiTotalPrice = banani * bananiPrice;
        double portokaliTotalPrice = portokali * portokaliPrice;
        double totalPrice = yagodiTotalPrice + maliniTotalPrice + bananiTotalPrice + portokaliTotalPrice;
        System.out.printf("%.2f", totalPrice);
    }
}
