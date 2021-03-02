using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PointOfRotation : MonoBehaviour
{
  public  float X = 0;
  public  float Y = 0;
}

public class BallController : MonoBehaviour
{
    //Vector3 m_NewForce = new Vector3(0.0f, 0.0f, 0.0f);
    //Vector3 m_NewForce2 = new Vector3(0.0f, 0.0f, 0.0f);
    // Start is called before the first frame update
    public double angleToRotate;
    public double anglePerSecond;
    (float, float) calcRotation((float, float) CosAndSin, (float, float) oldPosition )
    {
      float  newPositionX = oldPosition.Item1 * CosAndSin.Item1 - oldPosition.Item2 * CosAndSin.Item2;
      float  newPositionY = oldPosition.Item2 * CosAndSin.Item1 + oldPosition.Item1 * CosAndSin.Item2;
      (float, float) NewPosition = (newPositionX, newPositionY);
      return NewPosition;
    }


    (float,float) CalculateCosAndSin(double angle)
    {
        float sin = (float)Math.Sin(angle);
        float cos = (float)Math.Cos(angle);
        (float, float) CosAndSin = (cos, sin);
        return CosAndSin;
    }
    (float, float) MoveCenterTo0 (PointOfRotation centerOfRotation, BallController pointToMove)
    {
        float newPositionX = pointToMove.transform.position.x;
        float newPositionY = pointToMove.transform.position.y;
        newPositionX -= centerOfRotation.X;
        newPositionY -= centerOfRotation.Y;
        (float, float) NewPointOfRotation = (newPositionX, newPositionY);
        return NewPointOfRotation;
    }
    (float, float) MoveCenterBack(PointOfRotation centerOfRotation, (float, float) pointToMove)
    {
        float newPositionX = pointToMove.Item1;
        float newPositionY = pointToMove.Item2;  
        newPositionX += centerOfRotation.X;
        newPositionY += centerOfRotation.Y;
        (float, float) NewPointOfRotation = (newPositionX, newPositionY);
        return NewPointOfRotation;
    }
    (float, float) rotatePoint(PointOfRotation centerOfRotation, (float, float) CosAndSin, BallController pointToRotate)
    {
        (float, float) newPointAignedTo0 = MoveCenterTo0(centerOfRotation, pointToRotate);
        (float, float) newPointRotated = calcRotation(CosAndSin, newPointAignedTo0);
        (float, float) newPointAlignedBackToCenter = MoveCenterBack(centerOfRotation, newPointRotated);
         return newPointAlignedBackToCenter;
    }
    void moveLeft()
    {
        anglePerSecond += 0.0174;
        angleToRotate = anglePerSecond * (double)Time.deltaTime;
        Debug.Log("it works !");
    }
    void Start()
    {
        angleToRotate = 0;
        anglePerSecond = 0.11;
    }


    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("A key was pressed.");
            angleToRotate += 0.1;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("D key was released.");
            angleToRotate -= 0.1;
        }
    }
    private void FixedUpdate()
    {
        PointOfRotation por = new PointOfRotation();
        (float, float) cosAndSinCalculated = CalculateCosAndSin(angleToRotate);
        (float, float) newRotatedCoordinates = rotatePoint(por, cosAndSinCalculated, this);
        this.transform.position =  new Vector3(newRotatedCoordinates.Item1, newRotatedCoordinates.Item2, 0);



        // m_NewForce.x = 10.0f; //  (-1) * this.transform.position.x;
        // m_NewForce.y = 10.0f; //  (-1) * this.transform.position.y;
        // m_NewForce2.x = m_NewForce.y * (-1);
        // m_NewForce2.y = m_NewForce.x; 
        // m_NewForce2.x = m_NewForce.y * (-1);
        // rb.AddForce(m_NewForce);
        // rb.AddForce(m_NewForce2);

    }
}
