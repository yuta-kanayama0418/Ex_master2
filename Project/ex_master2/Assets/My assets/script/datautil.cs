using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;


public class datautil : MonoBehaviour
{
    [SerializeField] private double SidewalkMoveSpeed = 0;

    [SerializeField] string participant = "None";
    [SerializeField]
    private StimuliType stimuliType = StimuliType.None;

    [SerializeField] private GameObject player;
    [SerializeField] Text[] info;
    [SerializeField] private AudioClip[] sounds;
    [SerializeField] UnityEvent sight_reset;

    public static double sidewalkMoveSpeed;
    public static StimuliType stimuliType_;
    public static GameObject player_;
    public static int selectCnt_ = 0;
    public static AudioClip sound_;

    private string fold_path;
    private string file_name;
    private System.Diagnostics.Stopwatch timeStopwatch = new Stopwatch();

    public enum StimuliType
    {
        None,
        Visual,
        VisualandAuditory
    }

    private void Awake()
    {
        sidewalkMoveSpeed = SidewalkMoveSpeed;
        stimuliType_ = stimuliType;
        player_ = player;

        switch (stimuliType_)
        {
            case StimuliType.None:
                sound_ = sounds[0];
                break;
            case StimuliType.Visual:
                sound_ = sounds[0];
                break;
            case StimuliType.VisualandAuditory:
                sound_ = sounds[1];
                break;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sight_reset.Invoke();
        }

        //if (Input.GetKeyDown(KeyCode.Mouse3))
        //if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    Debug.LogWarning("time stop");
        //    timeStopwatch.Stop();
        //}

    }

    public void Time_measure_start()
    {
        timeStopwatch.Start();
    }

    public void Output_text()
    {
        //if (timeStopwatch.IsRunning)
        //{
        //    timeStopwatch.Stop();
        //}

        TimeSpan ts = timeStopwatch.Elapsed;
        var milli_sec = timeStopwatch.ElapsedMilliseconds;
        StringBuilder sb = new StringBuilder();
        DateTime dt = DateTime.Now;
        fold_path = "Data\\" + dt.ToString("yyyy-M-d") + participant + "\\";
        file_name = SceneManager.GetActiveScene().name + ".txt";

        if (!Directory.Exists(fold_path))
        {
            Directory.CreateDirectory(fold_path);
            Debug.Log("make directory");
        }

        using (StreamWriter sw = new StreamWriter(fold_path + file_name, true, Encoding.GetEncoding("Shift_JIS")))
        {
            sb.Append(dt.ToString("g") + "\n");
            sb.Append(milli_sec.ToString() + "msec\n");
            sb.Append("select count: " + datautil.selectCnt_.ToString() + "\n");
            int i = 1;
            sb.Append("1: 左手前，2: 左真ん中，3: 右手前，4: 右真ん中，5: 左奥，6: 右奥\n");
            foreach (var text in info)
            {
                sb.Append("表示テキスト" + i.ToString() + ": ");
                sb.Append(text.text.ToString());
                //sb.Append(text)
                i++;
            }

            sw.WriteLine(sb.ToString());
        }
    }

    public void Text_enabled()
    {
        foreach (var text in info)
        {
            text.enabled = true;
        }
    }
}
