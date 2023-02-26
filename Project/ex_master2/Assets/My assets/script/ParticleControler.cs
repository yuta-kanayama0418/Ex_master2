using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControler : MonoBehaviour
{
    private ParticleSystem particleSystemInstance;

    // Start is called before the first frame update
    void Start()
    {
        particleSystemInstance = GetComponent<ParticleSystem>();
        this.gameObject.SetActive(false);

        var pSmain = particleSystemInstance.main;
        var pSshape = particleSystemInstance.shape;
        var pSemit = particleSystemInstance.emission;
        if (data_util_wood._stimuliType == data_util_wood.StimuliType.OFNone)
        {
            pSmain.startLifetime = 3000;
            pSmain.startSpeed = 1f;
            pSmain.simulationSpeed = 0.00001f;
            pSemit.rateOverTime = 100;
        }
        else if(data_util_wood._stimuliType == data_util_wood.StimuliType.OFBack)
        {
            if (data_util_wood._speedPerception == data_util_wood.SpeedPerception.slow)
            {
                pSmain.startLifetime = 20;
                pSmain.startSpeed = 1f;
                pSmain.simulationSpeed = 1f;
                pSshape.angle = 6f;
                pSemit.rateOverTime = 200;
            }
            else if(data_util_wood._speedPerception == data_util_wood.SpeedPerception.fast)
            {
                pSmain.startLifetime = 20;
                pSmain.startSpeed = -1f;
                pSmain.simulationSpeed = 1f;
                pSshape.angle = 6f;
                pSemit.rateOverTime = 200;
            }
        }
        else if(data_util_wood._stimuliType == data_util_wood.StimuliType.OFFront)
        {
            if(data_util_wood._speedPerception == data_util_wood.SpeedPerception.slow)
            {
                pSmain.startLifetime = 8;
                pSmain.startSpeed = -3f;
                pSmain.simulationSpeed = 1f;
            }
            else if(data_util_wood._speedPerception == data_util_wood.SpeedPerception.fast)
            {
                pSmain.startLifetime = 8;
                pSmain.startSpeed = 1f;
                pSmain.simulationSpeed = 1f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ParticleStart()
    {
        this.gameObject.SetActive(true);
    }
}
