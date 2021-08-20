import java.util.Scanner;

public class Firm {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int hours = Integer.parseInt(scanner.nextLine());
        int days = Integer.parseInt(scanner.nextLine());
        int workers = Integer.parseInt(scanner.nextLine());

        double workingHours = (days - days * 0.1) * 8;
        double overworkingHours = workers * (days * 2);
        double totalWorkingHours = Math.floor(workingHours + overworkingHours);
        if (totalWorkingHours >= hours) {
            System.out.printf("Yes!%.0f hours left.", totalWorkingHours-hours);
        } else {
            System.out.printf("Not enough time!%.0f hours needed.", hours-totalWorkingHours);
        }
    }
}
