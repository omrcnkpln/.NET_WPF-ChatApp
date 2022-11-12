using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Media.Media3D;

namespace ChatApp.Client.Communication
{
    public class MySocketClient
    {
        const int ServerPortNum = 49570;
        Socket? clientSocket;
        public string readata = null;

        public void Connect()
        {
            // Create a Socket
            IPEndPoint clientEndPoint = new System.Net.IPEndPoint(IPAddress.Loopback, 0);
            this.clientSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Bind(clientEndPoint);

            // Create connection
            IPEndPoint serverEndPoint = new System.Net.IPEndPoint(IPAddress.Loopback, ServerPortNum);
            clientSocket.Connect(serverEndPoint);
        }

        public void send(string message)
        {
            // Send message
            string messageToSend = message;
            byte[] bytesToSend = Encoding.Default.GetBytes(messageToSend);
            this.clientSocket.Send(bytesToSend);
        }

        public void GetMessages()
        {
            string receivedMessage;

            while (true)
            {
                //Display received message
                byte[] buffer = new byte[1024];
                int numberOfBytesReceived = clientSocket.Receive(buffer);
                byte[] receivedBytes = new byte[numberOfBytesReceived];
                Array.Copy(buffer, receivedBytes, numberOfBytesReceived);
                receivedMessage = Encoding.Default.GetString(receivedBytes);

                readata = receivedMessage;
            }
        }
    }
}
