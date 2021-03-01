using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    public float velocity;
    public float acceleration;
    public float destroyPoint;
    public float spawnPoint;
    public GameObject ringType1;
    public GameObject ringType2;
    public List<GameObject> ringsInLevel = new List<GameObject>();
    public List<GameObject> ringsLoaded = new List<GameObject>();
    float ringWidth;
    

    // Start is called before the first frame update
    void Start()
    {
        
        ringWidth = 2*(ringType1.GetComponent<MeshRenderer>().bounds.extents.z);
        for (int i = 0; i<50 ; i++)
        {
            if (UnityEngine.Random.Range(0f, 2) > 1)
            {
                ringsInLevel.Add(ringType2);
            }
            else 
            {
                ringsInLevel.Add(ringType1);
            }
        }

        int ringsAtStart = (int)(System.Math.Abs(spawnPoint - destroyPoint) / ringWidth);
        for (int i = 0; i<ringsAtStart; i++)
        {
            ringsLoaded.Add(Instantiate(ringsInLevel[i], new UnityEngine.Vector3(0, 0, destroyPoint+i*ringWidth), UnityEngine.Quaternion.identity)) ;

        }
        Debug.Log(ringsLoaded.Count);
    }

    // Update is called once per frame
    void Update()
    {
        for (int a = 0; a < (int)((Math.Abs(ringsLoaded[ringsLoaded.Count-1].transform.position.z - spawnPoint)) / ringWidth) ; a++)
        {
            ringsLoaded.Add(Instantiate(ringsInLevel[ringsLoaded.Count-1], new UnityEngine.Vector3(0, 0, ringsLoaded[ringsLoaded.Count-1].transform.position.z + (a+1) * ringWidth), UnityEngine.Quaternion.identity));
        }
        
        for(int i = 0; i<ringsLoaded.Count; i++)
        {
            ringsLoaded[i].transform.position = new UnityEngine.Vector3(0,0, ringsLoaded[i].transform.position.z - velocity * Time.deltaTime);
        }

        float newSpeed = velocity + acceleration * Time.deltaTime;
        velocity = newSpeed;

    }
}
