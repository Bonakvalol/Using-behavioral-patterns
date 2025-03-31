using System;

public interface DocumentState
{
    void ExecuteAction(string action);
}

public class NewState : DocumentState
{
    public void ExecuteAction(string action)
    {
        switch (action)
        {
            case "open":
                Console.WriteLine("Документ открыт.");
                break;
            case "save":
                Console.WriteLine("Документ сохранен.");
                break;
            case "close":
                Console.WriteLine("Документ закрыт.");
                break;
            case "print":
                Console.WriteLine("Документ не может быть распечатан, так как он новый.");
                break;
            default:
                Console.WriteLine("Действие не поддерживается в данном состоянии.");
                break;
        }
    }
}

public class OpenState : DocumentState
{
    public void ExecuteAction(string action)
    {
        switch (action)
        {
            case "open":
                Console.WriteLine("Документ уже открыт.");
                break;
            case "save":
                Console.WriteLine("Документ сохранен.");
                break;
            case "close":
                Console.WriteLine("Документ закрыт.");
                break;
            case "print":
                Console.WriteLine("Документ распечатан.");
                break;
            default:
                Console.WriteLine("Действие не поддерживается в данном состоянии.");
                break;
        }
    }
}

public class SavedState : DocumentState
{
    public void ExecuteAction(string action)
    {
        switch (action)
        {
            case "open":
                Console.WriteLine("Документ открыт.");
                break;
            case "save":
                Console.WriteLine("Документ уже сохранен.");
                break;
            case "close":
                Console.WriteLine("Документ закрыт.");
                break;
            case "print":
                Console.WriteLine("Документ распечатан.");
                break;
            default:
                Console.WriteLine("Действие не поддерживается в данном состоянии.");
                break;
        }
    }
}

public class ModifiedState : DocumentState
{
    public void ExecuteAction(string action)
    {
        switch (action)
        {
            case "open":
                Console.WriteLine("Документ открыт.");
                break;
            case "save":
                Console.WriteLine("Документ сохранен.");
                break;
            case "close":
                Console.WriteLine("Документ закрыт.");
                break;
            case "print":
                Console.WriteLine("Документ распечатан.");
                break;
            default:
                Console.WriteLine("Действие не поддерживается в данном состоянии.");
                break;
        }
    }
}

public class Document
{
    private DocumentState state;

    public Document()
    {
        state = new NewState();
    }

    public void SetState(DocumentState newState)
    {
        state = newState;
    }

    public void ExecuteAction(string action)
    {
        state.ExecuteAction(action);
    }
}

class Program
{
    static void Main()
    {
        Document doc = new Document();

        while (true)
        {
            Console.WriteLine("Что хотите сделать с документом?");
            Console.WriteLine("1. Открыть");
            Console.WriteLine("2. Сохранить");
            Console.WriteLine("3. Закрыть");
            Console.WriteLine("4. Распечатать");
            Console.WriteLine("5. Изменить состояние документа");
            Console.WriteLine("6. Выйти");
            Console.Write("Введите номер действия: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    doc.ExecuteAction("open");
                    break;
                case "2":
                    doc.ExecuteAction("save");
                    break;
                case "3":
                    doc.ExecuteAction("close");
                    break;
                case "4":
                    doc.ExecuteAction("print");
                    break;
                case "5":
                    Console.WriteLine("Выберите состояние документа:");
                    Console.WriteLine("1. Новый");
                    Console.WriteLine("2. Открытый");
                    Console.WriteLine("3. Сохраненный");
                    Console.WriteLine("4. Измененный");
                    var stateChoice = Console.ReadLine();

                    switch (stateChoice)
                    {
                        case "1":
                            doc.SetState(new NewState());
                            break;
                        case "2":
                            doc.SetState(new OpenState());
                            break;
                        case "3":
                            doc.SetState(new SavedState());
                            break;
                        case "4":
                            doc.SetState(new ModifiedState());
                            break;
                        default:
                            Console.WriteLine("Неверный выбор.");
                            break;
                    }
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}
