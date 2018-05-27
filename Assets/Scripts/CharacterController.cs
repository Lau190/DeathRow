using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class CharacterController : MonoBehaviour {


    private CharacterBase m_activeCharacter;
    private InputDevice m_inputDevice;

    public CharacterBase target
    {
        get { return m_activeCharacter; }
        set { m_activeCharacter = value; }
    }

    // Use this for initialization
    void Start ()
    {
        m_inputDevice = InputManager.ActiveDevice;
    }
	
	// Update is called once per frame
	void Update ()
    {
       if(Input.GetButton("a"))
        {
            m_activeCharacter.Interact();
        } 
        //TO DO update input device only if a change of input devices occoured: m_inputDevice = InputManager.ActiveDevice;
    }

    void FixedUpdate()
    {
        m_activeCharacter.MoveCharacter(new Vector2(m_inputDevice.LeftStick.X, m_inputDevice.LeftStick.Y));

        //Used to get input from keyboard in case controller is not pluged

        float X = Input.GetAxis("Horizontal");
        float Y = Input.GetAxis("Vertical");

        if(X != 0f || Y != 0f)
        {
            m_activeCharacter.MoveCharacter(new Vector2(X, Y));
        }
    }

    void SetActiveCharacter(CharacterBase character)
    {
        m_activeCharacter = character;
    }
}
