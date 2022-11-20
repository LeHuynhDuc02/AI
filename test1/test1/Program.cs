// See https://aka.ms/new-console-template for more information

using WpfApp1;

Pair p1 = new Pair();
p1.a = 5;

Pair p2 = (Pair)p1.Clone();
p2.a = 7;

Console.WriteLine(p1.a);