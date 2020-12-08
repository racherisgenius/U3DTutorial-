/// <summary>
/// 泛型单例模式
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 单例，用instance获取
/// 继承的时候可以用
/// 单例的核心就是用instance,但是instance前面的类型都无所谓
/// 单例不能用static?
/// 用了泛型单例后，构造函数就不能是private的，因为new后父类就找不到了
/// 泛型是对类型的抽象
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> where T : new()
{
    static T _instance;
    static Singleton()
    {
        _instance = new T();
    }
    public static T instance
    {
        get
        {
            return _instance;
        }
    }
}
