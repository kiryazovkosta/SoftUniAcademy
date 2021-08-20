import java.util.Scanner;

public class DepositCalculator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double sum = Double.parseDouble(scanner.nextLine());
        int period = Integer.parseInt(scanner.nextLine());
        double lihva = Double.parseDouble(scanner.nextLine());

        double yearLihva = sum * (lihva / 100);
        double monthLihva = yearLihva / 12;
        double totalSum = sum +(period * monthLihva);
        System.out.println(totalSum);
    }
}
