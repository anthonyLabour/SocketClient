using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace SocketClient
{
    class Program
    {

        

        static void Main(string[] args)
        {
            byte[] bytes = new byte[1024];

            try
            {
                IPHostEntry myHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress myAddress = myHost.AddressList[0];
                IPEndPoint myLocalEndPoint = new IPEndPoint(myAddress, 11000);

                Socket cliente = new Socket(myAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    cliente.Connect(myLocalEndPoint);

                    Console.WriteLine("Conectado al servidor {0}", cliente.RemoteEndPoint.ToString());

                    Console.WriteLine("Ingrese su mensaje y presione enter para enviar");

                    String message = Console.ReadLine();
                   // Console.ReadLine();

                    byte[] msg = Encoding.ASCII.GetBytes(message);

                    int bytesEnviados = cliente.Send(msg);

                    int bytesRecibidos = cliente.Receive(bytes);

                    Console.WriteLine("Servidor dice : {0}", Encoding.ASCII.GetString(bytes, 0, bytesRecibidos));

                    

                   // cliente.Close();
                
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }



            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);


            }


            Console.ReadLine();
        }
    }
}
