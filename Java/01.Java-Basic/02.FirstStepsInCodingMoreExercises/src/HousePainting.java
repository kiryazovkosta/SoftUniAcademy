import java.util.Scanner;

public class HousePainting {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double x = Double.parseDouble(scanner.nextLine());
        double y = Double.parseDouble(scanner.nextLine());
        double h = Double.parseDouble(scanner.nextLine());

        double backWall = x * x;
        double frontWall = backWall - (1.2 * 2);
        double leftWall = (x * y) - (1.5 * 1.5);
        double rightWall = leftWall;
        double greenWalls = backWall + frontWall + leftWall + rightWall;
        double greenWallPaint = greenWalls / 3.4;
        System.out.printf("%.2f%n", greenWallPaint);

        double backRoof = (x * h) / 2;
        double frontRoof = backRoof;
        double leftRoof = x * y;
        double rightRoof = leftRoof;
        double redWalls = backRoof + frontRoof + leftRoof + rightRoof;
        double redWallsPaint = redWalls / 4.3;
        System.out.printf("%.2f%n", redWallsPaint);
    }
}
