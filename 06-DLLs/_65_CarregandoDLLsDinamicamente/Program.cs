
using System.Reflection;

Assembly minhaDll = Assembly.LoadFile(@"C:\Alexandre\C#\AulasCSharp2\06-DLLs\_63_CriandoDLL\bin\Debug\net8.0\_63_CriandoDLL.dll");
Type classeMatematica = minhaDll.GetType("_63_CriandoDLL.Matematica");

if (classeMatematica == null) throw new Exception("Classe matematica nao existe.");

dynamic instanciaMatematica = Activator.CreateInstance(classeMatematica);
var methodSoma = classeMatematica.GetMethod("Soma");
double resultado = (double)methodSoma.Invoke(instanciaMatematica, new object[] { 10, 20 });

Console.WriteLine(resultado);


