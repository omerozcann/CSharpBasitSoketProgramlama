using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Istemci
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpclnt = new TcpClient();            
            tcpclnt.Connect("127.0.0.1", 8001);
            Console.WriteLine("Bağlanıyor.....");

            Console.WriteLine("Bağlandı");

            Console.Write("Gönderilecek mesajı giriniz: ");
            String str = Console.ReadLine();
            Stream stm = tcpclnt.GetStream();

            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            Console.WriteLine("Gönderiliyor.....");

            stm.Write(ba, 0, ba.Length);

            byte[] bb = new byte[100];
            int k = stm.Read(bb, 0, 100);

            for (int i = 0; i < k; i++)
                Console.Write(Convert.ToChar(bb[i]));

            tcpclnt.Close();
        }
    }
}
