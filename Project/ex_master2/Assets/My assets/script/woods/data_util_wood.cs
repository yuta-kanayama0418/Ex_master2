using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Debug = UnityEngine.Debug;

public class data_util_wood : MonoBehaviour
{
    [SerializeField] private string subject = "None";
    [SerializeField] private bool practice;
    [SerializeField]
    private StimuliType stimuliType = StimuliType.None;
    [SerializeField] private SpeedPerception speedPerception = SpeedPerception.slow;

    [SerializeField] private int targetCnt = 3;
    [SerializeField]
    private TargetTag targetTag = TargetTag.red;

    [SerializeField] private GameObject[] stimuliObjects;
    [SerializeField] private AudioClip[] sounds;
    [SerializeField] UnityEvent sight_reset;

    public enum TargetTag
    {
        red,
        blue,
        green
    }
    public enum SpeedPerception
    {
        fast,
        slow
    }

    public enum StimuliType
    {
        None,
        PoleNone,
        PoleStimuli,
        OFNone,
        OFBack,
        OFFront
    }

    public static string _subject; //被験者名
    public static bool _practiceFlg; //基準走行フラグ
    public static AudioClip _auditoryStimuli;
    public static float _speedMagnification; //視覚刺激倍率
    public static StimuliType _stimuliType;
    public static SpeedPerception _speedPerception; //実際のWHILLの走行タイプ

    public const float _whillSpeed = 2.0f; //等速条件のWHILLの速度
    //public const float _whillAcceleration = 0.05367f; //WHILLの加速度
    //public const float destination = 9.0f; //走行距離(m)
    public static TargetTag _targetTag;
    public static int _targetCnt;
    public static int _destroyTargetCnt = 0;
    public static int _destroyUntargetCnt = 0;
    public static int _shootCnt = 0;

    private string foldPath;
    private string fileName;
    private Stopwatch timeStopwatch = new Stopwatch();
    private bool flg = true;

    // Start is called before the first frame update
    void Awake()
    {
        _subject = subject;
        _practiceFlg = practice;
        _stimuliType = stimuliType;
        _speedPerception = speedPerception;

        if (_stimuliType != StimuliType.None) _speedMagnification = 1.5f;
        else _speedMagnification = 1.0f;

        _targetTag = targetTag;
        _targetCnt = targetCnt;

        // sound set
        if (_stimuliType == StimuliType.None || _stimuliType == StimuliType.OFNone || _stimuliType == StimuliType.PoleNone)
        {
            _auditoryStimuli = sounds[0];
        }
        else
        {
            switch (_speedPerception)
            {
                case SpeedPerception.fast:
                    _auditoryStimuli = sounds[1];
                    break;
                case SpeedPerception.slow:
                    _auditoryStimuli = sounds[2];
                    break;
            }
        }

        if(_stimuliType == StimuliType.PoleNone || _stimuliType == StimuliType.PoleStimuli)
        {
            foreach(var obj in stimuliObjects)
            {
                if (obj == stimuliObjects[0]) obj.SetActive(true);
                else obj.SetActive(false);
            }
        }
        else if(_stimuliType == StimuliType.OFNone || _stimuliType == StimuliType.OFBack)
        {
            foreach(var obj in stimuliObjects)
            {
                if (obj == stimuliObjects[1]) obj.SetActive(true);
                else obj.SetActive(false);
            }
        }
        else if(_stimuliType == StimuliType.OFFront)
        {
            foreach (var obj in stimuliObjects)
            {
                if (obj == stimuliObjects[2]) obj.SetActive(true);
                else obj.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sight_reset.Invoke();
        }

        if (_destroyTargetCnt == targetCnt * 2 && flg)
        {
            Output_text();
            flg = false;
        }
    }

    public void Output_text()
    {
        TimeSpan ts = timeStopwatch.Elapsed;
        var milli_sec = timeStopwatch.ElapsedMilliseconds;
        StringBuilder sb = new StringBuilder();
        DateTime dt = DateTime.Now;

        if (_practiceFlg) foldPath = "Data\\" + dt.ToString("yyyy-M-d_") + subject + "-practice\\";
        else foldPath = "Data\\" + dt.ToString("yyyy-M-d_") + subject + "\\";
        fileName = SceneManager.GetActiveScene().name + ".txt";

        if (!Directory.Exists(foldPath))
        {
            Directory.CreateDirectory(foldPath);
        }

        using (StreamWriter sw = new StreamWriter(foldPath + fileName, true, Encoding.GetEncoding("Shift_JIS")))
        {
            sb.Append(dt.ToString("g") + "\n");
            //sb.Append("condition: " + _speedPerception.ToString() + "\n");
            sb.Append("stimuli type: " + _stimuliType.ToString() + "  " + _speedPerception.ToString() + "\n");
            //sb.Append("target color: " + _targetTag.ToString() + "\n");
            sb.Append("time: " + milli_sec.ToString() + "\n");
            sb.Append("shoot count: " + _shootCnt.ToString() + "\n");
            sb.Append("destroy target num : " + _destroyTargetCnt.ToString() + "\n");
            sb.Append("destrot untarget num : " + _destroyUntargetCnt.ToString() + "\n");
            int shootingScore = _destroyTargetCnt - _destroyUntargetCnt;
            sb.Append("shooting score : " + shootingScore.ToString() + "\n");

            //foreach (var dict in targetPosition)
            //{
            //    sb.Append(dict.Key + " position: " + dict.Value + "\n");
            //}

            sw.WriteLine(sb.ToString());
        }
        //Debug.LogWarning("file output");
    }

    public void TimeStart()
    {
        timeStopwatch.Start();
        //Debug.LogWarning("start");
    }

}
