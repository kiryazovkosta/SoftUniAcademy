import java.util.Scanner;

public class Scholarship {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Double dohod = Double.parseDouble(scanner.nextLine());
        Double sredenUspeh = Double.parseDouble(scanner.nextLine());
        Double minZaplata = Double.parseDouble(scanner.nextLine());

        Double socialna = 0.0;
        Double uspeh = 0.0;

        if (dohod < minZaplata && sredenUspeh > 4.5) {
            socialna = minZaplata * 0.35;
        }

        if (sredenUspeh >= 5.5) {
            uspeh = sredenUspeh * 25;
        }

        if (socialna == 0 && uspeh == 0) {
            System.out.print("You cannot get a scholarship!");
        } else if (socialna > uspeh) {
            System.out.printf("You get a Social scholarship %.0f BGN", Math.floor(socialna));
        } else {
            System.out.printf("You get a scholarship for excellent results %.0f BGN", Math.floor(uspeh));
        }
    }
}
