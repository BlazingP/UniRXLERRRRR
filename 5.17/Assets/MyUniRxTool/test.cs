//---------------------------------------------------------------
//shueiyu　　メモ帳
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
    public class test : MonoBehaviour
    {
        public ReactiveProperty<int> Age = new ReactiveProperty<int>(0);

        //public IntReactiveProperty Age = new IntReactiveProperty(0);  //このような方法もあります、


        void Start()
        {
            Observable.Timer(TimeSpan.FromSeconds(5.0f))                    //任務を配る
                  .Subscribe(_ =>　　　　　　　　　　　　　　　　　　　　　//任務を受ける　 観察者
                  {
                      Debug.Log("do Sometihing");
                  });


            Observable.EveryUpdate()
                .Where(_ => Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1))
                .First()                                                 //はじめてのクリックだけ
                .Subscribe(_ => Debug.Log("MouseClicked"))                   
                .AddTo(this);                                            //死んだら止める

            //{
            //    Debug.Log("mouseDown");      　　　　　　　　   　　  //同じの効果
            //});


            //---------------------------------------------------------------------------------------
            // UI
            //---------------------------------------------------------------------------------------
            var button = transform.Find("Button").GetComponent<Button>();  // UIを使うにはusing UnityEngine.UI;が必要になる。

            button.OnClickAsObservable()  
                .Subscribe(_ => Debug.Log("Button Clicked"));

           // button.interactable = false;   //Buttonをクリックできないに設定する

            var toggle = transform.Find("Toggle").GetComponent<Toggle>();

            toggle.OnValueChangedAsObservable()
              /*  .Where(on=>on)     */                                      // onの場合だけ.Subscribe
                .Subscribe(on => Debug.Log(on));                         //Toggle =ture  or false の観察

            var image = transform.Find("Image").GetComponent<Image>();

            image.OnBeginDragAsObservable().Subscribe(_ => Debug.Log("began drag"));   //
            image.OnDragAsObservable().Subscribe(_ => Debug.Log("draggiing"));
            image.OnEndDragAsObservable().Subscribe(_ => Debug.Log("end drag"));

            //---------------------------------------------------------------------------------------
            // ReactiveProperty
            //---------------------------------------------------------------------------------------

            Age.Subscribe(Age =>                                                    //値の変化を監視する、
            {
                Debug.Log("inner received age change");
            });
            Age.Value = 10;


        }
    }


    public class PersonView              // EX　 他のところでも取得できます。
    {
        test mtest;
        void Init()
        {
            mtest.Age.Subscribe((age) =>
            {
                Debug.Log(age);
            });
        }
    }
}
