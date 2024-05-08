
import java.util.Scanner;

public class Swap {

     public static void swapValueUsingVariable(int a, int b) {
        int temp;
        temp = a;
        a = b;
        b = temp;
        System.out.println("Value after  swapping is :");
        System.out.println("a :" + a);
        System.out.println("b :" + b);

    }

     public static void swapValueWithoutVariable(int a, int b) {
        
        a=a+b;
        b=a-b;
        a=a-b;
        System.out.println("Value after  swapping without using variable is :");
        System.out.println("a :" + a);
        System.out.println("b :" + b);
         
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter the value of a :");
        int a = sc.nextInt();
        System.out.print("Enter the value of b :");
        int b = sc.nextInt();
        System.out.println("Value before  swapping is");
        System.out.println("a :" + a);
        System.out.println("b :" + b);
        swapValueUsingVariable(a, b);
        swapValueWithoutVariable(a,b);
    }
}
