using System;
using WebSocketSharp.Server;
using WebSocketSharp;
using Lins;
using LitJson;

namespace MmoServer
{
    class Program
    {
        public class UserService : WebSocketBehavior
        {
            //TODO：提供服务
            protected override void OnMessage(MessageEventArgs e)
            {
                Console.WriteLine(e.Data);

                NetMsg nm = JsonMapper.ToObject<NetMsg>(e.Data);

                //TODO：验证用户注册信息是否合法，合法就通过验证

                //并给客户端发送用户注册结果
                NetMsg nm2 = new NetMsg();
                nm2.resp = new RespMsg();
                nm2.resp.userReg = new UserRegResp();
                nm2.resp.userReg.ok = true;
                nm2.resp.userReg.user = new User()
                {
                    id = Guid.NewGuid().ToString(),
                    name = nm.req.userReg.name,
                    pwd = nm.req.userReg.pwd,
                };

                string s = JsonMapper.ToJson(nm2);

                this.Send(s);
            }
        }

        static void Main(string[] args)
        {
            
            WebSocketServer svr = new WebSocketServer("ws://localhost:8888");

            svr.AddWebSocketService<UserService>("/UserService");

            svr.Start();//开启服务器

            Console.WriteLine("Server started...");

            Console.ReadLine();

            svr.Stop();

            Console.WriteLine("Server stop...");
        }
    }
}
