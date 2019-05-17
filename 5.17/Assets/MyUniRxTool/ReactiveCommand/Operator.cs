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
    public class Operator : MonoBehaviour
    {
        void Start()
        {
            var reactiveCommand = new ReactiveCommand<int>();
            reactiveCommand
                .Where(x => x % 2 == 0)
                .Subscribe(x => Debug.LogFormat("{0}は偶数",x));

            reactiveCommand
                .Where(x => x % 2 != 0)
                .Timestamp()
                .Subscribe(x => Debug.LogFormat("{0}は偶数ではない{1}", x.Value,x.Timestamp));
            
            int i = 10;

            reactiveCommand.Execute(i);

            reactiveCommand.Execute(11);
        }
    }
}
