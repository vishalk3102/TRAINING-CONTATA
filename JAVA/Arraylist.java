import java.util.Scanner;
import java.util.ArrayList;
import java.util.Collections;

public class Arraylist {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        ArrayList<Integer> marks = new ArrayList<Integer>();
        marks.add(89);
        marks.add(57);

        for (int i : marks) {
            System.out.println(i);
        }
        System.out.println("Value of array after changing ");
        marks.set(0, 78);
        marks.set(1, 32);
        for (int i : marks) {
            System.out.println(i);
        }

        System.out.println("Value of array after sorting");
        Collections.sort(marks);
        for (int i : marks) {
            System.out.println(i);
        }

        System.out.println(marks.get(1));
        System.out.println(marks.remove(1));
        marks.clear();
        System.out.println("Value of array after clearing");
        for (int i : marks) {
            System.out.println(i);
        }
        System.out.println(marks.size());
    }
}