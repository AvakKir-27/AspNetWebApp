using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetWebApp.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string Name { get; set; }
    [BindProperty]
    public string Phone { get; set; }
    [BindProperty]
    public string Email { get; set; }
    [BindProperty]
    public string MainLanguage {get; set;}
    [BindProperty]
    public string ModeOfStudy {get; set; }
    [BindProperty]
    public string Speciality { get; set; }
    [BindProperty]
    public string Course { get; set; }
    [BindProperty]
    public string BirthDate { get; set; }
    [BindProperty]
    public string[] Technologies { get; set; } = Array.Empty<string>();
    [BindProperty]
    public string Story {get; set;}
    [BindProperty]
    public string City {get; set; }
    public string Message { get; set; }
    public void OnGet()
    {
        // Message = "Привет! Сообщение от C#";
    }
    public IActionResult OnPost() {

        string technologies = Technologies.Length > 0
            ? string.Join(", ", Technologies)
            : "Не выбраны";

        string message = $"Анкета студента\n\n" +
                $"Имя: {Name}\n" + 
                $"Телефон: {Phone}\n" +
                $"Email: {Email}\n" +
                $"Город: {City}\n" +
                $"Основной язык программирования: {MainLanguage}\n" +
                $"Формат обучения: {ModeOfStudy}\n" +
                $"Специальность: {Speciality}\n" +
                $"Курс: {Course}\n" +
                $"Дата рождения: {BirthDate}\n" +
                $"Технологии: {technologies}\n" +
                $"О себе: {Story}";
        
        return Content(message);
    }
}
