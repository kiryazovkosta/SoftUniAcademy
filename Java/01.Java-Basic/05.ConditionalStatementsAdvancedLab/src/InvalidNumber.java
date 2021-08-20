import java.util.Scanner;

public class InvalidNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int number = scanner.nextInt();
        boolean isValid = (number >= 100 && number <= 200) || number == 0;
        if (!isValid) {
            System.out.println("invalid");
        }
    }
}
