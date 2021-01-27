using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Hw26._11._20
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 5001;
            UdpClient server = null;
            try
            {
                server = new UdpClient(port);
                
                IPEndPoint remoteEP = null;
                
                while (true)
                {
                    byte[] bytes = server.Receive(ref remoteEP);
                    server.Send(bytes, bytes.Length, remoteEP);
                    string results = Encoding.UTF8.GetString(bytes);
                    Console.WriteLine(remoteEP.ToString() + " отправил:" + results);
                    if (results.ToLower().Equals("stop server")) break;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (server != null) server.Close();
            }
        }
    }
}
