import java.util.Scanner;

public class PasswordGuess {
    public static void main(String[] args) {
        String password = "s3cr3t!P@ssw0rd";
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        if (password.equals(input)) {
            System.out.println("Welcome");
        } else {
            System.out.println("Wrong password!");
        }
    }
}
