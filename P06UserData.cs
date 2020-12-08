//修改一下之前的UserData.cs代码
  using System;
    using System.Collections;
    using System.Linq;
    using System.Text;
    
    /// <summary>
    /// 选人界面角色结构
    /// </summary>
    public class SelectRoleInfo
    {
        public string name; //角色名
        public int modelResPath; //模型资源路径
    }
    //静态类
    public class UserData : Singleton<UserData> //这里就会继承userdata的单例
    {
        //给假的数据
        public List<SelectRoleInfo> AllRole = new List<SelectRoleInfo>();//创建一个SelecrRoleInfo类型的列表用于存放角色
        //静态类的初始化,为该AllRole列表添加角色
        public UserData()
        {
            AllRole.Add(new SelectRoleInfo(){ name = "第一个角色", modelResPath 
            = ""});
            AllRole.Add(new SelectRoleInfo(){ name = "第二个角色", modelResPath 
            = ""});
            AllRole.Add(new S electRoleInfo(){ name = "第三个角色", modelResPath 
            = ""});
        }
    } 
