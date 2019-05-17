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
    public class UniRx2 : MonoBehaviour
    {
       void Start()
        {
            var migiMouseClickEvents = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1));   
            var hidariMouseClickEvents = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0));  
            
            Observable.Merge(migiMouseClickEvents,hidariMouseClickEvents)  // Merge　事件を　合併する
                .Subscribe(_ =>
                {
                    Debug.Log("Mouse Clicked");
                });
        }

    }
}