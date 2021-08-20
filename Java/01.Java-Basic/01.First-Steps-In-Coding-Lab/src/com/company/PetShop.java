package com.company;

import java.util.Scanner;

public class PetShop {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int dogsCount = Integer.parseInt(scanner.nextLine());
        int animalsCount = Integer.parseInt(scanner.nextLine());

        double dogsFoodPrice = dogsCount * 2.5;
        double animalsFoodPrice = animalsCount * 4;
        System.out.printf("%f lv.", dogsFoodPrice + animalsFoodPrice);
    }
}
