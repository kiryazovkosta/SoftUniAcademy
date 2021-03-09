package com.company;

import java.util.Scanner;

public class YardGreening {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Double area = Double.parseDouble(scanner.nextLine());

        Double totalPrice = area * 7.61;
        Double discount = totalPrice * 0.18;
        Double realPrice = totalPrice - discount;

        System.out.printf("The final price is: %f lv.", realPrice);
        System.out.printf("The discount is: %f lv.", discount);
    }
}
