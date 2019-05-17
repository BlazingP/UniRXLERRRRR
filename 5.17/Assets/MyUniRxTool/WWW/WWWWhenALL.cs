//---------------------------------------------------------------
//　Subscribe 　申し込む
//　Observable　観察可能な　　
// 　Merge　　　合併する
//  register    登録
//　Login　　   ログイン　
//  Focus       焦点に集まる  
//  Instructio  指令　　
//  Coroutine   コルーチン
//  Thread 　　 糸　　スレッド
//  results　   結果
//---------------------------------------------------------------
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using System.Threading;
namespace UniRxLesson
{
    public class WWWWhenALL : MonoBehaviour
    {
        void Start()
        {
            var googleStream = ObservableWWW.Get("https://www.google.co.jp");　
            var amazonStram = ObservableWWW.Get("https://www.amazon.co.jp");

            Observable.WhenAll(googleStream, amazonStram)  //WhenALL に通用
                .Subscribe(responseText =>
                {
                    
                    Debug.Log(responseText[0].Substring(0, 100)); 　
                    Debug.Log(responseText[1].Substring(0, 100));  //substringは文字列の一部を取得するためのメソッド
                });
        }
    }
}
