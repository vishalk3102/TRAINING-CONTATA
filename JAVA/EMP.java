import java.util.ArrayList;
import java.util.NoSuchElementException;
import java.util.Scanner;

interface Company {
    String companyName = "Contata Solutions";
    String location = "Noida";

    void showDetails();
}

class Employees implements Company {
    int empId;
    String empName;

    // FUNCTION TO INSERT EMPLOYEE
    void insertDetails(int empId, String empName) {
        this.empId = empId;
        this.empName = empName;
    }

    // FUNCTION TO GET EMPLOYEE
    void getDetails(int id, ArrayList<Employees> employeeList) {

        try {
            boolean found = false;
            for (Employees e : employeeList) {
                if (e.empId == id) {
                    found = true;
                    System.out.println("\n\n");
                    e.showDetails();
                    break;
                }
            }
            if (!found) {
                throw new NoSuchElementException("Employee ID doesn't exist");
            }
        } catch (NoSuchElementException e) {
            System.out.println(e.getMessage());
        }

    }

    // FUNCTION TO UPDATE EMPLOYEE
    void updateDetails(int id, ArrayList<Employees> employeeList) {

        try {
            Scanner sc = new Scanner(System.in);
            boolean found = false;
            for (Employees e : employeeList) {
                if (e.empId == id) {
                    found = true;
                    System.out.println("Enter  Your Details to be updated :");
                    System.out.print("Name:");
                    e.empName = sc.next();
                    break;
                }
            }
            if (!found) {
                throw new NoSuchElementException("Employee ID doesn't exist");
            }
        } catch (NoSuchElementException e) {
            System.out.println(e.getMessage());
        }

    }

    // FUNCTION TO DELETE EMPLOYEE
    void deleteDetails(int id, ArrayList<Employees> employeeList) {
        try {
            boolean found = false;
            for (Employees e : employeeList) {
                if (e.empId == id) {
                    found = true;
                    employeeList.remove(e);
                    break;
                }
            }
            if (!found) {
                throw new NoSuchElementException("Employee ID doesn't exist");
            }
        } catch (NoSuchElementException e) {
            System.out.println(e.getMessage());
        }
    }

    // FUNCTION TO GET ALL REGISTERED EMPLOYEES
    void getAllEmployees(ArrayList<Employees> employeeList) {
        System.out.println("\nEmployees List");
        for (Employees emp : employeeList) {
            System.out.print(emp.empId + " : " + emp.empName + "\n");
        }
    }

    // FUNCTION TO DIPLAY EMPLOYEE
    @Override
    public void showDetails() {

        System.err.println("ID : " + empId);
        System.err.println("Name : " + empName);
        System.err.println("CompanyName : " + companyName);
        System.err.println("Location : " + location);
        System.out.println("\n");
    }
}

class Assets implements Company {
    int assetId;
    String assetName;

    // FUNCTION TO INSERT ASSETS
    void insertAssets(int assetId, String assetName) {
        this.assetId = assetId;
        this.assetName = assetName;
    }

    // FUNCTION TO GET ASSETS
    void getAssets(int id, ArrayList<Assets> assetsList) {
        try {
            boolean found = false;
            for (Assets a : assetsList) {
                if (a.assetId == id) {
                    found = true;
                    a.showDetails();
                    break;
                }
            }

            if (!found) {
                throw new NoSuchElementException("Asset ID doesn't exist");
            }
        } catch (NoSuchElementException e) {
            System.out.println(e.getMessage());
        }
    }

    // FUNCTION TO UPDATE ASSETS
    void updateAssets(int id, ArrayList<Assets> assetsList) {
        try {
            Scanner sc = new Scanner(System.in);
            boolean found = false;
            for (Assets a : assetsList) {
                if (a.assetId == id) {
                    found = true;
                    System.out.println("Update Assets Details:");
                    System.out.print("Asset Name:");
                    a.assetName = sc.next();
                    break;
                }
            }

            if (!found) {
                throw new NoSuchElementException("Asset ID doesn't exist");
            }
        } catch (NoSuchElementException e) {
            System.out.println(e.getMessage());
        }

    }

    // FUNCTION TO DELETE ASSETS
    void deleteAssets(int id, ArrayList<Assets> assetsList) {
        try {
            Scanner sc = new Scanner(System.in);
            boolean found = false;
            for (Assets a : assetsList) {
                if (a.assetId == id) {
                    found = true;
                    assetsList.remove(a);
                    break;
                }
            }

            if (!found) {
                throw new NoSuchElementException("Asset ID doesn't exist");
            }
        } catch (NoSuchElementException e) {
            System.out.println(e.getMessage());
        }
    }

    // FUNCTION TO GET ALL REGISTERED ASSETS
    void getAllAssets(ArrayList<Assets> assetsList) {
        System.out.println("\n Assets List");
        for (Assets a : assetsList) {
            System.out.print(a.assetId + " : " + a.assetName + "\n");
        }
    }

    // FUNCTION TO DISPLAY ASSETS
    @Override
    public void showDetails() {
        System.err.println("Assets Id : " + assetId);
        System.err.println("Assets Name : " + assetName);
    }
}

public class EMP {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        ArrayList<Employees> employeeList = new ArrayList<Employees>();
        ArrayList<Assets> assetsList = new ArrayList<Assets>();

        // CREATING OBJECTS OF EMPLOYEES AND ASSETS CLASS
        Employees emp = new Employees();
        Assets item = new Assets();

        boolean flag = true;
        while (flag) {
            System.out.print("\nWelcome To EMS Menu\n");
            System.out.print("1) Get Details\n");
            System.out.print("2) Insert Details\n");
            System.out.print("3) update Details\n");
            System.out.print("4) Delete Details\n");
            System.out.print("5) Get Assets Details\n");
            System.out.print("6) Insert Assets Details\n");
            System.out.print("7) update Assets Details\n");
            System.out.print("8) Delete Assets Details\n");
            System.out.print("9) Get All Employees :\n");
            System.out.print("10) Get All Assets  :\n");
            System.out.print("11) Exit\n");
            System.out.print("\nEnter your option\n");
            int option = sc.nextInt();

            switch (option) {
                case 1:
                    System.out.println("\nEnter Your Details");
                    System.out.print("Employee ID : ");
                    int getId = sc.nextInt();
                    emp.getDetails(getId, employeeList);
                    break;
                case 2:
                    System.out.println("\nEnter Employee Details");
                    System.out.print("Employee ID : ");
                    int empId = sc.nextInt();
                    System.out.print("Employee Name : ");
                    String empName = sc.next();

                    Employees empAdd = new Employees();
                    empAdd.insertDetails(empId, empName);
                    employeeList.add(empAdd);
                    break;
                case 3:
                    System.out.print("\nEnter Employee ID : ");
                    int updateId = sc.nextInt();
                    emp.updateDetails(updateId, employeeList);
                    break;
                case 4:
                    System.out.print("\nEnter Employee ID : ");
                    int deleteId = sc.nextInt();
                    emp.deleteDetails(deleteId, employeeList);
                    break;

                case 5:
                    System.out.print("\nEnter Assets ID : ");
                    int getAssetId = sc.nextInt();
                    item.getAssets(getAssetId, assetsList);
                    break;
                case 6:
                    System.out.println("\nEnter Assets Details");
                    System.out.print("Assets ID : ");
                    int assetId = sc.nextInt();
                    System.out.print("Asset Name : ");
                    String assetName = sc.next();

                    Assets items = new Assets();
                    items.insertAssets(assetId, assetName);
                    assetsList.add(items);
                    break;
                case 7:
                    System.out.print("\nEnter Asset ID : ");
                    int updateAssetId = sc.nextInt();
                    item.updateAssets(updateAssetId, assetsList);
                    break;
                case 8:
                    System.out.print("\nEnter Assets ID : ");
                    int deleteAssetId = sc.nextInt();
                    item.deleteAssets(deleteAssetId, assetsList);
                    break;

                case 9:
                    emp.getAllEmployees(employeeList);
                    break;

                case 10:
                    item.getAllAssets(assetsList);
                    break;

                case 11:
                    System.out.println("\nExiting EMS");
                    flag = false;
                    break;
                default:
                    System.out.println("\nWrong Input");
                    break;
            }
        }
    }
}