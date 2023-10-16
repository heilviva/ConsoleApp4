using System;
using System.Collections.Generic;

class Program
{
    static int currentNoteIndex = 0;
    static List<Note> notes = new List<Note>();

    static void Main()
    {
        InitializeNotes();

        ConsoleKeyInfo key;
        do
        {
            Console.Clear();
            ShowNoteTitle();

            key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    GoToPreviousDate();
                    break;
                case ConsoleKey.RightArrow:
                    GoToNextDate();
                    break;
                case ConsoleKey.Enter:
                    ShowNoteDetails();
                    break;
            }
        } while (key.Key != ConsoleKey.Escape);
    }

    static void InitializeNotes()
    {
        // Создаем заметки с разными датами
        notes.Add(new Note { Title = "Заметка 1", Description = "Описание заметки 1", Date = new DateTime(2023, 10, 16) });
        notes.Add(new Note { Title = "Заметка 2", Description = "Описание заметки 2", Date = new DateTime(2023, 10, 17) });
        notes.Add(new Note { Title = "Заметка 3", Description = "Описание заметки 3", Date = new DateTime(2023, 10, 18) });
        notes.Add(new Note { Title = "Заметка 4", Description = "Описание заметки 4", Date = new DateTime(2023, 10, 19) });
        notes.Add(new Note { Title = "Заметка 5", Description = "Описание заметки 5", Date = new DateTime(2023, 10, 20) });
    }

    static void ShowNoteTitle()
    {
        Note currentNote = notes[currentNoteIndex];
        Console.WriteLine("Дата: " + currentNote.Date.ToString("dd.MM.yyyy"));
        Console.WriteLine("Название: " + currentNote.Title);
        Console.WriteLine();
        Console.WriteLine("Используйте стрелки влево/вправо для переключения дат");
        Console.WriteLine("Нажмите Enter для просмотра подробной информации");
        Console.WriteLine("Нажмите Escape для выхода");
    }

    static void GoToNextDate()
    {
        currentNoteIndex = (currentNoteIndex + 1) % notes.Count;
    }

    static void GoToPreviousDate()
    {
        currentNoteIndex = (currentNoteIndex - 1 + notes.Count) % notes.Count;
    }

    static void ShowNoteDetails()
    {
        Note currentNote = notes[currentNoteIndex];
        Console.Clear();
        Console.WriteLine("Дата: " + currentNote.Date.ToString("dd.MM.yyyy"));
        Console.WriteLine("Название: " + currentNote.Title);
        Console.WriteLine("Описание: " + currentNote.Description);
        Console.WriteLine("Заметка должна быть выполнена: " + currentNote.DueDate.ToString("dd.MM.yyyy"));
        Console.WriteLine();
        Console.WriteLine("Нажмите любую клавишу для возврата к списку заметок");
        Console.ReadKey();
    }
}

class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}