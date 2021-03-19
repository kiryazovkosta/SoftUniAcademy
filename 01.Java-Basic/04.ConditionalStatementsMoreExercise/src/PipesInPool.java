import java.util.Scanner;

public class PipesInPool {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int v = Integer.parseInt(scanner.nextLine());
        int p1 = Integer.parseInt(scanner.nextLine());
        int p2 = Integer.parseInt(scanner.nextLine());
        double h = Double.parseDouble(scanner.nextLine());

        double v1 = p1 * h;
        double v2 = p2 * h;
        double pV = v1 + v2;
        if (v >= pV) {
            double vP = (pV / v) * 100;
            double vP1 = (v1 / pV) * 100;
            double vP2 = (v2 / pV) * 100;
            System.out.printf("The pool is %.2f%% full. Pipe 1: %.2f%%. Pipe 2: %.2f%%.", vP, vP1, vP2);
        } else {
            System.out.printf("For %f hours the pool overflows with %f liters.", h, pV-v);
        }
    }
}
