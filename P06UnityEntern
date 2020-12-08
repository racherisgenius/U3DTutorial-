//扩展类的成员函数
/// <summary>
/// 1. 静态类
/// 2.扩展函数也是静态的
/// 3. 之后直接替换需要变化的函数就好
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class UnityExtern
{
    /// <summary>
    /// 对gameobject这个类做了一个扩展了一个函数叫Find，并且接收path变量，返回一个T泛型
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Find<T>(this.GameObject parent, string path)
    {
        return parent.transform.Find(path).GetComponent<T>();
    }
}
