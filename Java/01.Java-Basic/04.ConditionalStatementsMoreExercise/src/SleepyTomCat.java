import java.util.Scanner;

public class SleepyTomCat {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int holidays = Integer.parseInt(scanner.nextLine());
        int holidaysMinutes = holidays * 127;
        int workdays = 365 - holidays;
        int workingDaysMinutes = workdays * 63;
        int totalMinutes = holidaysMinutes + workingDaysMinutes;
        int diffMinutes = Math.abs(totalMinutes - 30000);
        int hours = diffMinutes / 60;
        int minutes = diffMinutes % 60;
        if (totalMinutes > 30000) {
            System.out.println("Tom will run away");
            System.out.printf("%d hours and %d minutes more for play", hours, minutes);
        } else {
            System.out.println("Tom sleeps well");
            System.out.printf("%d hours and %d minutes less for play", hours, minutes);
        }
    }
}
