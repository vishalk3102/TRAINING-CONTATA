import java.util.Scanner;

public class Array {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int[] nums = new int[2];
        nums[0] = 0;
        nums[0] = 1;

        System.out.println(" value of array numbers");
        for (int i = 0; i < nums.length; i++) {
            System.out.println(nums[i]);
        }

        String[] cars = new String[] { "bmw", "audi", "mercedes" };
        System.out.println(" value of array cars");
        for (String i : cars) {
            System.err.println(i);
        }

        int[] marks = new int[5];
        System.out.println(" enter the value of array marks");
        for(int i=0;i<marks.length;i++)
        {
           marks[i]=sc.nextInt();
        }
        System.out.println(" value of array marks");
        for (int i : marks) {
            System.out.println(i);
        }
    }
}