using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float m_damping;

    private Vector3 m_velocity;
    private Transform  m_target;
    private float m_offsetZ; //Used to maintain the Z value on the camera in order to avoid making the characters dissapear.                     

    //Constants used to replace magic numbers in code
    const float constCameraNoDamp = 0f;


    public Transform target
    {
        get { return m_target; }
        set { m_target = value; }
    }
    
    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        m_offsetZ = (transform.position - m_target.transform.position).z;

        Vector3 newCameraPosition = Vector3.SmoothDamp(transform.position, (m_target.transform.position) + (Vector3.forward * m_offsetZ), ref m_velocity, m_damping);
        transform.position = newCameraPosition;

        //Reset the camera damping after camera has moved to target - TO DO
        //if ((m_damping != 0.0f) && isTargetReached(m_target.transform))
        //{
        //    Debug.Log("damping reset");
        //    m_damping = constCameraNoDamp;
        //}

    }

    public void setCameraTarget(Transform target, float damping)
    {
        m_target = target;
        m_damping = damping;
    }

    //Not used. It is meant to determine if the camera position has reached the player position - TO DO
    private bool isTargetReached(Transform target)
    {
        if(transform.position.x == m_target.transform.position.x &&
            transform.position.y == m_target.transform.position.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

