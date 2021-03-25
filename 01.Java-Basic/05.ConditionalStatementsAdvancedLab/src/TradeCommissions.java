import java.util.Scanner;

public class TradeCommissions {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String city = scanner.nextLine();
        double sales = scanner.nextDouble();

        double percentage = 0;
        switch (city) {
            case "Sofia":
                if (sales >= 0 && sales <= 500) {
                    percentage = 0.05;
                } else if (sales > 500 && sales <= 1000) {
                    percentage = 0.07;
                } else if (sales > 1000 && sales <= 10000) {
                    percentage = 0.08;
                } else if (sales > 10000) {
                    percentage = 0.12;
                }
                break;

            case "Varna":
                if (sales >= 0 && sales <= 500) {
                    percentage = 0.045;
                } else if (sales > 500 && sales <= 1000) {
                    percentage = 0.075;
                } else if (sales > 1000 && sales <= 10000) {
                    percentage = 0.1;
                } else if (sales > 10000) {
                    percentage = 0.13;
                }
                break;

            case "Plovdiv":
                if (sales >= 0 && sales <= 500) {
                    percentage = 0.055;
                } else if (sales > 500 && sales <= 1000) {
                    percentage = 0.08;
                } else if (sales > 1000 && sales <= 10000) {
                    percentage = 0.12;
                } else if (sales > 10000) {
                    percentage = 0.145;
                }
                break;

            default:
                break;
        }

        if (percentage == 0) {
            System.out.println("error");
        } else {
            System.out.printf("%.2f", sales * percentage);
        }
    }
}
