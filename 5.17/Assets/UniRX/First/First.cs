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
//  progress    進歩、発達、発展、前進、進行、成り行き、経過
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
using DG.Tweening;
using System.Linq;
namespace UniRxLesson
{
    public class First : MonoBehaviour
    {
        class Student
        {
            public string Name;
            public int Age;

        }

        // Use this for initialization
        void Start()
        {
            var students = new List<Student>()
            {
                new Student{ Name="A",Age=28},
                new Student{ Name="B",Age=18},
                new Student{ Name="C",Age=38 },
            };

            //----------UniRX 链 式

            //var Sstudent = students.First();   //获取第一个 
            //Debug.Log(Sstudent.Name);

            //var NewStudent = students.First(student => student.Age > 20);   //获取第年龄大于20的第一个 
            //Debug.Log(NewStudent.Name);
            // linq 式

            var newStudent = (from student in students select student)      //获取第年龄大于10的第一个 
            .First(student => student.Age > 10);
            Debug.Log(newStudent.Name);


            Observable.EveryUpdate()
                .First(_ => Input.GetKeyDown(KeyCode.X))     //仅在第一次触发
                .Subscribe(_ =>
                {
                    Debug.Log("X down First");
                })
                .AddTo(this);
        }

    }
}
