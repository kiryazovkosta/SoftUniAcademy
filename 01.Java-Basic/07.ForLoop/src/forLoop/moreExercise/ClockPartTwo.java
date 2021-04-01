package forLoop.moreExercise;

public class ClockPartTwo {
    public static void main(String[] args) {
        int minHours = 0;
        int maxHours = 23;
        int minMinutes = 0;
        int maxMinutes = 59;
        int minSeconds = 0;
        int maxSeconds = 59;
        for (int hour = minHours; hour <= maxHours; hour++) {
            for (int minute = minMinutes; minute <= maxMinutes ; minute++) {
                for (int second = minSeconds; second <= maxSeconds ; second++) {
                    System.out.printf("%d : %d : %d\n", hour, minute, second);
                }
            }
        }
    }
}
