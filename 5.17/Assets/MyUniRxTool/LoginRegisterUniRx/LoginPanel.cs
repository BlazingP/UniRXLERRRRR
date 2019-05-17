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
    public class LoginPanel : MonoBehaviour
    {
        Button mLoginBtn;
        Button mRegister;
        InputField mUsername;
        InputField mPassword;
        void Start()
        {
          
            mLoginBtn = transform.Find("Login").GetComponent<Button>();
            mRegister = transform.Find("Register").GetComponent<Button>();
            mUsername = transform.Find("UserName").GetComponent<InputField>();
            mPassword = transform.Find("PassWord").GetComponent<InputField>();

            mLoginBtn.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    Debug.Log("Login btn clicked");
                });

            mUsername.OnEndEditAsObservable()
                .Subscribe(result =>
                {
                    mPassword.Select();                    //名前の入力を完了してEnterするとパスワードへ移動
//                    Debug.Log("Username:" + result);       //戻り値         result
                });
            mPassword.OnEndEditAsObservable()
                .Subscribe(result =>
                {
                    mLoginBtn.onClick.Invoke();             //パスワードの入力完了してEnterするとログインする。
//                   Debug.Log("Password:" + result);
                });
            mRegister.OnClickAsObservable()　　　　　　　　　
                .Subscribe(_ =>
                {
                    LoginRegisterUniRx.PanelMgr.LoginPanel.gameObject.SetActive(false);
                    LoginRegisterUniRx.PanelMgr.RegisterPanel.gameObject.SetActive(true);
                }); 
        }

    }
}