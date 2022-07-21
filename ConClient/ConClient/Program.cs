using Lins;
using LitJson;
using System;
using WebSocketSharp;

namespace ConClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebSocket ws = new WebSocket("ws://localhost:8888/UserService"))
            {
                ws.OnMessage += Ws_OnMessage;

                ws.Connect();
                var nm = new NetMsg();
                nm.req = new RegMsg();
                nm.req.userReg = new UserRegReq();
                nm.req.userReg.name = Console.ReadLine();
                nm.req.userReg.pwd = Console.ReadLine();

                string s = JsonMapper.ToJson(nm);

                ws.Send(s);

                Console.ReadLine();//等待服务器返回一个响应
            } 

            Console.WriteLine("Hello World!");
        }

        private static void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine($"RESP: {e.Data}");
        }
    }
}
