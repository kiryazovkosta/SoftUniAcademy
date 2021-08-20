package whileLoop.exercise;

import java.util.Scanner;

public class ExamPreparation {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int tasksCounter = 0;
        double tasksGradesSum = 0;
        Boolean isFailed = false;
        int poorGradesCounter = 0;
        int maxPoorGrades = Integer.parseInt(scanner.nextLine());
        String lastTaskName = "";
        String input = scanner.nextLine();
        while (!input.equals("Enough")) {
            String taskName = input;
            int taskGrade = Integer.parseInt(scanner.nextLine());
            if (taskGrade <= 4 ){
                poorGradesCounter++;
            }

            if (poorGradesCounter >= maxPoorGrades) {
                isFailed = true;
                break;
            }

            lastTaskName = taskName;
            tasksCounter++;
            tasksGradesSum += taskGrade;
            input = scanner.nextLine();
        }

        if (isFailed) {
            System.out.printf("You need a break, %d poor grades.", poorGradesCounter);
        } else {
            System.out.printf("Average score: %.2f\n", tasksGradesSum / tasksCounter);
            System.out.printf("Number of problems: %d\n", tasksCounter);
            System.out.printf("Last problem: %s\n", lastTaskName);
        }
    }
}
