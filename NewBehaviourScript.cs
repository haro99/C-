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
        // �����x�Z���T�̒l���擾
        Vector3 val = Input.acceleration;
        //�ۑ����ꂽ�����x���烊�A���^�C���̍����x������
        val = val - position;
        //x,y,z���ꂼ��̒l���o�͂���
        Text.text = "x:" + val.x + "y:" + val.y + "z:" + val.z;

        switch (status)
        {
            case Status.Down:
                Messagetext.text = "������";
                //���̉����x����������
                if (val.y <= -0.15f)
                {
                    //�J�E���g
                    

                    status = Status.Up;
                }
                break;

            case Status.Up:
                Messagetext.text = "�グ��";
                if(val.y >= 0.15f)
                {
                    count++;
                    Counttext.text = count.ToString() + "��";
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
