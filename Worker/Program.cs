using NetMQ;
using NetMQ.Sockets;

using var receiver = new PullSocket(">tcp://localhost:5556");
using var sink = new PushSocket(">tcp://localhost:5557");

while (true)
{
    var bytes = receiver.ReceiveFrameBytes();
    var n = BitConverter.ToInt32(bytes, 0);
    var result = true;
    if (n < 2)
        result = false;
    else if (n == 2)
        result = true;
    else
        foreach (var m in Enumerable.Range(2, n - 2))
        {
            if (n % m == 0)
            {
                result = false;
                break;
            }
        }
    if (result)
        sink.SendFrame(bytes);
}