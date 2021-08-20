import java.util.Scanner;

public class WorldSwimmingRecord {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double record = Double.parseDouble(scanner.nextLine());
        double distance = Double.parseDouble(scanner.nextLine());
        double secondsPerMeter = Double.parseDouble(scanner.nextLine());

        double c1 = distance * secondsPerMeter;
        double c2 = Math.floor(distance / 15) * 12.5;
        double current = c1 + c2;
        if (current < record) {
            System.out.printf("Yes, he succeeded! The new world record is %.2f seconds.", current);
        } else {
            System.out.printf("No, he failed! He was %.2f seconds slower.", current-record);
        }
    }
}
