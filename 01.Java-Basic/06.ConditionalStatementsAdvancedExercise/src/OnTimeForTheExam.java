import java.util.Scanner;

public class OnTimeForTheExam {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int examHours = Integer.parseInt(scanner.nextLine());
        int examMinutes = Integer.parseInt(scanner.nextLine());
        int myHours = Integer.parseInt(scanner.nextLine());
        int myMinutes = Integer.parseInt(scanner.nextLine());

        int totalExamMinutes = (examHours * 60) + examMinutes;
        int totalMyMinutes = (myHours * 60) + myMinutes;
        if (totalMyMinutes > totalExamMinutes) {
            System.out.println("Late");
            int diffInMinutes = totalMyMinutes - totalExamMinutes;
            if (diffInMinutes >= 60) {
                int diffHours = diffInMinutes / 60;
                int diffMinutes = diffInMinutes % 60;
                System.out.printf("%d:%02d hours after the start", diffHours, diffMinutes);
            }else {
                System.out.printf("%d minutes after the start", diffInMinutes);
            }
        } else {
            int diffInMinutes = totalExamMinutes - totalMyMinutes;
            if (diffInMinutes == 0) {
                System.out.println("On time");
            } else if (diffInMinutes <= 30) {
                System.out.println("On time");
                System.out.printf("%d minutes before the start", diffInMinutes);
            } else {
                System.out.println("Early");
                if (diffInMinutes >= 60) {
                    int diffHours = diffInMinutes / 60;
                    int diffMinutes = diffInMinutes % 60;
                    System.out.printf("%d:%02d hours before the start", diffHours, diffMinutes);
                } else {
                    System.out.printf("%d minutes before the start", diffInMinutes);
                }
            }
        }

    }
}
