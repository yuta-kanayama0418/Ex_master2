using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visual_stimuliForIR : MonoBehaviour
{
    private bool stimuliFlg = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stimuliFlg)
        {
            this.transform.position += new Vector3(0, 0, (float)datautil.sidewalkMoveSpeed) * Time.deltaTime;
        }
    }

    public void stimuliFlgSet()
    {
        //Debug.LogWarning("stimuli on");
        if (datautil.stimuliType_ != datautil.StimuliType.None) stimuliFlg = true;
    }
}
