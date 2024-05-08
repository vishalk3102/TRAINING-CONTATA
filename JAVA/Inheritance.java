
class Vehicle {
    String brand = "ford";

    public void showDetails() {
        System.out.println(brand);
    }

}

public class Inheritance extends Vehicle {

    String modelName = "mustang";

    public static void main(String[] args) {
        Inheritance obj = new Inheritance();
        obj.showDetails();
        System.out.println("brand :" + obj.brand + " model Name :" + obj.modelName);
    }
}