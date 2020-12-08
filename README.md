# Unity3D 商业化的网络游戏架构笔记
>再次感谢大佬的视频！

感谢b站大佬提供的U3D视频教学，本笔记里做了思维导图，笔记整理和代码注释，希望对各位有帮助！一起努力变成优秀的游戏主程！奥利给！

b站地址：https://www.bilibili.com/video/BV1C7411i7Rg?p=6


## 目录
### P5-登录界面UI制作
   * [P5 Login代码](https://github.com/racherisgenius/U3DTutorial-/blob/main/P5Login.cs)
   * [P5 UserData代码](https://github.com/racherisgenius/U3DTutorial-/blob/main/P05UserData.cs)
   
   * P5. 登录界面UI制作笔记
   ```
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
  ```
  ### P6-选人界面制作 + 单例模式 + 扩展类的成员函数
   * [P6 SelectRole代码](https://github.com/racherisgenius/U3DTutorial-/blob/main/P06SelectRole.cs)
   * [P6 Singleton代码](https://github.com/racherisgenius/U3DTutorial-/blob/main/P06Singleton.cs)
   * [P6 UserData代码](https://github.com/racherisgenius/U3DTutorial-/blob/main/P06UserData.cs)
   * [P6 UnityExtern代码](https://github.com/racherisgenius/U3DTutorial-/blob/main/P06UnityEntern.cs)
   
   * P6. 选人界面制作 + 单例模式 + 扩展类的成员函数
  ```
1. 创建SelectRole脚本
    挂在UISystem下的SelectRole下
2. SelecrRole脚本
    找到rolelist节点
    通过加载resources目录下的组件，遍历userdata的list动态生成角色
        把UI文件夹放入resources文件夹下
3. 为角色排版
    在Content内添加Grid Layout Group，修改cell size  198 * 68， spacing 6.7
4. 单例模式
    建立Common文件夹，添加一个单例脚本
5. 扩展类的成员函数
    建立Extern文件夹，添加一个扩展类脚本
```
   ### P7- 游戏启动流程SetUp
   * [P7 GameMgr代码](https://github.com/racherisgenius/U3DTutorial-/blob/main/P07GameMgr.cs)
   * [P7 TouchRotate代码](https://github.com/racherisgenius/U3DTutorial-/blob/main/P07TouchRotate.cs)
   * [P7 UserData代码](https://github.com/racherisgenius/U3DTutorial-/blob/main/P07UserData.cs)
   * [P7 UnityExtern代码](https://github.com/racherisgenius/U3DTutorial-/blob/main/P07TouchRotate.cs)
   * [P7 SetUp代码](https://github.com/racherisgenius/U3DTutorial-/blob/main/P07SetUp.cs)
   * [P7 SelectRole代码](https://github.com/racherisgenius/U3DTutorial-/blob/main/P07SelectRole.cs)
   * P7. 游戏启动流程SetUp
   ```
   //*游戏启动前：启动，闪屏（logo)， 检查更新， 更新（重启），公告，登录 ，
//所以p7中制作的是setup界面：闪屏（logo)， 检查更新， 更新（重启），公告
1. 创建SetUp Scene
    删除Hierarchy中所有的东西
    创建一个空物体，命名为【SetUp】
2. 创建新脚本SetUp.cs
    把SetUp脚本挂上SetUp物件上
    让游戏启动流程的逻辑通过一个脚本挂在一个物件上完成
3. 创建一个Logic模块-放游戏主逻辑
    为Logic模块添加新的类GameMgr.cs
4. 打开SelectRole场景
    【老师思路：把模型塞到一个场景里在找个模型照，然后让SelectRole中的摄像机和模型场景中的摄像机叠加】
    先把背景删除
    创建一个空物件，命名【ModelStudio】，用来放置模型
    在模型里面，创建一个摄像机，用来照射模型
    复制Prefab中模型路径，更新UserData的代码
    调整摄像机和模型的照射关系，创建一个空物件，命名【ModelPlace】
5. 将模型拖入ModelPlace层级下（Rotation-y轴180度可以改变模型的正反面）
    在ModelStudio下创建一个sprite和一个Directional Light（放在ModelStudio外部）
    调整sprite大小，命名【bg】并放在ModelPlace-Camera层级下
    删除ModelPlace，因为后期会动态加载出
    把ModelStudio拖入Resources-UI-SelectRole，变成一个预设体
    删除ModelStudio，后期动态加载
6. 更新 SelectRole代码
    创建 处理模型摄影部分
    创建 扩展函数
7. 给模型加个旋转
    在SelectRole下创建一个Image组件，来检测滑动，命名【TouchRotate】
    创建一个TouchRotate脚本挂给TouchRotate物件
   
   ```
