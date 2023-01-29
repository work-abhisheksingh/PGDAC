package pojos;

import java.time.*;
import java.util.ArrayList;
import java.util.List;

import javax.persistence.*;

@Entity
@Table(name = "Courses_table")
public class Courses extends BaseEntity {
	@Column(name = "Course_Title", unique = true, length = 100)
	private String CourseTitle;
	@Column(name = "start_Date")
	private LocalDate startDate;
	@Column(name = "end_Date")
	private LocalDate endDate;

	private double fees;

	private int capacity;
	//Course 1--->*Admission
	@OneToMany(mappedBy="ChosenCourse",cascade=CascadeType.ALL,orphanRemoval=true)
	private List<Admissions> admissions=new ArrayList<>();

	public Courses() {

	}

	public Courses(String courseTitle, LocalDate startDate, LocalDate endDate, double fees, int capacity) {
		super();
		CourseTitle = courseTitle;
		this.startDate = startDate;
		this.endDate = endDate;
		this.fees = fees;
		this.capacity = capacity;
	}

	public String getCourseTitle() {
		return CourseTitle;
	}

	public void setCourseTitle(String courseTitle) {
		CourseTitle = courseTitle;
	}

	public LocalDate getStartDate() {
		return startDate;
	}

	public void setStartDate(LocalDate startDate) {
		this.startDate = startDate;
	}

	public LocalDate getEndDate() {
		return endDate;
	}

	public void setEndDate(LocalDate endDate) {
		this.endDate = endDate;
	}

	public double getFees() {
		return fees;
	}

	public void setFees(double fees) {
		this.fees = fees;
	}

	public int getCapacity() {
		return capacity;
	}

	public void setCapacity(int capacity) {
		this.capacity = capacity;
	}

}
