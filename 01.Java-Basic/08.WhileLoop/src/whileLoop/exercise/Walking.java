package whileLoop.exercise;

import java.util.Scanner;

public class Walking {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int totalSteps = 0;
        String input = scanner.nextLine();
        while (!input.equals("Going home")) {
            int steps = Integer.parseInt(input);
            totalSteps += steps;
            if (totalSteps >= 10000) {
                break;
            }

            input = scanner.nextLine();
        }

        if (input.equals("Going home")) {
            int extraSteps = Integer.parseInt(scanner.nextLine());
            totalSteps += extraSteps;
        }

        if (totalSteps >= 10000) {
            System.out.printf("Goal reached! Good job!\n%d steps over the goal!", totalSteps- 10000);
        } else {
            System.out.printf("%d more steps to reach goal.", 10000 - totalSteps);
        }
    }
}
