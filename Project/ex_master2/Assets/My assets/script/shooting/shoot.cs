using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class shoot : MonoBehaviour
{
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
            Attack();
            if (SceneManager.GetActiveScene().name == "ex_wood")
            {
                //Debug.LogWarning("active scene is " + SceneManager.GetActiveScene().name);
                data_util_wood._shootCnt++;
            }
            else //if (SceneManager.GetActiveScene().name == "shoot_outside")
            {
                datautil_for_shooting.shootCnt++;
            }
        }
    }

    private void Attack()
    {
        GameObject weapon;
        weapon = Instantiate(GameObject.Find("ammo"), GameObject.Find("ammo").transform.position,
            GameObject.Find("ammo").transform.rotation);
        ammo ammoInstance = weapon.GetComponent<ammo>();
    }


}
