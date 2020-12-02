
    //登录界面
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using UnityEvent;
    using UnityEngine.SceneManager;
    public class Login: MonoBehaviour
    {

        private InputField _inputAccount; //使用UnityEngine.UI，创建一个接收account的变量
        private InputField _inputPassword;//创建一个接收password的变量
        private Button _btnOk; //使用UnityEngine.UI，创建一个确认按钮

        void Awake()
        {
            //先声明变量

            //transform.Find: 找到某一个子节点然后在该子节点上获取某些东西
            _inputAccount = transform.Find
            ("inputAccount").GetComponent<InputField>();//在inputAccount中获取InputField组件
            _inputPassword = transform.Find
            ("inputPassword").GetComponent<InputField>();//在inputPassword中获取InputField组件
            _btnOk = transform.Find("BtnLogin").GetComponent<Button>(); //在BtnLogin上获取Button组件

            //给button绑定事件

            _btnOK.onClick.AddListenter(onBtnOkClick);//给btn绑定onBtnOkClick事件
        }

        private void onBtnOkClick()
        {
            //链接服务器,等待返回数据
            //暂时用假数据直接进入界面
            
            //利用切换场景的方式做
            //遇到过时函数就恩F12
            SceneManager.LoadScene("SelectRole");

        }
        
    }
