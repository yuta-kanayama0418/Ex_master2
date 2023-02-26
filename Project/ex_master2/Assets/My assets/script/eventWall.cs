using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class eventWall : MonoBehaviour
{
    [SerializeField] UnityEvent event_wall;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.LogWarning("wall enter");
            event_wall.Invoke();
        }
    }
}
