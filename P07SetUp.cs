/// <summary>
/// SetUp.cs
/// </summary>
using UnityEngine;
using System.Collections;

public class SetUp: MonoBehaviour
{
    private void Awake()
    {
        //闪屏，更新，最后到登录
        //但是这里直接做登录，相当于游戏主逻辑开始进行（闪屏更新不属于游戏主逻辑）
        GameMgr.instance.Init();//游戏逻辑从启动导入到GameMgr

    }
}
