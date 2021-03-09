import java.util.Scanner;

public class USD2BGN {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Double usd = Double.parseDouble(scanner.nextLine());
        Double bgn = usd * 1.79549;
        System.out.println(bgn);
    }
}
