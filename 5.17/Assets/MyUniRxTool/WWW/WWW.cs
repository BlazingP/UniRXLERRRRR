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
//　参考　ObservableWWW.cs
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
    //GetWWW　PostWWW   GetAndGetBytes   PostAndGetBytes
    public class WWW : MonoBehaviour
    {
        void Start()
        {
            var progressObservable = new ScheduledNotifier<float>();

            ObservableWWW.GetAndGetBytes("http://liangxiegame.com/media/QFramework_v0.0.9.unitypackage", progress:progressObservable) //ダウンロードの進捗状況 
                .Subscribe(byts =>
                {

                });
            progressObservable.Subscribe(progress =>
            {
                Debug.LogFormat("完成:{0}%", progress*100);　　//進捗状況監視
            });
        }
    }
}