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

        int i = 0; //便于后面的onToggleValueChanged
        //初始化角色列表:利用for循环从userdata中获取数据
        foreach (var roleInfo in UserData.instance.AllRole)
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

    private void onToggleValueChanged(int roleIndex, bool isOn)
    {
        if(isOn)
        {
            _selectRoleIndex = roleIndex;
        }
    }
}
