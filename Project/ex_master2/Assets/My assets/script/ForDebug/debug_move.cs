using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debug_move : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] float debugMoveSpeed;

    private bool debug = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            debug = true;
        }

        if (debug)
        {
            this.transform.position += new Vector3(0, 0, debugMoveSpeed) * Time.deltaTime;
        }
            if (text != null)
        {
            text.text = this.transform.position.ToString();
        }
    }

    public void DebugStop()
    {
        debug = false;
    }
}
