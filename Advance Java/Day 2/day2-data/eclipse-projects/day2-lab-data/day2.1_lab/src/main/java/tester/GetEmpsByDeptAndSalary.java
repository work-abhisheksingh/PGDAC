package tester;

import static utils.HibernateUtils.getFactory;

import java.util.Scanner;

import org.hibernate.SessionFactory;

import dao.EmployeeDaoImpl;
import pojos.Department;

public class GetEmpsByDeptAndSalary {

	public static void main(String[] args) {
		try (SessionFactory sf = getFactory(); Scanner sc = new Scanner(System.in)) {
			// create user dao instance
			EmployeeDaoImpl dao = new EmployeeDaoImpl();
			System.out.println("Enter dept min sal");
			dao.getEmpsByDeptAndSalary
			(Department.valueOf(sc.next().toUpperCase()), 
					sc.nextDouble()).forEach(System.out::println);

		} // JVM : sc.close , sf.close() => DB cn pool is cleaned up...
		catch (Exception e) {
			e.printStackTrace();
		}

	}

}
