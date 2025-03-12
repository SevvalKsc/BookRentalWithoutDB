using BookRentalWithoutDB.Models;

namespace BookRentalWithoutDB.Data;

public class StudentRespository
{
    static List<Student> data = new List<Student> //Student = Model
    {
        new Student{ID = 1, Name = "Şevval", Surname = "Kuşçu", BirthDate = new DateTime(2000, 10, 18)},
        new Student{ID = 2, Name = "Burak", Surname = "Kuşçu", BirthDate = new DateTime(2000, 10, 18)},
        new Student{ID = 3, Name = "Hüseyin", Surname = "Şimşek", BirthDate = new DateTime(1990, 1, 1)}
    };

    public List<Student> GetAllStudents()
    {
        return data; //"Select * from students";
    }

    public Student GetStudent(int id) //Select * from students where ID = 1
    {
        Student result = data.Where(s => s.ID == id).FirstOrDefault();
        
        return result;
    }

    public void Insert(Student student)
    {
        if (student != null)
        {
            int newId = data.Any() ? data.Max(s => s.ID) + 1 : 1;
            student.ID = newId;
            data.Add(student);
        }
    }

    public void Update(Student student)
    {
        var studentInDB = data.Where(s => s.ID == student.ID).FirstOrDefault();
        if (studentInDB != null)
        {
            studentInDB.Name = student.Name;
            studentInDB.Surname = student.Surname;
            studentInDB.BirthDate = student.BirthDate;
        }
    }

    public void Delete(int id)
    {
        data.RemoveAll(d => d.ID == id);
    }
}