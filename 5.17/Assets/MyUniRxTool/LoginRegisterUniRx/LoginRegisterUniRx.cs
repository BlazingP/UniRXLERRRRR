//---------------------------------------------------------------
//　
//　Subscribe 　申し込む
//　Observable　観察可能な　　
// 　Merge　　　合併する
//  register   登録
//　Login　　ログイン　
//---------------------------------------------------------------
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

namespace UniRxLesson
{
    public class LoginRegisterUniRx : MonoBehaviour
    {
        public LoginPanel LoginPanel;                           //目标文件都可以访问到这个文件。
        public RegisterPanel RegisterPanel;
        /*☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆*/
        public static LoginRegisterUniRx PanelMgr;      //他の所でもこのクラスを引用できるように　　
        /*☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆*/
        private void Awake()
        {
            PanelMgr = this;
        }
        void Start()
        {
            LoginPanel = transform.Find("LoginPanel").GetComponent<LoginPanel>();

            LoginPanel.gameObject.SetActive(true);

            RegisterPanel = transform.Find("RegisterPanel").GetComponent<RegisterPanel>();

            RegisterPanel.gameObject.SetActive(false);

        }
    }
}
