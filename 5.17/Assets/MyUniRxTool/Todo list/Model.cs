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
namespace UniRxLesson
{        ///<summary>
         ///未処理（みしょり）事項（じこう）
         ///</summary>
    [Serializable]      //实列化
    public class TodoItem
        {
        ///<summary>
        ///The identifler,
        ///</summary>
            public int Id;
        ///<summary>
        ///内容
        ///</summary>
        public StringReactiveProperty Content;
        ///<summary>
        ///完成しましたか？
        ///</summary>
        public BoolReactiveProperty Completed;
        }
        [Serializable]
        public class TodoList
        {
            public List<TodoItem> TodoItems = new List<TodoItem>()
        {
            new TodoItem
            {
                Id=0,
                Content=new StringReactiveProperty("買い物します"),
                Completed=new BoolReactiveProperty(false)
             },
            new TodoItem
            {
                Id=1,
                Content=new StringReactiveProperty("図書館に行きます"),
                Completed=new BoolReactiveProperty(false)


            },
            //new TodoItem
            //{
            //    Id=2,
            //    Content=new StringReactiveProperty("家に帰る"),
            //    Completed=new BoolReactiveProperty(false)
            //}

        };

        public void Save()
        {
            PlayerPrefs.SetString("model",JsonUtility.ToJson(this));
        }

        internal static TodoList Load()
        {
            var jsonContent = PlayerPrefs.GetString("model", string.Empty);
            if (string.IsNullOrEmpty(jsonContent))
            {
                return new TodoList();
            }
            else
            { 
           return JsonUtility.FromJson<TodoList>(jsonContent);
            }
        }
    }
}

