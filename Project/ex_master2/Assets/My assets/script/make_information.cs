using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;
using UnityEngine.Events;

public class make_information : MonoBehaviour
{
    [SerializeField]
    Text info;

    [SerializeField] private Material[] materials;


    private string[] industry = new string[9]
    {
        "レストラン",
        "中華料理店",
        "ラーメン店",
        "焼き肉店",
        "そば・うどん店",
        "すし店",
        "酒場",
        "喫茶店",
        "ハンバーガー店"
    };

    private string[] day = new string[5]
    {
        "月曜",
        "火曜",
        "水曜",
        "木曜",
        "金曜"
    };

    private string[] marubatu = new string[2]
    {
        "〇",
        "×"
    };

    // Start is called before the first frame update
    void Start()
    {
        info.text = industry[UnityEngine.Random.Range(0, industry.Length)] + "\n";
        info.text += UnityEngine.Random.Range(5, 13).ToString() + ":00 ~ " + UnityEngine.Random.Range(14, 28).ToString() + ":00\n";
        info.text += "定休日: " + day[UnityEngine.Random.Range(0, day.Length)] + "\n";
        info.text += "テイクアウト: " + marubatu[UnityEngine.Random.Range(0, 2)] + "配達: " + marubatu[UnityEngine.Random.Range(0, 2)] + "\n";
        info.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(datautil.player_.transform);
        transform.Rotate(new Vector3(1, 0, 0), 90);
        transform.Rotate(new Vector3(0, -1, 0), 90);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.LogWarning("trigger enter");

        if (other.gameObject.GetComponent<pointer>().flg)
        {
            this.GetComponent<Renderer>().material = materials[1];
            Destroy(other.gameObject);
            info.text += "r\n";
        }
        else
        {
            this.GetComponent<Renderer>().material = materials[0];
            Destroy(other.gameObject);
            info.text += "b\n";
        }
    }

}
