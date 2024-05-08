import java.util.Scanner;

public class Input {
    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);
        int a = input.nextInt();
        System.out.println("input :" + a);

        String s = input.nextLine();
        System.out.print("You entered string " + s);

        String str = input.nextLine();
        System.out.print("You entered string2 "+str);

    }
}
