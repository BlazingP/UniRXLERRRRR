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
    public class CorotineSpawn : MonoBehaviour
    {
        IEnumerator A()
        {
            yield return new WaitForSeconds(1.0f);
            Debug.Log("A");
        }

        IEnumerator B()
        {
            yield return new WaitForSeconds(2.0f);
            Debug.Log("B");
        }
        void Start()
        {
            var aStream = Observable.FromCoroutine(_ => A());
            var bStream = Observable.FromCoroutine(_ => B());                 

            Observable.WhenAll(aStream, bStream)            // IEnumerator A and B　（　全てのイベント）を実行したら　実行する
                .Subscribe(_ =>
                {
                    Debug.Log("when all");
                });

        }
    }
}
