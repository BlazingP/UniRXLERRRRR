//---------------------------------------------------------------
//　Subscribe 　申し込む
//　Observable　観察可能な　　
// 　Merge　　　合併する
//  register   登録
//　Login　　ログイン　
//  Focus    焦点に集まる  
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
    public class Coroutine : MonoBehaviour
    {
        //  CoroutineをObservableへ転化する
        IEnumerator CoroutineA()
        {
            yield return new WaitForSeconds(1.0f);
            Debug.Log("A");
        }
        private void Start()
        {
            Observable.FromCoroutine(_=>CoroutineA())
                      .Subscribe(_ =>
                      { 

                      });    
            //StartCoroutine(CoroutineA());        
        }
    }
}
