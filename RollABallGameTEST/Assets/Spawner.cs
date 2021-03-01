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
    public List<GameObject> ringsInLevel = new List<GameObject>();
    public List<GameObject> ringsLoaded = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        float ringWidth = 2*(ringType1.GetComponent<MeshRenderer>().bounds.extents.z);
        for (int i = 0; i<10 ; i++)
        {
            ringsInLevel.Add(ringType1);
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
        for(int i = 0; i<=ringsLoaded.Count; i++)
        {
            ringsLoaded[i].transform.position = new UnityEngine.Vector3(0,0, ringsLoaded[i].transform.position.z - velocity * Time.deltaTime);
        }

        float newSpeed = velocity += acceleration * Time.deltaTime;
        velocity = newSpeed;

    }
}
