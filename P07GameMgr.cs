/// <summary>
/// GameMgr.cs
/// </summary>
using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
//GameMgr是全局唯一的，所以需要继承一个单例
public class GameMgr : Singleton<GameMgr>
{
    /// <summary>
    /// 初始化函数，在SetUp中去调用
    /// </summary>
    public void Init()
    {
        //启动游戏引擎
        //跳转第一个逻辑界面
        Application.LoadLevel("Login");

    }
}
