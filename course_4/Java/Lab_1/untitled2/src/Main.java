import java.util.Scanner;

class Main {

    public static void main(String[] args) {
        task1();
//        task2();
//        task3();
//        task4();
//        task5();
//        task6();
    }

    private static void task1() {
        Scanner input = new Scanner(System.in);
        System.out.print("Введите что-то: ");
        String text = input.nextLine();
        input.close();
        System.out.println(text);
    }

    private static void task2() {
        for (int i = 1; i < 500; i++) {
            if (i % 5 == 0) {
                System.out.println("fizz");
            }
            if (i % 7 == 0) {
                System.out.println("buzz");
            }
            if (i % 5 == 0 && i % 7 == 0) {
                System.out.println("fizzbuzz");
            }
        }
    }

    private static void task3() {
        Scanner input = new Scanner(System.in);
        System.out.print("Введите строку: ");
        String text = input.nextLine();
        input.close();
        System.out.println(text);
        for (int i = text.length() - 1; i >= 0; i--) {
            System.out.print(text.charAt(i));
        }
    }

    private static void task4() {
        int prev1 = 0, prev2 = 1;
        int fibo = 1;
        while (fibo < 10000) {
            System.out.print(fibo + ", ");
            fibo = prev1 + prev2;
            prev1 = prev2;
            prev2 = fibo;
        }
        System.out.println();
    }

    public static void task5() {
        Scanner input = new Scanner(System.in);
        System.out.print("Введите число: ");
        int num = input.nextInt();
        input.close();

        int result = 1;
        for (int i = 1; i <= num; i++) {
            result = result * i;
        }
        System.out.println(result);
    }

    private static void task6() {
        Scanner input = new Scanner(System.in);
        System.out.print("Введите число: ");
        int num = input.nextInt();
        input.close();

        boolean[] primes = new boolean[num];
        for (int i = 2; i < num; i++) {
            primes[i] = true;
        }
        for (int i = 2; i < num; i++) {
            if (primes[i]) {
                for (int j = i; j * i < num; j++) {
                    primes[i * j] = false;
                }
            }
        }
        for (int i = 2; i < num; i++) {
            if (i > num - 100) {
                if (primes[i]) {
                    System.out.print(i + ", ");
                }
            }
        }
        System.out.println();
    }
}
