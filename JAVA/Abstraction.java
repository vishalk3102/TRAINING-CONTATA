
import java.util.Scanner;

abstract class Subject {
    Subject() {
        System.out.println("Learning Subject");
    }

    abstract void syllabus();
}

class IT extends Subject {
    void syllabus() {
        System.out.println("C++,JS,OS");
    }

    void show() {
        System.out.println("show function");
    }

}

public class Abstraction {
    public static void main(String[] args) {

        Subject obj = new IT();
        // obj.syllabus();
        // obj.show();

        IT obj2 = new IT();
        obj2.syllabus();
        obj2.show();
    }
}