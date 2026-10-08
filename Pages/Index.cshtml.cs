using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aspnetWebApp.Models;

namespace aspnetWebApp.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public required string Name { get; set; }
    [BindProperty]
    public required string Phone { get; set; }
    [BindProperty]
    public required string Email { get; set; }
    [BindProperty]
    public required string MainLanguage {get; set;}
    [BindProperty]
    public required string ModeOfStudy {get; set; }
    [BindProperty]
    public required string Speciality { get; set; }
    [BindProperty]
    public required string Course { get; set; }
    [BindProperty]
    public required string BirthDate { get; set; }
    [BindProperty]
    public string[] Technologies { get; set; } = Array.Empty<string>();
    [BindProperty]
    public required string Story {get; set;}
    [BindProperty]
    public required string City {get; set; }
    public required string Message { get; set; }
    public static List<Student> Students {get; set; } = new();

    public void OnGet()
    {
        // Message = "Привет! Сообщение от C#";
    }
    public IActionResult OnPost() {

        string technologies = Technologies.Length > 0
            ? string.Join(", ", Technologies)
            : "Не выбраны";


        var student = new Student {
            Id = Students.Any() ? Students.Max(x => x.Id) + 1 : 1, 
            Name = Name,
            Phone = Phone,
            Email = Email,
            MainLanguage = MainLanguage,
            ModeOfStudy = ModeOfStudy,
            Speciality = Speciality,
            Course = Course,
            BirthDate = BirthDate,
            Technologies = Technologies,
            Story = Story,
            City = City
        };
        
        // return Content(JsonSerializer.Serialize(student), "application/json");
        Students.Add(student);
        return new JsonResult(student);
    }

    public IActionResult OnGetStudents() {
        return new JsonResult(Students);
    }

    public IActionResult OnPostDelete(int id) {
        var student = Students.FirstOrDefault(x => x.Id == id);
        if (student == null) {
            return new JsonResult(new {
                success = false,
                message = "Студент не найден"
            });
        }
        Students.Remove(student);
        return new JsonResult(new {
            success = true
        });
    }
}
