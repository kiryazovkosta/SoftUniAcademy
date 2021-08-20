import java.util.Scanner;

public class VegetableMarket {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double vegetablesPrice = Double.parseDouble(scanner.nextLine());
        double fruitsPrice = Double.parseDouble(scanner.nextLine());
        int vegetables = Integer.parseInt(scanner.nextLine());
        int fruits = Integer.parseInt(scanner.nextLine());
        double totalPriceInBgn = (vegetables * vegetablesPrice) + (fruits * fruitsPrice);
        double totalPriceInEuro = totalPriceInBgn / 1.94;
        System.out.printf("%.2f", totalPriceInEuro);
    }
}
