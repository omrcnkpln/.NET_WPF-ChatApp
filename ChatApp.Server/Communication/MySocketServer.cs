using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ChatApp.Server.Communication
{
    public class MySocketServer
    {
        const int ServerPortNum = 49570;

        public MySocketServer()
        {
            // Create a Socket
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, ServerPortNum);
            Socket welcomingSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            welcomingSocket.Bind(serverEndPoint);

            // Wait for connection
            welcomingSocket.Listen();
            Socket connectionSocket = welcomingSocket.Accept();
            if (connectionSocket.Connected)
            {
                Console.WriteLine("connected");
            }

            while (true)
            {
                try
                {
                    // Display received message
                    byte[] buffer = new byte[1024];
                    int numberOfBytesReceived = connectionSocket.Receive(buffer);
                    byte[] receivedBytes = new byte[numberOfBytesReceived];
                    Array.Copy(buffer, receivedBytes, numberOfBytesReceived);
                    string receivedMessage = Encoding.Default.GetString(receivedBytes);
                    Console.WriteLine("Server received message: " + receivedMessage);

                    // Send received message to the client
                    connectionSocket.Send(receivedBytes);
                }
                catch (Exception ex)
                {
                    break;
                    //throw ex; 
                }
            }
        }
    }
}
