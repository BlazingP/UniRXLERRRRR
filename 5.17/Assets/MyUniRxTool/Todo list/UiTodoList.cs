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
//  Collection 回収　　集めること
//  resource   資源　
//  request   要請する ようせい　要求する
//  progress  	進歩、発達、発展、前進、進行、成り行き、経過
//---------------------------------------------------------------
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;
using System.Linq;
namespace UniRxLesson
{
    public class UiTodoList : MonoBehaviour
    {
        UiTodoItem mTodoItemPrototype;
        InputField mInputContent;
        TodoList Model;
        Button mBtnAdd;
        [SerializeField] Transform Content;
 
        private void Awake()
        {
            mTodoItemPrototype = transform.Find("TodoItemPrototype").GetComponent<UiTodoItem>();

            mInputContent = transform.Find("InputContent").GetComponent<InputField>();

            mBtnAdd = transform.Find("BtnAdd").GetComponent<Button>();


        }
        private void Start()
        {
            Model = TodoList.Load();

            mInputContent.OnValueChangedAsObservable()
                .Select(inputContent => !string.IsNullOrEmpty(inputContent))   //不为空就为真

                .SubscribeToInteractable(mBtnAdd);    //mBtnAddと連携

            mBtnAdd.OnClickAsObservable()
                .Subscribe(_ =>
                {
                Model.TodoItems.Add(new TodoItem()
                {
                    Id = 3,
                    Content = new StringReactiveProperty(mInputContent.text),
                        Completed = new BoolReactiveProperty(false),
                    });
                    mInputContent.text = string.Empty; //入力ボックスの消す
                });


            //mInputContent.OnEndEditAsObservable()　　　//Enterキーを押せば　
            //    .Subscribe(todoContent =>
            //    {
            //        Model.TodoItems.Add(new TodoItem()
            //        {
            //            Id = 3,
            //            Content = new StringReactiveProperty(todoContent),
            //            Completed = new BoolReactiveProperty(false),
            //        });
            //        mInputContent.text = string.Empty; 
            //    });

            //Model.TodoItems.ToReactiveCollection().ObserveCountChanged()
            Model.TodoItems.ObserveEveryValueChanged((items) => items.Count)  //　TodoLtemsの変化があればデータを更新する。

                .Subscribe(_ =>
                {
                    OnDataChanged();
                });
                

            OnDataChanged();
        }
        void OnDataChanged()
        {
            var childCount = Content.childCount;

            for(int i = 0; i < childCount; i++)
            {
                Destroy(Content.GetChild(i).gameObject);
            }


            Model.TodoItems.Where(todoItem => !todoItem.Completed.Value)  //使うにはusing System.Linq;が必要です
             .ToList()
             .ForEach(todoItem=> 
             {
                 todoItem.Completed.Subscribe(completed =>
                 {
                     if (completed)
                     {
                         OnDataChanged();
                     }
                 });

                 var uiTodoitem = Instantiate(mTodoItemPrototype);

                 uiTodoitem.transform.SetParent(Content);  //   SetParent 

                 uiTodoitem.transform.localScale = Vector3.one; //位置を調整する

                 uiTodoitem.gameObject.SetActive(true);

                 uiTodoitem.setModel(todoItem);
             });
            Model.Save();
        }
    }
}
