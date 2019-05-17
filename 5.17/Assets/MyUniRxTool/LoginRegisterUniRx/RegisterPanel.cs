//---------------------------------------------------------------
//　
//　Subscribe 　申し込む
//　Observable　観察可能な　　
// 　Merge　　　合併する
//  register   登録
//　Login　　　ログイン　
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
    public class RegisterPanel : MonoBehaviour
    {
        Button mRegisterBtn;
        Button mBackBtn;

        InputField mUsername;
        InputField mPassword;
        InputField mPassword1;
        void Start()
        {
            mRegisterBtn = transform.Find("Register").GetComponent<Button>();
            mBackBtn = transform.Find("ReturnLogin").GetComponent<Button>();

            mUsername = transform.Find("UserName").GetComponent<InputField>();
            mPassword = transform.Find("PassWord").GetComponent<InputField>();
            mPassword1 = transform.Find("PassWord1").GetComponent<InputField>();

            mUsername.OnEndEditAsObservable()
                .Subscribe(result =>
                {
                    mPassword.Select();                    //名前の入力を完了してEnterするとパスワードへ移動
                                                         
                });
            mPassword.OnEndEditAsObservable()
                .Subscribe(result =>
                {
                    mPassword1.Select();              　    //パスワードの入力完了してEnterするとパスワードの確認へ移動。
                                                  
                });

            mPassword1.OnEndEditAsObservable()
               .Subscribe(result =>
               {
                   mRegisterBtn.onClick.Invoke();            //パスワードの確認入力完了してEnterすると登録する。
                                       
                });

            mRegisterBtn.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    Debug.Log("RegisterBtn Clicked");
                });

            mBackBtn.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    LoginRegisterUniRx.PanelMgr.LoginPanel.gameObject.SetActive(true);
                    LoginRegisterUniRx.PanelMgr.RegisterPanel.gameObject.SetActive(false);
                });
        }

    }
}