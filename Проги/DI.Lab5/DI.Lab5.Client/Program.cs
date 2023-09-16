using Autofac;
using DI.Lab5.Base;
using DI.Lab5.Realization.Encoders;

var builder = new ContainerBuilder();

builder.RegisterInstance(new SubstitutionEncoder(4, GetSubstitution()))
    .As<IPermutationEncoder>();

var container = builder.Build();

using(var scope = container.BeginLifetimeScope())
{
    var msg = "Hello World";
    Console.WriteLine("Message: " + msg);
    var encoder = container.Resolve<IPermutationEncoder>();
    Console.WriteLine($"Encoded {encoder.Encode(msg)}");
}

int[] GetSubstitution() => new int[] { 4, 3, 2, 1 };
