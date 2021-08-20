import java.util.Scanner;

public class AreaOfFigures {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String figure = scanner.nextLine();
        double p1 = Double.parseDouble(scanner.nextLine());

        double area = 0;
        if (figure.equals("square")) {
            area = p1 * p1;
        } else if (figure.equals("rectangle")) {
            double p2 = Double.parseDouble(scanner.nextLine());
            area = p1 * p2;
        } else if (figure.equals("circle")) {
            area = Math.PI * Math.pow(p1, 2);
        } else if (figure.equals("triangle")) {
            double p2 = Double.parseDouble(scanner.nextLine());
            area = (p1 * p2) / 2;
        }

        System.out.printf("%.3f", area);
    }
}
