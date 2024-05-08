import java.util.*;

interface Vehicles {

    void changeGear(int a);

    void speedUp(int a);

    void applyBrakes(int a);

}

class Bicycle implements Vehicles {
    int speed;
    int gear;

    Bicycle(int a, int b) {
        speed = a;
        gear = b;
    }

    public void changeGear(int newGear) {
        gear = newGear;
    }

    public void speedUp(int increment) {
        speed += increment;
    }

    public void applyBrakes(int decremnent) {
        speed -= decremnent;
    }

    public void print() {
        System.out.println("Gear : " + gear);
        System.out.println("speed : " + speed);
    }
}

public class InterfaceDemo {
    public static void main(String[] args) {
        Bicycle a = new Bicycle(30, 1);
        a.changeGear(4);
        a.print();

        a.speedUp(10);
        a.print();

        a.applyBrakes(20);
        a.print();

    }
}