using DP.Lab9.Code;

string msg = "";
int chooice = 0;
OneTimeCipherEncoder encoder = new OneTimeCipherEncoder();


do
{
    do
    {
        Console.Write("Введите исходное или зашифрованное сообщение: ");
        msg = Console.ReadLine();
    } while (string.IsNullOrEmpty(msg));

    Console.WriteLine();

    do
    {
        Console.WriteLine("Выберите что с ним сделать: ");
        Console.WriteLine("1. Зашифровать");
        Console.WriteLine("2. Дешифровать");
    } while (!int.TryParse(Console.ReadLine(), out chooice) || chooice < 1 || chooice > 2);


    if (chooice == 1)
    {
        string encoded = encoder.Encode(msg);
        Console.WriteLine($"Исходное сообщение: ");
        Console.WriteLine(msg);
        Console.WriteLine();
        Console.WriteLine("Ключ: ");
        Console.WriteLine(string.Join("|", encoder.Key));
        Console.WriteLine();
        Console.WriteLine($"Закодированное сообщение:\n{encoded}");
    }
    else
    {
        Console.WriteLine($"Закодированное сообщение: ");
        Console.WriteLine(msg);
        Console.WriteLine("Ключ:");
        Console.WriteLine(string.Join("|", encoder.Key));
        Console.WriteLine();
        Console.WriteLine($"Декодированное сообщение:\n{encoder.Decode(msg)}");
    }

    Console.Write("Для окончания работы программы введите 3 или любой другой символ для продолжения работы: ");


} while (!int.TryParse(Console.ReadLine(), out chooice) || chooice != 3);
