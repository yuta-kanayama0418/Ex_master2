using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class radomSpawnTarget : MonoBehaviour
{
    [SerializeField]
    GameObject[] targetObj;

    [SerializeField] private GameObject parentObj;

    private int objCnt = 0;

    public void spawnTarget()
    {
        spawnObject(4f, 13f);
        spawnObject(15f, 24f);
        spawnObject(26f, 35f);
        //Debug.LogWarning("ogj cnt: " + objCnt.ToString());
    }

    void spawnObject(float startZ, float lastZ)
    {
        GameObject newGameObject;
        string newKey;
        Vector3 randomVec;
        int tempObjCnt = objCnt;
        int targetCnt = 0;

        if (SceneManager.GetActiveScene().name == "ex_wood")
        {
            targetCnt = data_util_wood._targetCnt;
        }
        else
        {
            targetCnt = datautil_for_shooting.targetCnt_;
        }

        for (int i = tempObjCnt; i < targetCnt + tempObjCnt; i++)
        {
            foreach (GameObject obj in targetObj)
            {
                while (true)
                {
                    randomVec = new Vector3(Random.Range(8.5f, 9f), Random.Range(2f, 8f), Random.Range(startZ, lastZ));
                    if (Physics.CheckSphere(randomVec, 0.5f))
                    {
                        //Debug.LogWarning("need replace(right)");
                        continue;
                    }
                    else
                    {
                        newGameObject = Instantiate(obj, randomVec, Quaternion.identity);
                        if (SceneManager.GetActiveScene().name == "ex_wood")newGameObject.transform.parent = parentObj.transform;

                            newKey = newGameObject.tag + i.ToString();
                        datautil_for_shooting.targetPosition.Add(newKey + "right", newGameObject.transform.position);
                        break;
                    }
                }
            }

            foreach (GameObject obj in targetObj)
            {
                while (true)
                {
                    randomVec = new Vector3(Random.Range(-8.5f, -9f), Random.Range(2f, 8f), Random.Range(startZ, lastZ));
                    if (Physics.CheckSphere(randomVec, 0.5f))
                    {
                        //Debug.LogWarning("need replace(left)");
                        continue;
                    }
                    else
                    {
                        newGameObject = Instantiate(obj, randomVec, Quaternion.identity);
                        if (SceneManager.GetActiveScene().name == "ex_wood") newGameObject.transform.parent = parentObj.transform;

                        newKey = newGameObject.tag + i.ToString();
                        datautil_for_shooting.targetPosition.Add(newKey + "left", newGameObject.transform.position);
                        break;
                    }
                }
            }

            objCnt++;
        }
    }
}
