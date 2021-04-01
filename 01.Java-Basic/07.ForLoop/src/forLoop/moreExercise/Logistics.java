package forLoop.moreExercise;

import java.util.Scanner;

public class Logistics {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int p1 = 0;
        int p2 = 0;
        int p3 = 0;
        int loads = Integer.parseInt(scanner.nextLine());
        for (int i = 0; i < loads; i++) {
            int load = Integer.parseInt(scanner.nextLine());
            if (load <= 3) {
                p1 += load;
            } else if (load >= 4 && load <= 11) {
                p2 += load;
            } else {
                p3 += load;
            }
        }

        double totalLoads = p1 + p2 + p3;
        System.out.printf("%.2f\n", (p1*200+p2*175+p3*120)/totalLoads);
        System.out.printf("%.2f%%\n", (p1/totalLoads)*100.0);
        System.out.printf("%.2f%%\n", (p2/totalLoads)*100.0);
        System.out.printf("%.2f%%\n", (p3/totalLoads)*100.0);
    }


}
