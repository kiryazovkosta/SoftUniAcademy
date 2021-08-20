import java.util.Scanner;

public class Volleyball {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String year = scanner.nextLine();
        int holidays = Integer.parseInt(scanner.nextLine());
        int homedays = Integer.parseInt(scanner.nextLine());

        double inSofia = (48 - homedays) * 3/4.0;
        double inHome = homedays;
        inSofia += (holidays * 2/3.0);
        double totalGames = inSofia + inHome;
        if (year.equals("leap")) {
            totalGames += (totalGames * 0.15);
        }

        System.out.printf("%.0f", Math.floor(totalGames));
    }
}
