using DP.Lab6.Presentational;

var keyWord = "";
do
{
    Console.Write("Введите ключевое слово: ");
    keyWord = Console.ReadLine();

} while (string.IsNullOrEmpty(keyWord));


int actionNum = 0;
int exitNum = 3;
do
{

    ThrithemiusEncoder encoder = new ThrithemiusEncoder(keyWord);

    string actionStr = "";
    do
    {
        Console.WriteLine("Выберите действие: ");
        Console.WriteLine("1. Закодировать сообщение.");
        Console.WriteLine("2. Декодировать сообщение.");
        Console.WriteLine("3. Выйти.");


    } while (!int.TryParse(actionStr = Console.ReadLine(), out actionNum) || actionNum < 1 || actionNum > 3);

    if(actionNum == 1)
    {
        string msg = "";
        do
        {
            Console.Write("Введите сообщение: ");
            msg = Console.ReadLine();
        } while (string.IsNullOrEmpty(msg));

        Console.WriteLine("Таблица: ");
        Console.WriteLine(encoder.Table.GetStringRepresentation());

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Закодированное сообщение: " + encoder.Encode(msg));
    }
    else if(actionNum == 2)
    {
        string encodedMsg = "";
        do
        {
            Console.Write("Введите закодированное сообщение: ");
            encodedMsg = Console.ReadLine();
        } while (string.IsNullOrEmpty(encodedMsg));

        Console.WriteLine("Таблица: ");
        Console.WriteLine(encoder.Table.GetStringRepresentation());

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Декодированное сообщение: " + encoder.Decode(encodedMsg));
    }
} while (actionNum != exitNum);