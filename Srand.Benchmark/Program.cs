using Srand.Test;
using System.Diagnostics;

var r = new System.Random(5);
Console.WriteLine("Random: " + r.Next().ToString());

Console.WriteLine("TEST 1: generate a random image with System.Random and with Srand to see if they both look equally 'random':\n");
{
    Console.WriteLine("Generate random image using System.Random..");
    var gen = new ImageGenerator();
    gen.Create("system.random.png", () =>
    {
        byte[] ret = new byte[3];
        Random.Shared.NextBytes(ret);
        return ret;
    });
    Console.WriteLine("Done! Image at output folder with name 'system.random.png'.\n");
}
{
    Console.WriteLine("Generate random image using Srand..");
    var gen = new ImageGenerator();
    var srand = new Srand.SeededRandom(Random.Shared.Next());
    gen.Create("srand.png", () =>
    {
        byte[] ret = new byte[3];
        srand.NextBytes(ret);
        return ret;
    });
    Console.WriteLine("Done! Image at output folder with name 'srand.png'.\n");
}

Console.WriteLine("Both images are in output folder. Check them out later to see if they both appear random enough.");


Console.WriteLine("\n\nTEST 2: performance benchmark. We'll run Next(), NextDouble(), and NextSingle() multiple times to see performance differences:\n");
{
    Console.WriteLine("Testing System.Random..");
    var rand = new Random();
    var runTimes = 10000000;
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (var i = 0; i < runTimes; ++i)
        {
            var a = rand.Next();
        }
        stopwatch.Stop();
        Console.WriteLine($"Time to execute {runTimes} times 'Next()' without params:    {stopwatch.Elapsed}");
    }
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (var i = 0; i < runTimes; ++i)
        {
            var a = rand.Next(1, 1000);
        }
        stopwatch.Stop();
        Console.WriteLine($"Time to execute {runTimes} times 'Next()' with min-max:      {stopwatch.Elapsed}");
    }
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (var i = 0; i < runTimes; ++i)
        {
            var a = rand.NextDouble();
        }
        stopwatch.Stop();
        Console.WriteLine($"Time to execute {runTimes} times 'NextDouble()':             {stopwatch.Elapsed}");
    }
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (var i = 0; i < runTimes; ++i)
        {
            var a = rand.NextSingle();
        }
        stopwatch.Stop();
        Console.WriteLine($"Time to execute {runTimes} times 'NextSingle()':             {stopwatch.Elapsed}");
    }
}
{
    Console.WriteLine("\nTesting SRand..");
    var rand = new Srand.SeededRandom(Random.Shared.Next());
    var runTimes = 10000000;
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (var i = 0; i < runTimes; ++i)
        {
            var a = rand.Next();
        }
        stopwatch.Stop();
        Console.WriteLine($"Time to execute {runTimes} times 'Next()' without params:    {stopwatch.Elapsed}");
    }
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (var i = 0; i < runTimes; ++i)
        {
            var a = rand.Next(1, 1000);
        }
        stopwatch.Stop();
        Console.WriteLine($"Time to execute {runTimes} times 'Next()' with min-max:      {stopwatch.Elapsed}");
    }
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (var i = 0; i < runTimes; ++i)
        {
            var a = rand.NextDouble();
        }
        stopwatch.Stop();
        Console.WriteLine($"Time to execute {runTimes} times 'NextDouble()':             {stopwatch.Elapsed}");
    }
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (var i = 0; i < runTimes; ++i)
        {
            var a = rand.NextSingle();
        }
        stopwatch.Stop();
        Console.WriteLine($"Time to execute {runTimes} times 'NextSingle()':             {stopwatch.Elapsed}");
    }
}