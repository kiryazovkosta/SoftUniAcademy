import java.util.Scanner;

public class TransportPrice {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int distance = Integer.parseInt(scanner.nextLine());
        String transport = scanner.nextLine();
        double price = 0.0;

        if (distance >= 100) {
            price = distance * 0.06;
        } else if (distance >= 20) {
            price = distance * 0.09;
        } else if (transport.equals("day")){
            price = (distance * 0.79) + 0.70;
        } else {
            price = (distance * 0.90) + 0.70;
        }

        System.out.printf("%.2f", price);
    }
}
