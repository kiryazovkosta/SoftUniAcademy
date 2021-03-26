import java.util.Scanner;

public class HotelRoom {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String month = scanner.nextLine();
        int nights = Integer.parseInt(scanner.nextLine());

        double apartmentPrice = 0.0;
        double studioPrice = 0.0;

        switch (month) {
            case "May":
            case "October":
                apartmentPrice = 65;
                studioPrice = 50;
                if (nights > 14) {
                    studioPrice -= studioPrice * 0.3;
                } else if (nights > 7) {
                    studioPrice -= studioPrice * 0.05;
                }
                break;

            case "June":
            case "September":
                apartmentPrice = 68.7;
                studioPrice = 75.2;
                if (nights > 14) {
                    studioPrice -= studioPrice * 0.2;
                }
                break;

            case "July":
            case "August":
                apartmentPrice = 77;
                studioPrice = 76;
                break;

            default:
                break;
        }

        if (nights > 14) {
            apartmentPrice -= apartmentPrice * 0.1;
        }

        System.out.printf("Apartment: %.2f lv.%n", nights * apartmentPrice);
        System.out.printf("Studio: %.2f lv.%n", nights * studioPrice);
    }
}
