//---------------------------------------------------------------
//　
//　Subscribe 　申し込む
//　Observable　観察可能な　　
// 　Merge　　　合併する
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
    public class ButtonLock : MonoBehaviour
    {

        void Start()
        { 
            var btnA = transform.Find("ButtonA").GetComponent<Button>();
            var btnB = transform.Find("ButtonB").GetComponent<Button>();
            var btnC = transform.Find("ButtonC").GetComponent<Button>();

            var aStream = btnA.OnClickAsObservable().Select(_ =>"A");　　//ストリームを取得 
            var bStream = btnB.OnClickAsObservable().Select(_ =>"B");　　//Select　選択
            var cStream = btnC.OnClickAsObservable().Select(_ =>"C");
            Observable.Merge(aStream, bStream, cStream)
                .First()                                  
                .Subscribe(btnId =>                                 //btnID  Select
                {
                    Debug.LogFormat("Button{0} Clicked ", btnId);
                    /*Selectを用いて様々な操作ができる。*/

                    //switch (btnId)
                    //{
                    //    case "A":
                    //        Debug.Log("Button A Clicked");
                    //        break;
                    //}

                    Observable.Timer(TimeSpan.FromSeconds(1.0f))　   //一秒後
                   .Subscribe(_ =>                 　　　　　　　　　
                   {
                        gameObject.SetActive(false);
                    });
                });
        }
    }
}