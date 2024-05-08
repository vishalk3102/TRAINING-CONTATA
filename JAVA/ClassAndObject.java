import java.util.Scanner;

public class ClassAndObject {

    private int x;
    private String name;

    public ClassAndObject() {
        x = 1;
        name = "Vishal Kumar";
    }

    public ClassAndObject(int x, String name) {
        this.x = x;
        this.name = name;
    }

    public void show() {
        System.out.println("ID :" + x);
        System.out.println("Name :" + name);
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        ClassAndObject a = new ClassAndObject();
        ClassAndObject b = new ClassAndObject(2, "VK");
        System.out.println("Values of object a:");
        a.show();
        System.out.println("Values of object b:");
        b.show();

    }
}