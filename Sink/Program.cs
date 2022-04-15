using System.Diagnostics;
using NetMQ;
using NetMQ.Sockets;

using var sink = new PullSocket("@tcp://localhost:5557");
sink.ReceiveFrameBytes();

var stopwatch = new Stopwatch();
stopwatch.Start();

int primeCounter = 0;
while (true)
{
    var bytes = sink.ReceiveFrameBytes();
    var n = BitConverter.ToInt32(bytes, 0);
    Console.WriteLine(n);
    primeCounter += 1;
    if (primeCounter == 9592)
        break;
}
stopwatch.Stop();
Console.WriteLine($"Total elapsed time: {stopwatch.ElapsedMilliseconds} ms");