using NetMQ;
using NetMQ.Sockets;

using var sender = new PushSocket("@tcp://localhost:5556");
using var sink = new PushSocket(">tcp://localhost:5557");
Console.WriteLine("Press ENTER when the workers are ready...");
Console.ReadKey(true);
Console.WriteLine("Sending tasks to workers...");

// The first message is "0" and signals start of batch
sink.SendFrame(new byte[] { 0x00 }, 0);
var numbers = Enumerable.Range(0, 100_000);
foreach (var n in numbers)
{
    sender.SendFrame(BitConverter.GetBytes(n));
}