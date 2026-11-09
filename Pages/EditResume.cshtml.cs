using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aspnetWebApp.Models;

namespace aspnetWebApp.Pages;

public class EditResumeModel : PageModel
{
    [BindProperty]
    public string TechnologiesText {get; set;} = "";
    [BindProperty]
    public Student Resume {get; set;} = new();
    public IActionResult OnGet(int id)
    {
        var student = CreateResumeModel.Students.FirstOrDefault(s => s.Id == id);
        if(student == null)
        {
            return NotFound();
        }
        Resume = new Student
        {
            Id = student.Id,
            Name = student.Name,
            Phone = student.Phone,
            Email = student.Email,
            MainLanguage = student.MainLanguage,
            ModeOfStudy = student.ModeOfStudy,
            Speciality = student.Speciality,
            Course = student.Course,
            BirthDate = student.BirthDate,
            Technologies = student.Technologies.ToArray(),
            Story = student.Story,
            City = student.City
        };
        TechnologiesText = string.Join(", ", student.Technologies);
        return Page();
    }

    public IActionResult OnPost()
    {
        var student = CreateResumeModel.Students
        .FirstOrDefault(s => s.Id == Resume.Id);
        
        if(student == null)
        {
            return NotFound();
        }
        student.Name = Resume.Name;
        student.Phone = Resume.Phone;
        student.Email = Resume.Email;
        student.MainLanguage = Resume.MainLanguage;
        student.ModeOfStudy = Resume.ModeOfStudy;
        student.Speciality = Resume.Speciality;
        student.Course = Resume.Course;
        student.BirthDate = Resume.BirthDate;
        student.Technologies = TechnologiesText
        .Split(",", StringSplitOptions.RemoveEmptyEntries)
        .Select(technology => technology.Trim())
        .Where(technology => technology.Length > 0)
        .ToArray();
        student.Story = Resume. Story;
        student.City = Resume.City;

        return RedirectToPage("/Resume", new {id = student.Id});
    }
}