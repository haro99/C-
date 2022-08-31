using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Status
{
    Standby,
    Down,
    Up
}

public class NewBehaviourScript : MonoBehaviour
{
    public Text Text, Counttext, Messagetext;
    public Vector3 position;
    public int count, count2;
    public Status status;
    private Quaternion gyro;

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        this.gyro = Input.gyro.attitude;
        position = Input.acceleration;
    }

    // Update is called once per frame
    void Update()
    {
        // 加速度センサの値を取得
        Vector3 val = Input.acceleration;
        //保存された加速度からリアルタイムの差速度を引く
        val = val - position;
        //x,y,zそれぞれの値を出力する
        Text.text = "x:" + val.x + "y:" + val.y + "z:" + val.z;

        switch (status)
        {
            case Status.Down:
                Messagetext.text = "下げて";
                //一定の加速度があったら
                if (val.y <= -0.15f)
                {
                    //カウント
                    

                    status = Status.Up;
                }
                break;

            case Status.Up:
                Messagetext.text = "上げて";
                if(val.y >= 0.15f)
                {
                    count++;
                    Counttext.text = count.ToString() + "回";
                    status = Status.Down;
                }
                break;
        }
    }

    public void Button()
    {
        position = Input.acceleration;
        status = Status.Down;
    }
}
