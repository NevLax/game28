Random random = new Random();

while (true)
{
    switch (GetInput())
    {
        case "h":
        case "help": PrintHelp(); break;
        case "r":
        case "rules": PrintRules(); break;
        case "s":
        case "start": StartGame(); break;
        default:
            Console.WriteLine("Неверная команда");
            PrintHelp();
            break;
    }
}

string GetInput()
{
    Console.WriteLine("Введите команду");
    return Console.ReadLine();
}

void PrintHelp()
{
    Console.WriteLine("Посмотреть команды: \"help\" | \"h\"");
    Console.WriteLine("Начать игру: \"start\" | \"s\"");
    Console.WriteLine("Посмотреть правила \"rules\" | \"r\"");
}

void PrintRules()
{
    Console.WriteLine("У каждого игрока есть поле (массив чисел) от 4 до 24\n" +
        "Каждый раунд игроки бросают кубика\n" +
        "Сумма выпавших очков вноситься в поле\n" +
        "Задача - собрать на поле 4 ячейки подряд");
}

void StartGame()
{
    bool[] first = new bool[20];
    bool[] second = new bool[20];
    bool cycle = true;
    int i = 1;

    while(cycle)
    {
        Console.Write("\nХод " + i++ + " :");
        Step(first, second);
        if (Wins(first, second)) { cycle = false; }
    }
}

bool Wins(bool[] first, bool[] second)
{
    bool firstResult = HasFourTrueInARow(first);
    bool secondResult = HasFourTrueInARow(second);

    if (firstResult || secondResult)
    {
        if (firstResult != secondResult)
        {
            if (firstResult) Console.WriteLine("Победил первый игрок");
            else Console.WriteLine("Победил второй игрок");
        }
        else { Console.WriteLine("Ничья"); }
        return true;
    }
    return false;
}

void Step(bool[] firstBoard, bool[] secondBoard)
{
    firstBoard[GetRanodmDice()] = true;
    secondBoard[GetRanodmDice()] = true;

    Console.Write("Первая доска");
    PrintBoard(firstBoard);
    Console.Write("Вторая доска");
    PrintBoard(secondBoard);
}

void PrintBoard(bool[] board)
{
    foreach (bool b in board)
    {
        if (b) { Console.Write("*"); }
        else { Console.Write("-"); }
    }
}

int GetRanodmDice()
{
    return random.Next(20);
}

bool HasFourTrueInARow(bool[] arr)
{
    int count = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i])
        {
            count++;
            if (count == 4) { return true; }
        }
        else { count = 0; }
    }
    return false;
}