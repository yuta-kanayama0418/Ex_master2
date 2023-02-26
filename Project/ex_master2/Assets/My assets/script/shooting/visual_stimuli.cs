using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visual_stimuli : MonoBehaviour
{
    bool visualStimuli = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (visualStimuli)
        {
            this.transform.position += new Vector3(0, 0, (float)datautil_for_shooting.sidewalkMoveSpeed) * Time.deltaTime;
        }
    }

    public void VisualStimuli()
    {
        if(datautil_for_shooting.stimuliType_ != datautil_for_shooting.StimuliType.None) visualStimuli = true;
    }
}
