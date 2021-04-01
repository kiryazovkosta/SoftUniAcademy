package forLoop.moreExercise;

public class Clock {
    public static void main(String[] args) {
        int minHours = 0;
        int maxHours = 23;
        int minMinutes = 0;
        int maxMinutes = 59;
        for (int hour = minHours; hour <= maxHours; hour++) {
            for (int minute = minMinutes; minute <= maxMinutes ; minute++) {
                System.out.printf("%d : %d\n", hour, minute);
            }
        }
    }
}
