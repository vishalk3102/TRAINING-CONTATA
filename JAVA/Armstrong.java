import java.util.Scanner;

public class Armstrong {

    public static int calculateArmstrong(int n) {
        int temp = n;
        int rem = 0;
        int sum = 0;
        int count = 0;
        while (temp > 0) {
            temp = temp / 10;
            count++;
        }
        temp = n;
        while (temp > 0) {
            rem = temp % 10;
            sum += Math.pow(rem, count);
            temp /= 10;
        }
        if (sum == n)
            return 1;
        return 0;
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter the Number");
        int n = sc.nextInt();
        int res = calculateArmstrong(n);
        String str = (res == 1) ? "Armstrong Number" : "Not a Armstrong Number ";
        System.out.println(str);
    }
}