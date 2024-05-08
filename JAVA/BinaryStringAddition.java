import java.util.Scanner;

public class BinaryStringAddition {

    public static String BinaryAddition(String s1, String s2) {
        int a = Integer.parseInt(s1, 2);
        int b = Integer.parseInt(s2, 2);
        int sum = a + b;
        String result = Integer.toBinaryString(sum);
        return result;
    }

    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);
        System.out.println("Enter the String 1 :");
        String s1 = sc.next();
        System.out.println("Enter the String 2 :");
        String s2 = sc.next();

        System.out.println(BinaryAddition(s1, s2));
    }
}
