using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GameObject ballPlayer = GameObject.Find("playerBall");
        //BallController ballController = ballPlayer.GetComponent<BallController>();
        //float degreeToRotate = ((float)ballController.angleToRotate * 360) / (2 * Mathf.PI);
        //transform.Rotate(0, 0, degreeToRotate);
    }

    // Update is called once per frame
    void Update()
    {
        //float currentZRotation = this.transform.rotation.z;
        //transform.rotation = Quaternion.Euler(0, 0, (currentZRotation + rotationAngle));
        //currentZRotation = transform.rotation.z;
    }
    private void FixedUpdate()
    {
        GameObject ballPlayer = GameObject.Find("playerBall");
        BallController ballController = ballPlayer.GetComponent<BallController>();
        float degreeToRotate = ((float)ballController.angleToRotate * 360) / (2 * Mathf.PI);
        transform.Rotate(0, 0, degreeToRotate);
    }
}
