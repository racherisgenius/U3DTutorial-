/// <summary>
/// UserData.cs
/// </summary>

//UserData管理用户数据
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
    public static class UserData
    {
        //给假的数据
        public static List<SelectRoleInfo> AllRole = new List<SelectRoleInfo>();//创建一个SelecrRoleInfo类型的列表用于存放角色
        //静态类的初始化,为该AllRole列表添加角色
        static UserData()
        {
            AllRole.Add(new SelectRoleInfo(){ name = "第一个角色", modelResPath 
            = "Prefabs/Role/H001_Daji_L_Skin"});
            AllRole.Add(new SelectRoleInfo(){ name = "第二个角色", modelResPath 
            = "Prefabs/Role/Hero_Shae_L"});
            AllRole.Add(new SelectRoleInfo(){ name = "第三个角色", modelResPath 
            = "Prefabs/Role/juggernaunt_body"});
        }
    } 
