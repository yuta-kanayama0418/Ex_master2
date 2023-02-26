using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ammo : MonoBehaviour
{
    [SerializeField]
    private GameObject controller;

    public float ammoSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(controller.transform.rotation);

        transform.position = controller.transform.position;
        transform.rotation = controller.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * ammoSpeed;
    }


    private void OnTriggerEnter(Collider other)
    {
        //Debug.LogWarning("hit");
        //Destroy(this.gameObject);
        if (other.gameObject.tag == datautil_for_shooting.targetTag_.ToString())
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            if (SceneManager.GetActiveScene().name == "ex_wood")
            {
                data_util_wood._destroyTargetCnt += 1;
            }
            else //if (SceneManager.GetActiveScene().name == "shoot_outside")
            {
                datautil_for_shooting.destroyTargetCnt += 1;
            }

        }
        else if(other.gameObject.tag != "Untagged" && other.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
            //Debug.LogWarning("shoot miss");
            if (SceneManager.GetActiveScene().name == "ex_wood")
            {
                data_util_wood._destroyUntargetCnt += 1;
            }
            else //if (SceneManager.GetActiveScene().name == "shoot_outside")
            {
                datautil_for_shooting.destroyUntargetCnt += 1;
            }
        }
    }

}
