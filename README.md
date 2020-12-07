# Unity3D 商业化的网络游戏架构笔记
>再次感谢大佬的视频！

感谢b站大佬提供的U3D视频教学，本笔记里做了思维导图，笔记整理和代码注释，希望对各位有帮助！一起努力变成优秀的游戏主程！奥利给！

b站地址：https://www.bilibili.com/video/BV1C7411i7Rg?p=6


## 目录
    * P5-登录界面UI制作
        * [链接](#P5 Login代码)
        * [链接](#P5 UI制作思维导图)

        * P5. 登录界面UI制作
        1. 建立场景Login
            放入文件夹Scenes，为了规范保存。

        2. 设置InputField(inputAccount, inputPassword) 和 登录确认 (BtnLogin)
            调整分辨率在Canvas - Canvas Scaler - Scale With Screen Size (1920 * 1080)
            创建空物体包装以上三个物体，命名为【Login】
            创建一个UI预制体文件夹，并把Login拖入UI中变成预制体

        3. 创建Scripts文件夹，用于存放代码
            创建UI文件夹-Setup文件夹， 用于存放登录时候的代码
            *此处Setup表示的就是游戏框架：UI下的登录步骤*
            *Scripts - UI - Setup*

        4. 创建Login脚本
            挂在Login预制体上，并apply修改
            并在unity引擎中保存项目

        5. 创建背景
            Login下面添加Image组件，调色并命名为bg
            点击Apply到Login预制体，并保存项目

        6. 建立数据
            创建一个类【UserData】，并在其中建立SelectRoleInfo类用于存储用户数据：1. 角色名称 2. 模型资源路径

        7. 创建新场景-SelectRole并对其做一个选人界面的UI
            在Login场景中，将EventSystem和Canvas放入空物体并命名为UISystem
            把UISystem放入Assets-UI文件夹中，变成预制体，坐标rest成0
            把Login拉入UISystem-Canvas下，坐标reset成0

        8. 制作SelectRole场景
            将UISystem预制体拖拽到SelectRole的Hierarchy中
            创建一个空物体，命名【SelectRole】
            再SelectRole中创建ScrollView组件改名为【RoleList】，用来显示角色列表，删除横向和纵向的Scrollbra
            在Canvas下继续创建一个Btn组件【BtnEnter】和创建背景图【bg】
            最后把bg, RoleList和BtnEnter拉到SelectRole中。再将SelectRole拉到Assets-UI文件下变成预制体
        9. 调整RoleList下ViewPort-Content大小
            拉到和viewport一样高
            在RoleList- ViewPort- Content 下创建Toggle组件，删除Background中的checkMark
            给Content添加Toggle Group脚本
            将Toggle改名为【RoleItem】并拉到Assets-UI下变成预制体
            【整理一下UI文件夹下的子文件夹】
            【SelectRole】：RoleItem，SelectRole
            【Login】：Login
            因为后期需要动态生成角色，所以场景中不需要添加RoleItem，可以直接将RoleItem删除
