using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinking : MonoBehaviour
{
    [SerializeField] private int blink_cnt = 1000;
    [SerializeField] private GameObject visualStimuli;
    private int count =0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        Debug.Log(count);

        if (count > blink_cnt)
        {
            Debug.Log(!visualStimuli.activeSelf);
            visualStimuli.SetActive(!visualStimuli.activeSelf);
            count = 0;
        }

    }
}
