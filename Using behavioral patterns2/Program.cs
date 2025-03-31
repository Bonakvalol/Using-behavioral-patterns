using System;

abstract class TaxStrategy
{
    public abstract decimal Calculate(decimal income);
}

class ProgressiveTax : TaxStrategy
{
    public override decimal Calculate(decimal income)
    {
        if (income <= 10000) return income * 0.1m;
        else if (income <= 50000) return 1000 + (income - 10000) * 0.2m;
        else return 9000 + (income - 50000) * 0.3m;
    }
}

class FixedRateTax : TaxStrategy
{
    private readonly decimal rate;
    public FixedRateTax(decimal rate) { this.rate = rate; }
    public override decimal Calculate(decimal income) { return income * rate; }
}

class TaxCalc
{
    private TaxStrategy strategy;

    public void SetStrategy(TaxStrategy strategy)
    {
        this.strategy = strategy;
    }

    public decimal Calculate(decimal income)
    {
        if (strategy == null)
            throw new InvalidOperationException("Стратегия не установлена.");
        return strategy.Calculate(income);
    }
}

class Program
{
    static void Main()
    {
        TaxCalc calc = new TaxCalc();

        try
        {
            Console.WriteLine("Выберите систему налогообложения:");
            Console.WriteLine("1 - Прогрессивная система");
            Console.WriteLine("2 - Фиксированная ставка");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                calc.SetStrategy(new ProgressiveTax());
            }
            else if (choice == 2)
            {
                Console.WriteLine("Введите фиксированную ставку (например, 0.15 для 15%):");
                decimal rate = decimal.Parse(Console.ReadLine());
                calc.SetStrategy(new FixedRateTax(rate));
            }
            else
            {
                Console.WriteLine("Неверный выбор.");
                return;
            }

            Console.WriteLine("Введите доход:");
            decimal income = decimal.Parse(Console.ReadLine());

            decimal tax = calc.Calculate(income);
            Console.WriteLine($"Рассчитанный налог: {tax}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Неверный формат ввода. Пожалуйста, введите числовое значение.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
