/// <summary>
/// 角色表
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;

//角色表内数据结构
public class RoleDatabase
{
    public int ID;
    public string Name;
    public string ModelPath;
}

//因为RoleTable就一份，所以继承singleton
public class RoleTable : Singleton<RoleTable>
{
    //这里的int表示控制角色的index，不是角色id
    Dictionary<int, RoleDatabase> _cache = new Dictionary<int,
    RoleDatabase>();

    public RoleTable()
    {
        //读表(二进制)
        var table = Resources.Load<TextAsset>("Config/RoleTable.csv.bytes");
        //创建一个内存流,利用刚刚读到的表做内存流的数据源
        //用二进制方法读表
        var tableStream = new MemoryStream(table.bytes);
        //根据内存流创建一个内存流的读取器
        using(var reader = new StreamReader(tableStream, Encoding.GetEncoding
        ("gb2312")))
        {
            //会自动关闭内存流
            reader.ReadLine();//跳过第一行
            
            //下面是正式数据-循环读
            var lineStr = reader.ReadLine();
            while(lineStr != null)
            {
                //读到内存里,因为csv文件用逗号隔开，所以我们用逗号分隔数据
                var itemStrArray = lineStr.Split(',');
                var roleDB = new RoleDatabase(); //目的是把itemStrArray的东西塞进roleDB
                roleDB.ID = int.Parse(itemStrArray[0]);//把Array中的第一个元素压进roleDB
                roleDB.Name = itemStrArray[1];
                roleDB.ModelPath = itemStrArray[2];
//?
                _cache[roleDB.ID] = roleDB //key = roleDB
              
                //循环
                lineStr = reader.ReadLine()
            }

        }

    }
