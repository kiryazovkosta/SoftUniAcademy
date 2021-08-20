import java.util.Scanner;

public class VacationBooksList {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int totalPages = Integer.parseInt(scanner.nextLine());
        int pagesPerHour = Integer.parseInt(scanner.nextLine());
        int daysCount = Integer.parseInt(scanner.nextLine());

        int totalReadingTime = totalPages / pagesPerHour;
        int hoursPerDay = totalReadingTime / daysCount;
        System.out.printf("%d", hoursPerDay);
    }
}
