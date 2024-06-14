using MyCSVSerializer;
using Test;
using System.Diagnostics;
using Newtonsoft.Json;


var test = new TestClass
{
    x1 = 1,
    x2 = "Hellow my serializer",
    x3 = 1.1,
    x4 = DateTime.Now,
    x5 = false
};

var iterations = 100000;

Console.WriteLine("\tЗамеры кастомного csv-сериализатора\n\n");
string resultSerialize = "";
TestClass resultDeserialize = new TestClass();

var stopWatch = new Stopwatch();
stopWatch.Start();

for (int i=0; i< iterations; i++)
{
    using (var stream = new FileStream("test.csv", FileMode.Create, FileAccess.Write))
    {
        var cs = new MyCsvSerializer<TestClass>();

        resultSerialize = cs.Serialize(stream, test);
    }
}

stopWatch.Stop();
Console.WriteLine("Значение строки сериализации:\n" + resultSerialize);
Console.WriteLine("\nВремя выполнения (мс)- " + stopWatch.ElapsedMilliseconds);

stopWatch.Restart();
for (int i=0; i< iterations; i++)
{
    using (var stream = new FileStream("test.csv", FileMode.Open, FileAccess.Read))
    {
        var cs = new MyCsvSerializer<TestClass>();
        resultDeserialize = cs.Deserialize(stream).FirstOrDefault();
    }
}
stopWatch.Stop();

Console.WriteLine("Значение строки десериализации:\n" + resultDeserialize.ToString());
Console.WriteLine("\nВремя выполнения (мс)- " + stopWatch.ElapsedMilliseconds);

Console.WriteLine("\n\nЗамеры JSON-сериализатора Newtonsoft\n\n");

stopWatch.Restart();
var serializer = new JsonSerializer();
for (int i=0; i< iterations; i++)
{

    using (var sw = new StreamWriter("test.json"))
        using(var writer = new JsonTextWriter(sw))
    {
        serializer.Serialize(writer, test);
        resultSerialize = writer.ToString();
    }
}
stopWatch.Stop();
Console.WriteLine("Значение строки сериализации:\n" + resultSerialize);
Console.WriteLine("\nВремя выполнения (мс)- " + stopWatch.ElapsedMilliseconds);

stopWatch.Restart();

for (int i=0; i< iterations; i++)
{
    using (var sr = new StreamReader("test.json"))
        using (var read = new JsonTextReader(sr))
    {
        resultDeserialize = serializer.Deserialize<TestClass>(read);
    }
}
stopWatch.Start();
Console.WriteLine("Значение строки десериализации:\n" + resultDeserialize.ToString());
Console.WriteLine("\nВремя выполнения (мс)- " + stopWatch.ElapsedMilliseconds);
