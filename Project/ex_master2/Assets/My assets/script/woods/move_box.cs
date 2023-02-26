using UnityEngine;

public class move_box : MonoBehaviour
{
    private bool move = false;
    private float speed = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            switch (data_util_wood._speedPerception)
            {
                case data_util_wood.SpeedPerception.fast:
                    this.transform.position -= new Vector3(0, 0, data_util_wood._whillSpeed * (data_util_wood._speedMagnification - 1)) * Time.deltaTime;
                    break;
                case data_util_wood.SpeedPerception.slow:
                    this.transform.position += new Vector3(0, 0, data_util_wood._whillSpeed * (data_util_wood._speedMagnification - 1)) * Time.deltaTime;
                    break;
            }
        }
    }

    public void Move_box()
    {
        if (data_util_wood._stimuliType == data_util_wood.StimuliType.PoleStimuli)
        {
            move = true;
            //Debug.LogWarning(data_util_wood.mag);
        }
    }

    public void Stop_box()
    {
        move = false;
    }
}
