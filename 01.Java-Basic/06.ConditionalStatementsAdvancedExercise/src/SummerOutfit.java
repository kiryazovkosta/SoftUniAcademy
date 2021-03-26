import java.util.Scanner;

public class SummerOutfit {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int degrees = Integer.parseInt(scanner.nextLine());
        String time = scanner.nextLine();
        String outfit = "";
        if (degrees >= 10 && degrees <= 18) {
            if (time.equals("Morning")) {
                outfit = "Sweatshirt and Sneakers";
            } else if (time.equals("Afternoon") || time.equals("Evening")) {
                outfit = "Shirt and Moccasins";
            }
        } else if (degrees > 18 && degrees <= 24) {
            if (time.equals("Morning") || time.equals("Evening")) {
                outfit = "Shirt and Moccasins";
            } else if (time.equals("Afternoon")) {
                outfit = "T-Shirt and Sandals";
            }
        } else if (degrees >= 25) {
            if (time.equals("Morning")) {
                outfit = "T-Shirt and Sandals";
            } else if (time.equals("Afternoon")) {
                outfit = "Swim Suit and Barefoot";
            } else if (time.equals("Evening")) {
                outfit = "Shirt and Moccasins";
            }
        }

        System.out.printf("It's %d degrees, get your %s.", degrees, outfit);
    }
}
