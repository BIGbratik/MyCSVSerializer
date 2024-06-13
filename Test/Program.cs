using MyCSVSerializer;
using Test;
using System;

Console.WriteLine("Hello, World!");

var test = new TestClass
{
    x1 = 1,
    x2 = "Hellow my serializer",
    x3 = 1.1,
    x4 = DateTime.Now,
    x5 = false
};

using (var stream = new FileStream("test.csv", FileMode.Create, FileAccess.Write))
{
    var cs = new MyCsvSerializer<TestClass>();

    cs.Serialize(stream, test);
}

var data = new List<TestClass>();
using (var stream = new FileStream("test.csv", FileMode.Open, FileAccess.Read))
{
    var cs = new MyCsvSerializer<TestClass>();
    data = cs.Deserialize(stream).ToList();
}

Console.WriteLine(data.FirstOrDefault().ToString());
