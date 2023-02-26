using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class select : MonoBehaviour
{

    [SerializeField] UnityEvent event_trigger_btn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            //Debug.LogWarning("button A");
            Select(true);
            datautil.selectCnt_++;
        }
        //if (Input.GetKeyDown(KeyCode.Mouse1))
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            //Debug.LogWarning("button B");
            Select(false);
            datautil.selectCnt_++;
        }

        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            Debug.LogWarning("finish");
            event_trigger_btn.Invoke();
        }
    }

    private void Select(bool flg)
    {
        GameObject selecter;
        selecter = Instantiate(GameObject.Find("pointer"), GameObject.Find("pointer").transform.position,
            GameObject.Find("pointer").transform.rotation);
        pointer pointerInstance = selecter.GetComponent<pointer>();
        pointerInstance.flg = flg;
    }

}
