using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Sunucu
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ipAd = IPAddress.Parse("127.0.0.1");        

            TcpListener myList = new TcpListener(ipAd, 8001);
            myList.Start();

            Console.WriteLine("Sunucu 8001 numaralı portta çalışıyor...");
            Console.WriteLine("Tam sunucu adresi  :" +myList.LocalEndpoint);
            Console.WriteLine("Bağlantı için bekleniyor.....");

            Socket s = myList.AcceptSocket();
            Console.WriteLine("Bağlantı kabul edildi " + s.RemoteEndPoint);

            byte[] b = new byte[100];
            int k = s.Receive(b);
            Console.WriteLine("Alındı...");
            for (int i = 0; i < k; i++)
            {
                Console.Write(Convert.ToChar(b[i]));
            }

            ASCIIEncoding asen = new ASCIIEncoding();
            s.Send(asen.GetBytes("Mesaj sunucu tarafından alındı."));
            Console.WriteLine("\nGönderim başarılı");
            
            s.Close();
            myList.Stop();
        }
    }
}
