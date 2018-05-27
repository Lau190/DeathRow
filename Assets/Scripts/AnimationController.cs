using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class AnimationController : MonoBehaviour {
    private Animator m_activeAnimator;
    private InputDevice m_inputDevice;
    private float m_XInput;
    private float m_YInput;

    public bool EnableKeyboardControl;
     
    public Animator target
    {
        set
        {
            m_activeAnimator = value;
        }

        get
        {
            return m_activeAnimator;
        }
    }
	// Use this for initialization
	void Start ()
    {
        EnableKeyboardControl = true;
        m_inputDevice = InputManager.ActiveDevice;
        m_XInput = 0;
        m_YInput = 0;
    }

    // Update is called once per frame
    void Update()
    {


        if (EnableKeyboardControl)
        {
            //XInput
        } 
        else
        {

        }

       // m_activeAnimator.SetFloat("Xmove", )
	}

    
}
