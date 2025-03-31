using System;
using System.Collections.Generic;

abstract class Notifier
{
    public abstract void OnServerUpdate(string status);
}

class ActivityLogger : Notifier
{
    public override void OnServerUpdate(string status)
    {
        Console.WriteLine($"[Лог активности]: Сервер сообщает - {status}");
    }
}

class EmailAlert : Notifier
{
    public override void OnServerUpdate(string status)
    {
        Console.WriteLine($"[Уведомление по Email]: Сервер сообщает - {status}");
    }
}

class ServerMonitor
{
    private List<Notifier> listeners = new List<Notifier>();

    public void AddListener(Notifier listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(Notifier listener)
    {
        listeners.Remove(listener);
    }

    public void NotifyListeners(string status)
    {
        foreach (var listener in listeners)
        {
            listener.OnServerUpdate(status);
        }
    }

    public void UpdateStatus(string newStatus)
    {
        Console.WriteLine($"[Сервер]: Обновление состояния - {newStatus}");
        NotifyListeners(newStatus);
    }
}

class App
{
    static void Main()
    {
        ServerMonitor server = new ServerMonitor();
        ActivityLogger logger = new ActivityLogger();
        EmailAlert email = new EmailAlert();

        Console.WriteLine("Настройка подписчиков для мониторинга сервера:");
        Console.WriteLine("1 - Добавить только логгер активности");
        Console.WriteLine("2 - Добавить только Email-уведомления");
        Console.WriteLine("3 - Добавить оба подписчика");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                server.AddListener(logger);
                Console.WriteLine("Логгер активности подключен.");
                break;
            case 2:
                server.AddListener(email);
                Console.WriteLine("Email уведомления подключены.");
                break;
            case 3:
                server.AddListener(logger);
                server.AddListener(email);
                Console.WriteLine("Оба подписчика подключены.");
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                return;
        }

        Console.WriteLine("Введите новое состояние сервера:");
        string status = Console.ReadLine();
        server.UpdateStatus(status);

        Console.WriteLine("Хотите отключить одного из подписчиков? (1 - Логгер, 2 - Email, 3 - Нет)");
        int detachChoice = int.Parse(Console.ReadLine());

        switch (detachChoice)
        {
            case 1:
                server.RemoveListener(logger);
                Console.WriteLine("Логгер активности отключен.");
                break;
            case 2:
                server.RemoveListener(email);
                Console.WriteLine("Email уведомления отключены.");
                break;
        }

        Console.WriteLine("Введите следующее состояние сервера:");
        status = Console.ReadLine();
        server.UpdateStatus(status);
    }
}
