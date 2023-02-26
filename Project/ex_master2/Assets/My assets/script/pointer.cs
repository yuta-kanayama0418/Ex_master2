using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointer : MonoBehaviour
{
    [SerializeField]
    private GameObject controller;

    public bool flg;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = controller.transform.position;
        transform.rotation = controller.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 100;
    }
}
