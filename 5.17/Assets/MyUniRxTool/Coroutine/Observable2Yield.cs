//---------------------------------------------------------------
//　Subscribe 　申し込む
//　Observable　観察可能な　　
// 　Merge　　　合併する
//  register   登録
//　Login　　ログイン　
//  Focus    焦点に集まる  
//  Instructio   指令　　
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
    public class Observable2Yield : MonoBehaviour
    {
        //  ObservableをCoroutineへ転換する
        IEnumerator Delay1Second()
        {
            yield return Observable.Timer(TimeSpan.FromSeconds(1.0f)).ToYieldInstruction();
            Debug.Log("Delay 1 second");
        }
        void Start()
        {
            StartCoroutine(Delay1Second());
        }
    }
}