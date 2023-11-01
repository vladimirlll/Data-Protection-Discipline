using DP.Lab7.Code;

string message = "";

using(StreamReader reader = new StreamReader("input.txt"))
{
    message = reader.ReadToEnd();
}

Console.WriteLine($"Сообщение, прочитанное из файла:\n{message}");

Console.WriteLine();
int chooice = 0;
do
{
    Console.WriteLine("Выберите что с ним сделать: ");
    Console.WriteLine("1. Зашифровать");
    Console.WriteLine("2. Дешифровать");
} while (!int.TryParse(Console.ReadLine(), out chooice) || chooice < 1 || chooice > 2);

string key = "";
Console.WriteLine();
Console.Write("Введите ключ: ");
key = Console.ReadLine()!;

RussianVigenereEncoder encoder = new RussianVigenereEncoder(key);

if(chooice == 1)
{
    Console.WriteLine($"Исходное сообщение: ");
    Console.WriteLine(message);
    Console.WriteLine();
    Console.WriteLine("Ключ:");
    Console.WriteLine(encoder.GetNormalizedKey(message));
    Console.WriteLine();
    Console.WriteLine($"Закодированное сообщение:\n{encoder.Encode(message)}");
}
else
{
    Console.WriteLine($"Закодированное сообщение: ");
    Console.WriteLine(message);
    Console.WriteLine("Ключ:");
    Console.WriteLine(encoder.GetNormalizedKey(message));
    Console.WriteLine();
    Console.WriteLine($"Декодированное сообщение:\n{encoder.Decode(message)}");
}