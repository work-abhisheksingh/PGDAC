package pojos;

import java.time.LocalDate;
import javax.persistence.*;
//Employee : id (auto_increment : PK) , first name ,last name , 
//department (enum : RND,FINANCE,MARKETING,HR,BILLING), salary, dob(LocalDate) ,isPermanent(boolean)

@Entity
@Table(name = "emps", uniqueConstraints = @UniqueConstraint(columnNames = { "first_name", "last_name" }))
public class Employee {
	@Id // PK
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "emp_id")
	private Long empid;
	@Column(name = "first_name", length = 30)
	private String firstName;
	@Column(name = "last_name", length = 30)

	private String lastName;
	@Enumerated(EnumType.STRING) // =>Col type: Varchar, enum
	@Column(length = 30)
	private Department dept;
	private double salary;
	private LocalDate dob;
	private boolean is_Permanent;

	public Employee(Long empid, String firstName, String lastName, Department dept, double salary, LocalDate dob,
			boolean is_Permanent) {
		super();
		this.empid = empid;
		this.firstName = firstName;
		this.lastName = lastName;
		this.dept = dept;
		this.salary = salary;
		this.dob = dob;
		this.is_Permanent = is_Permanent;
	}

}
