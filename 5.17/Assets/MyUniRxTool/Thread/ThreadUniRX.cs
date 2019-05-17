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
    public class ThreadUniRX : MonoBehaviour
    {

        void Start()
        {
           var threadAStream= Observable.Start(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));     //使うにはusing System.Threading;が必要となります。
                return 10;
            });

            var threadBStream = Observable.Start(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(3));
                return 10;
            });

            Observable.WhenAll(threadAStream, threadBStream)              //スレッドとコルーチンでWhenALLが使える
                .ObserveOnMainThread()
                .Subscribe(results =>
                {
                    Debug.LogFormat("{0}:{1} {2}", results[0], results[1],results[0]+ results[1]);
                });
        }

        void Update()
        {

        }
    }
}
