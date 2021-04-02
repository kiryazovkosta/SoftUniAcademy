package whileLoop.lab;

import java.util.Scanner;

public class SumNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int number = Integer.parseInt(scanner.nextLine());
        int sum = 0;
        while (number > sum) {
            int a = Integer.parseInt(scanner.nextLine());
            sum += a;
        }

        System.out.println(sum);
    }
}
