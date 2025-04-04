using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Student
{
    public int Id { get; set; }
    [MaxLength(30)]
    public string FirstName { get; set; }
    [MaxLength(30)]
    public string? LastName { get; set; }
    public DateTimeOffset BirthDate { get; set; }
    
    //navigations
    public Address Address { get; set; }
    public List<StudentGroup> StudentGroups { get; set; }
}
