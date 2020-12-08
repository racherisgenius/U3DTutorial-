/// <summary>
/// UnityExtern.cs
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

    /// <summary>
    /// 删除所有的子节点
    /// </summary>
    /// <param name="parent"></param>
    public static void DestoryAllChildren(this GameObject parent)
    {
        for(int i = 0; i < _modelPlace.transform.childCount; ++i)
            {
                var child = _modelPlace.transform.GetChild(i);
                GameObject.Destory(child.gameObject);
            }
    }
}
