package pojos;

import java.time.LocalDate;
import java.util.Date;
import javax.persistence.*;
import org.hibernate.annotations.CreationTimestamp;

@Entity
@Table(name = "Admission_Table", uniqueConstraints = @UniqueConstraint(columnNames = {"Course_id","Student_id"}))
public class Admissions extends BaseEntity {
	@Column(name = "Applied_Date")
	@CreationTimestamp
	private LocalDate AppliedDate;
	@Column(name = "Result_Date")
	private LocalDate ResultDate;
	@ManyToOne
	@JoinColumn(name = "Student_id")
	private Student Candidate;
	@ManyToOne
	@JoinColumn(name="Course_id")
	private Courses ChosenCourse;
	@Enumerated(EnumType.STRING)
	@Column(name = "Status", length = 20)
	private Status status;

	public Admissions() {

	}

	public LocalDate getAppliedDate() {
		return AppliedDate;
	}

	public void setAppliedDate(LocalDate appliedDate) {
		AppliedDate = appliedDate;
	}

	public LocalDate getResultDate() {
		return ResultDate;
	}

	public void setResultDate(LocalDate resultDate) {
		ResultDate = resultDate;
	}

	public Student getCandidate() {
		return Candidate;
	}

	public void setCandidate(Student candidate) {
		Candidate = candidate;
	}

	public Courses getChosenCourse() {
		return ChosenCourse;
	}

	public void setChosenCourse(Courses chosenCourse) {
		ChosenCourse = chosenCourse;
	}

	@Override
	public String toString() {
		return "Admissions" + getId() + "[AppliedDate=" + AppliedDate + ", ResultDate=" + ResultDate + "]";
	}

}
