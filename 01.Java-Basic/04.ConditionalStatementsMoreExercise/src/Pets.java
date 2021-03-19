import java.util.Scanner;

public class Pets {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int days = Integer.parseInt(scanner.nextLine());
        int food = Integer.parseInt(scanner.nextLine());
        double dogPerDay = Double.parseDouble(scanner.nextLine());
        double catPerDay = Double.parseDouble(scanner.nextLine());
        double turtlePerDay = Double.parseDouble(scanner.nextLine());
        turtlePerDay = turtlePerDay / 1000;
        double dailyFood = dogPerDay + catPerDay + turtlePerDay;
        double allDaysFood = dailyFood * days;
        if (food >= allDaysFood) {
            System.out.printf("%.0f kilos of food left.", Math.floor(food - allDaysFood));
        } else {
            System.out.printf("%.0f more kilos of food are needed.", Math.ceil(allDaysFood - food));
        }
    }
}
