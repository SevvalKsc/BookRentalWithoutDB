using System.Collections;

namespace BookRentalWithoutDB.Models;

public class Student
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
}