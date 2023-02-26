using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Debug = UnityEngine.Debug;

public class datautil_for_shooting : MonoBehaviour
{
    [SerializeField] private double SidewalkMoveSpeed = 0;
    [SerializeField] string participant = "None";
    [SerializeField] private int targetCnt = 3;
    [SerializeField]
    private TargetTag targetTag = TargetTag.red;
    [SerializeField]
    private StimuliType stimuliType = StimuliType.None;

    [SerializeField] private AudioClip[] sounds;
    [SerializeField] UnityEvent sight_reset;
    
    

    public enum TargetTag
    {
        red,
        blue,
        green
    }

    public enum StimuliType
    {
        None,
        Visual,
        VisualandAuditory
    }

    public static double sidewalkMoveSpeed;
    public static StimuliType stimuliType_;
    public static TargetTag targetTag_;
    public static int targetCnt_;
    public static int destroyTargetCnt = 0;
    public static int destroyUntargetCnt = 0;
    public static int shootCnt = 0;
    public static AudioClip sound_;
    public static Dictionary<string, Vector3> targetPosition = new Dictionary<string, Vector3>();

    private string fold_path;
    private string file_name;
    private System.Diagnostics.Stopwatch timeStopwatch = new Stopwatch();

    private bool flg = true;
    // Start is called before the first frame update
    void Awake()
    {
        sidewalkMoveSpeed = SidewalkMoveSpeed;
        targetTag_ = targetTag;
        stimuliType_ = stimuliType;
        targetCnt_ = targetCnt;

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

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))
            //if (Input.GetKeyDown(KeyCode.Return))
        {
            DateTime dt = DateTime.Now;
            //Output_text();
            //Debug.LogWarning(fold_path + file_name);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sight_reset.Invoke();
            Debug.Log("sight reset");
        }

        if (destroyTargetCnt == targetCnt * 2 && flg)
        {
            Output_text();
            flg = false;
        }
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
            sb.Append("condition: " + stimuliType_.ToString() + "\n");
            sb.Append("target color: " + targetTag_.ToString() + "\n");
            sb.Append("time: " + milli_sec.ToString() + "\n");
            sb.Append("shoot count: " + shootCnt.ToString() + "\n");
            sb.Append("destroy target num : " + destroyTargetCnt.ToString() + "\n");
            sb.Append("destrot untarget num : " + destroyUntargetCnt.ToString() + "\n");
            int shootingScore = destroyTargetCnt - destroyUntargetCnt;
            sb.Append("shooting score : " + shootingScore.ToString() + "\n");

            foreach (var dict in targetPosition)
            {
                //sb.Append(dict.Key + " position: " + dict.Value + "\n");
            }

            sw.WriteLine(sb.ToString());
        }
        Debug.LogWarning("file output");
    }

    public void TimeStart()
    {
        timeStopwatch.Start();
    }
}
