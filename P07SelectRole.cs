/// <summary>
/// SelectRole.cs
/// </summary>

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//做一个操作rolelist
public class SelectRole: MonoBehaviour
{
    //因为要去找到rolelist才可以对其进行操作，所以第一步需要先找到rolelist
    private GameObject _roleListContent;
    private Button _btnEnter;//确认按钮
    private ToggleGroup _roleListToggleGroup;

    private GameObject _modelStudio; //模型摄影棚
    private GameObject _modelPlace; //模型放置节点
    private TouchRotate _modelTouchRotate; //模型旋转节点
    private int _selectRoleIndex = -1; //刚开始是-1表示没有任何默认选项
    private int _lastRoleIndex = 2; //假装这是个服务器，记录了上一次玩家登陆的角色

    private void Awake()
    {
        //找rolelist节点
        _roleListContent = transform.Find("RoleList/Viewport/
        Content").GameObject;
        _roleListToggleGroup = _roleListContent.GetComponent<ToggleGroup>(); //因为刚刚已经取到了content，所以togglegroup可以直接在上面取
        _btnEnter = transform.Find("BtnEnter").GetComponent<Button>(); //取button上的组件
        _btnEnter.onClick.AddListenter(onBtnOkClick);
        
        //找一下旋转节点
        _modelTouchRotate = gameObject.Find<TouchRotate>("TouchRotate");

        //处理模型摄影棚部分
        //动态加载摄影棚
        _modelStudio = GameObject.Instantiate(Resources.Load<GameObject>
        ("UI/SelectRole/ModelStudio"));
        //转摄像头？
        _modelTouchRotate.DragCallBack = onTouchRotate;
        //获取ModelPlace组件
        _modelPlace = _modelStudio.Find<Transform>("ModelPlace").GameObject;

        int i = 0; //便于后面的onToggleValueChanged
        //初始化角色列表:利用for循环从userdata中获取数据
        foreach (var roleInfo in UserData.AllRole)
        {
            //获取一个资源，再通过GameObject.Instantiate把他实例化出来
            var roleItem = GameObject.Instantiate(Resources.Load<GameObject>
            ("UI/SelectRole/RoleItem"));
            //绑定一下roleItem的位置, false的意思是roleitem在世界坐标不变
            roleItem.transform.setParent(_roleListContent.transform, false);
            //接下来取roleItem上的名字和模型地址
            var textName = roleItem.transform.Find
            ("Label").GetComponent<Text>();
            var toggle = roleItem.GetComponent<Toggle>();//toggle就在这个roleitem上，所以直接取就好了

            //每一次都需要重新赋值成当前togglegroup，不然不会出现互斥效果
            toggle.group = _roleListToggleGroup;
            //遍历赋值:用闭包实现角色索引和toggle的绑定
            textName.text = roleInfo.name; //名字
            var idnex = i; 
            ++i;
            toggle.onValueChange.AddListenter(
                (isOn)=> {onToggleValueChanged(index, isOn)；});//给toggle加一个监听
            //toggle的默认选中:看看是不是和我上一次选的角色一致
            toggle.isOn = index == _lastRoleIndex;
            
        }
    }
    private void onBtnEnterClick()
    {
        ;
    }
    private void onTouchRotate(PointerEventData eventData)
    {
        _modePlace.transform.Rotate(new Vector3(0, -eventData.Delta.x, 0));
    }
    private void onToggleValueChanged(int roleIndex, bool isOn)
    {
        if(isOn)
        {
            //先记录索引
            if(_selectRoleIndex == roleIndex)
            {
                return;
            }
            //记录选择的索引，获取了选中角色的索引号
            _selectRoleIndex = roleIndex;
            
            //再清除之前留下的模型（清空ModelPlace下面所有的物体），不然模型会疯狂覆盖
            _modelPlace.DestoryAllChildren();
            //抽象出来就变成：清空一个gameobject下的所有子gameobject
            /*
            俩种做法：
            1. 找到这个gameobject。然后调用destory去销毁子物件
            for(int i = 0; i < _modelPlace.transform.childCount; ++i)
            {
                var child = _modelPlace.transform.GetChild(i);
                GameObject.Destory(child.gameObject);
            }

            2. 获取子节点所有的组件
            foreach(var child in _modePlace.transform.GetComponentsInChildren<Transform>())
            {
                 GameObject.Destory(child.gameObject);
            }
             */

            //生成新的模型
            //可以获得角色信息
            var curRoleInfo = UserData.instance.AllRole[roleIndex];
            //把加载的模型放在ModelPlace层级下（先要缓存一个ModelPlace，降低动态生成的消耗）
            var model = GameObject.Instantiate(Resources.Load<GameObject>(curRoleInfo.modelResPath));//实例化模型
            model.transform.setParent(_modelPlace.transform, false);//给模型安排到ModelPlace层级下
        }
    }
}
