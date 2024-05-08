import java.util.Scanner;

public class OddEven {

    public static int checkOddEven(int n) {
        int flag = 0;
        if (n % 2 == 0) {
            flag = 1;
        } else {
            flag = 0;
        }

        return flag;
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter the Number :");
        int n = sc.nextInt();
        int flag = checkOddEven(n);
        if (flag == 1) {
            System.out.println("Even Number");
        } else {
            System.out.println("odd Number");
        }
    }

}
