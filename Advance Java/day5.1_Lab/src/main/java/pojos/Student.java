package pojos;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.*;

@Entity
@Table(name = "Student_Table")
public class Student extends BaseEntity {
	@Column(name = "first_name", length = 50)
	private String FirstName;
	@Column(name = "Last_name", length = 50)
	private String LastName;
	@Column(name = "Email", length = 50)
	private String email;
	@OneToMany(mappedBy="Candidate",cascade=CascadeType.ALL,orphanRemoval=true)
	private List<Admissions> admissions=new ArrayList<>();

	private Student() {

	}

	@Override
	public String toString() {
		return "StudentID" + getId() + "[FirstName=" + FirstName + ", LastName=" + LastName + ", email=" + email + "]";
	}

	public String getFirstName() {
		return FirstName;
	}

	public void setFirstName(String firstName) {
		FirstName = firstName;
	}

	public String getLastName() {
		return LastName;
	}

	public void setLastName(String lastName) {
		LastName = lastName;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public Student(String firstName, String lastName, String email) {
		super();
		FirstName = firstName;
		LastName = lastName;
		this.email = email;
	}

}
