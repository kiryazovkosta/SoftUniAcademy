import java.util.Scanner;

public class FlowerShop {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int magnoli = Integer.parseInt(scanner.nextLine());
        int zumbuli = Integer.parseInt(scanner.nextLine());
        int rozi = Integer.parseInt(scanner.nextLine());
        int kaktusi = Integer.parseInt(scanner.nextLine());
        double podarakCena = Double.parseDouble(scanner.nextLine());

        double cvetqPrice = (magnoli * 3.25)
                + (zumbuli * 4.0)
                + (rozi * 3.5)
                + ( kaktusi * 8.0);
        double pechalba = cvetqPrice - (cvetqPrice * 0.05);
        if (pechalba >= podarakCena) {
            System.out.printf("She is left with %.0f leva.", Math.floor(pechalba-podarakCena));
        } else {
            System.out.printf("She will have to borrow %.0f leva.", Math.ceil(podarakCena-pechalba));
        }

    }
}
