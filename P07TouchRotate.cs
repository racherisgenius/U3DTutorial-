/// <summary>
/// TouchRotate.cs
/// </summary>
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TouchRotate: MonoBehaviour, IDragHandler
{
   //脚本检测拖动事件
   public  Action<PointerEventData> DragCallBack;
    public void OnDrag(PointerEventData eventData)
    {
        //导入出一些触摸的信息
        if(DragCallBack != null)
        {
            DragCallBack(eventData);
        }
        
    }
}
