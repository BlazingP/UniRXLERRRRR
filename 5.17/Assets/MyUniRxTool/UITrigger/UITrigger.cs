//---------------------------------------------------------------
//　
//　Subscribe 　申し込む
//　Observable　観察可能な　　
// 　Merge　　　合併する
//  register   登録
//　Login　　ログイン　
//  Focus    焦点に集まる  
// APIに関して　もっと詳しくは　　ObservableTriggerExtensions.cs     ObservableTriggerExtensions.Component.cs 
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
    public class UITrigger : MonoBehaviour
    {
        Image mImage;
        Text mtext;
        void Start()
        {
            mImage = transform.Find("Image").GetComponent<Image>();
            mtext = transform.Find("Text").GetComponent<Text>();

            mImage.OnBeginDragAsObservable()
                .Subscribe(_ =>
                {
                    Debug.Log("begin drag");
                    mtext.text = "begin drag";
                });

            mImage.OnEndDragAsObservable()
                .Subscribe(_ =>
                {
                    Debug.Log("end drag");
                    mtext.text = "end drag";
                });

            
            mImage.OnDragAsObservable()
                .Subscribe(_ =>
                {
                    Debug.Log("dragging");
                    mtext.text = "dragging";
                });

            mImage.OnPointerClickAsObservable()
                .Subscribe(_ =>
                {
                    Debug.Log("on pointer click");
                    mtext.text = "on pointer click";
                });
        }
    }
}
