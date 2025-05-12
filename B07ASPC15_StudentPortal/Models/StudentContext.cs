
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace B07ASPC15_StudentPortal.Models
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> op):base(op)
        {
                
        }
        public DbSet<StudentBasic> StudentBasics { get; set; }
    }
    public enum Shift
    {
        First=1,Second
    }
    public class StudentBasic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string PresentAdd { get; set; }
        public string PermanentAdd { get; set; }
        public string ImagePath { get; set; }

    }
    public class StudentAcademic
    {
        public int Id { get; set; }
        public string BoardRoll { get; set; }
        public string  Registration { get; set; }
        public string  Session { get; set; }
        public Shift  ShiftInfo { get; set; }
        [ForeignKey("StudentBasic")]
        public int StudentId { get; set; }
        public string Semester { get; set; }
        public string Year { get; set; }
        public  StudentBasic StudentBasic { get; set; }

    }
    public class Semester
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class StdSemester
    {
        public int Id { get; set; }
        [ForeignKey("StudentBasic")]
        public int StdId { get; set; }
        [ForeignKey("Semester")]
        public int SemesterId { get; set; }
        public string Year { get; set; }
        public Semester Semester { get; set; }

        public StudentBasic StudentBasic { get; set; }

    }
    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsCommon { get; set; }
    }
    public class TechwithSubject
    {
        public int Id { get; set; }
        [ForeignKey("Technology")]
        public int TechId { get; set; }
        [ForeignKey("Subject")]
        public int SubId { get; set; }
        public Technology Technology { get; set; }
        public Subject Subject { get; set; }
    }

    public class SemesterwithSubject
    {
        public int Id { get; set; }
        [ForeignKey("Subject")]
        public int SubId { get; set; }

        public int SemesterId { get; set; }
        public Subject Subject { get; set; }
        [ForeignKey("Semester")]
        public Semester Semester { get; set; }
        public string Year { get; set; }
    }


    public class FeeHead
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
    }
    public class StdAmount
    {
        public int Id { get; set; }
        [ForeignKey("StudentBasic")]
        public int StdId { get; set; }
        [ForeignKey("FeeHead")]
        public int FeeHeadId { get; set; }
        public float Amount { get; set; }
        public float PayAmount { get; set; }
        public float DiscountAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public StudentBasic StudentBasic { get; set; }
        public FeeHead FeeHead { get; set; }
    }

    }
