import java.util.Scanner;

public class OperationsBetweenNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int first = Integer.parseInt(scanner.nextLine());
        int second = Integer.parseInt(scanner.nextLine());
        String operation = scanner.nextLine();

        double result = 0;
        String type = "";
        switch (operation) {
            case "+":
            case "-":
            case "*":
                if (operation.equals("+")) {
                    result = first + second;
                } else if (operation.equals("-")) {
                    result = first - second;
                } else {
                    result = first * second;
                }

                type = result % 2 == 0 ? "even" : "odd";
                System.out.printf("%d %s %d = %.0f - %s", first, operation, second, result, type);
                break;

            case "/":
            case "%":
                if (second != 0) {
                    if (operation.equals("/")) {
                        result = first / (second * 1.00);
                        System.out.printf("%d %s %d = %.2f", first, operation, second, result);
                    } else if (operation.equals("%")) {
                        result  = first % second;
                        System.out.printf("%d %s %d = %.0f", first, operation, second, result);
                    }

                } else {
                    System.out.printf("Cannot divide %d by zero", first);
                }
                break;

            default:
                break;
        }
    }
}
