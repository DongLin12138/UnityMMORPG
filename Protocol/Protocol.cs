using System;
using System.Collections.Generic;
using System.Text;

namespace Lins
{
    public class User
    {
        public string id;
        public string name;
        public string pwd;
    }

    public class UserRegReq
    {
        public string name;
        public string pwd;
    }

    public class UserRegResp
    {
        public bool ok;//是否注册成功
        public User user;
    }

    /// <summary>
    /// 网络请求
    /// </summary>
    public class RegMsg
    {
        public UserRegReq userReg;
    }

    /// <summary>
    /// 网络响应
    /// </summary>
    public class RespMsg
    {
        public UserRegResp userReg;
    }

    public class NetMsg
    {
        public RegMsg req;
        public RespMsg resp;
    }
}
