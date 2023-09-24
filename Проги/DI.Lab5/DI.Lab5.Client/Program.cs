using Autofac;
using DI.Lab5.Base;
using DI.Lab5.Client.Models;
using DI.Lab5.Realization.Encoders;

var builder = new ContainerBuilder();

builder.RegisterType<PermutationKeeper>().SingleInstance();
builder.Register<IEncoder>(c => new SubstitutionEncoder(4, 
    c.Resolve<PermutationKeeper>().Permutation));

var container = builder.Build();

using(var scope = container.BeginLifetimeScope())
{
    try
    {
        var permutationKeeper = container.Resolve<PermutationKeeper>();

        Console.Write("Введите исходное сообщение: ");
        var msg = Console.ReadLine();
        Console.WriteLine("\nВведите подстановку для заданного сообщения");
        var permutation = Console.ReadLine();
        permutationKeeper.SetPermutationFromString(permutation!);

        Console.WriteLine("\n\n\nИсходное сообщение: " + msg);
        var encoder = container.Resolve<IEncoder>();
        Console.WriteLine($"Закодированное сообщение: {encoder.Encode(msg)}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
}