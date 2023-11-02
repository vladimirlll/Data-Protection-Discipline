using DP.Lab8.Code;
using System.Runtime.CompilerServices;
using System.Text;

string msg = string.Empty;

Console.Write("Введите путь к файлу: ");
string filePath = Console.ReadLine()!;

using (StreamReader reader = new StreamReader(filePath, true))
{
    msg = reader.ReadToEnd();
}

Console.WriteLine($"Сообщение, прочитанное из файла - {filePath}:\n{msg}");

Console.WriteLine();
int chooice = 0;
do
{
    Console.WriteLine("Выберите что с ним сделать: ");
    Console.WriteLine("1. Зашифровать и сохранить в файлы символами и кодами");
    Console.WriteLine("2. Дешифровать из файла с кодами символов");
} while (!int.TryParse(Console.ReadLine(), out chooice) || chooice < 1 || chooice > 2);

Generator generator = new Generator(1000);
GammaEncoder encoder = new GammaEncoder(generator);

Console.OutputEncoding = Encoding.UTF8;

if (chooice == 1)
{
    string encoded = encoder.Encode(msg);

    using (StreamWriter writer = new StreamWriter("encoded_nums.txt", false, Encoding.UTF8))
    {
        List<int> nums = encoded.Select(sym => (int)sym).ToList();
        writer.WriteLine(string.Join(' ', nums));
    }

    using(StreamWriter writer = new StreamWriter("encoded.txt", false, Encoding.UTF8))
    {
        writer.WriteLine(encoded);
    }

    Console.WriteLine();
    Console.WriteLine($"Зашифрованное сообщение сохранено в файле encoded.txt - {encoded}");
    Console.WriteLine($"Коды символов зашифрованного сообщения сохранены в файле encoded_nums.txt, использовать этот файл в качестве исходного сообщения для расшифровки");
}
else
{
    
    List<int> nums = msg.Split(' ').Select(str => int.Parse(str)).ToList();
    msg = "";
    foreach (var num in nums)
    {
        msg += (char)num;
    }

    string decoded = encoder.Decode(msg);

    using (StreamWriter writer = new StreamWriter("decoded.txt", false, Encoding.UTF8))
    {
        writer.WriteLine(decoded);
    }

    Console.WriteLine();
    Console.WriteLine($"Дешифрованное сообщение сохранено в файле decoded.txt - {decoded}");
}