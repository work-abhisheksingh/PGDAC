package tester;

import static utils.HibernateUtils.getFactory;

import java.util.Scanner;

import org.hibernate.SessionFactory;

import dao.CategoryDaoImpl;
import pojos.Category;
import pojos.Product;

public class AddNewCategoryWithProducts {

	public static void main(String[] args) {
		try (SessionFactory sf = getFactory(); Scanner sc = new Scanner(System.in)) {
			System.out.println("Hibernate up n running !" + sf);
			CategoryDaoImpl dao = new CategoryDaoImpl();
			System.out.println("Enter category name");
			String name = sc.nextLine();
			Category category = new Category(name, sc.nextLine());
			// Add 3 Products
			for (int i = 0; i < 3; i++) {
				System.out.println("Product Name");
				String pName = sc.nextLine();
				System.out.println("Enter price");
				double price = sc.nextDouble();
				sc.nextLine();
				System.out.println("Enter product desc");
				Product p = new Product(pName, price, sc.nextLine());
				category.addProduct(p);// Establishes BiDirectional Link
			}

			System.out.println(dao.addNewCategory(category));

		} // JVM : sf.close() => DB cn pool is cleaned up...
		catch (Exception e) {
			e.printStackTrace();
		}

	}

}
