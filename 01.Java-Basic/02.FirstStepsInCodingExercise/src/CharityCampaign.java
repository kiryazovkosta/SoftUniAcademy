import java.util.Scanner;

public class CharityCampaign {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int daysCount = Integer.parseInt(scanner.nextLine());
        int sladkari = Integer.parseInt(scanner.nextLine());
        int cakes = Integer.parseInt(scanner.nextLine());
        int gofreti = Integer.parseInt(scanner.nextLine());
        int pancakes = Integer.parseInt(scanner.nextLine());

        double cakesPrice = cakes * 45;
        double gofretiPrice = gofreti * 5.80;
        double pancakesPrice = pancakes * 3.2;
        double totalPerDay = (cakesPrice + gofretiPrice + pancakesPrice) * sladkari;
        double total = totalPerDay * daysCount;
        System.out.printf("%f", total - (total / 8));
    }
}