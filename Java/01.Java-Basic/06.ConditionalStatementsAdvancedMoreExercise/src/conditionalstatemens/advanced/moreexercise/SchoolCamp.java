package conditionalstatemens.advanced.moreexercise;

import java.util.Scanner;

public class SchoolCamp {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String season = scanner.nextLine();
        String group = scanner.nextLine();
        int students = Integer.parseInt(scanner.nextLine());
        int nights = Integer.parseInt(scanner.nextLine());

        double pricePerPerson = 0.0;
        String sport = "";
        switch (group) {
            case "boys":
                switch (season) {
                    case "Winter":
                        pricePerPerson = 9.60;
                        sport = "Judo";
                        break;

                    case "Spring":
                        pricePerPerson = 7.20;
                        sport = "Tennis";
                        break;

                    case "Summer":
                        pricePerPerson = 15.00;
                        sport = "Football";
                        break;

                    default:
                        break;
                }
                break;

            case "girls":
                switch (season) {
                    case "Winter":
                        pricePerPerson = 9.60;
                        sport = "Gymnastics";
                        break;

                    case "Spring":
                        pricePerPerson = 7.20;
                        sport = "Athletics";
                        break;

                    case "Summer":
                        pricePerPerson = 15.00;
                        sport = "Volleyball";
                        break;

                    default:
                        break;
                }
                break;

            case "mixed":
                switch (season) {
                    case "Winter":
                        pricePerPerson = 10.00;
                        sport = "Ski";
                        break;

                    case "Spring":
                        pricePerPerson = 9.50;
                        sport = "Cycling";
                        break;

                    case "Summer":
                        pricePerPerson = 20.00;
                        sport = "Swimming";
                        break;

                    default:
                        break;
                }
                break;

            default:
                break;
        }

        double price = students * pricePerPerson * nights;
        if (students >= 50) {
            price -= price * 0.5;
        } else if (students >= 20 && students < 50) {
            price -= price * 0.15;
        } else if (students >= 10 && students < 20) {
            price -= price * 0.05;
        }

        System.out.printf("%s %.2f lv.", sport, price);
    }
}
