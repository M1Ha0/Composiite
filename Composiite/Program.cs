using System;
using System.Collections.Generic;

interface IUnit
{
    void Attack();
}

class Warrior : IUnit
{
    public void Attack()
    {
        Console.WriteLine("Воин атакует мечом!");
    }
}

class Mage : IUnit
{
    public void Attack()
    {
        Console.WriteLine("Маг атакует заклинанием!");
    }
}

class Archer : IUnit
{
    public void Attack()
    {
        Console.WriteLine("Лучник атакует из лука!");
    }
}

class Squad : IUnit
{
    private string name;
    private List<IUnit> units = new List<IUnit>();

    public Squad(string name)
    {
        this.name = name;
    }

    public void Add(IUnit unit)
    {
        units.Add(unit);
    }

    public void Attack()
    {
        Console.WriteLine($"\n--- Отряд «{name}» идет в атаку! ---");
        foreach (IUnit unit in units)
        {
            unit.Attack();
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== RPG: Система управления отрядами ===");

        IUnit warrior1 = new Warrior();
        IUnit mage1 = new Mage();
        IUnit archer1 = new Archer();

        Squad vanguardSquad = new Squad("Авангард");
        vanguardSquad.Add(warrior1);
        vanguardSquad.Add(archer1);

        IUnit warrior2 = new Warrior();
        IUnit mage2 = new Mage();

        Squad mainSquad = new Squad("Главная Армия");
        mainSquad.Add(mage2);
        mainSquad.Add(warrior2);
        mainSquad.Add(vanguardSquad);

        Console.WriteLine("\nОдиночный воин:");
        warrior1.Attack();

        mainSquad.Attack();
    }
}