import java.util.Scanner;

public class SumSeconds {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int a = Integer.parseInt(scanner.nextLine());
        int b = Integer.parseInt(scanner.nextLine());
        int c = Integer.parseInt(scanner.nextLine());

        int totalSeconds = a + b + c;
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        System.out.printf("%d:%02d", minutes, seconds);
    }
}
