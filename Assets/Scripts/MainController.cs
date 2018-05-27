using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;



public class MainController : MonoBehaviour {

    private InputDevice m_inputDevice;
    private CharacterBase m_activeCharacter;
    private GameObject m_camera;
    private CameraController m_cameraController;
    private CharacterController m_characterController;

    private CharacterBase m_lastActiveCharacter;
    private bool m_blockUserInput;
    private GameObject m_collidedObject;
    private Animator m_animation;
    private GameObject m_activeGameObject;


    // Use this for initialization/
    void Start ()
    {
        //Get active controller.
        m_inputDevice = InputManager.ActiveDevice;

        //Get default player character and main camera instances.
        m_activeCharacter = FindObjectOfType<CharacterPlayer1>();
        m_characterController = gameObject.GetComponent<CharacterController>();
        m_camera = GameObject.FindGameObjectWithTag("MainCamera");
        m_cameraController = m_camera.GetComponent<CameraController>();

        //Set default target values for player character and main camera
        m_characterController.target = m_activeCharacter;
        m_cameraController.target = m_activeCharacter.transform;

    }
	
	// Update is called once per frame.
	void Update ()
    {
        SwitchCharacter();

    }

    //Set Active character based on DPad button.
    private void SwitchCharacter()
    {

        if (m_inputDevice.DPadUp.WasPressed || Input.GetButtonDown("1Button"))
        {
            PlayerGameobjectData player = new PlayerFactory().GetPlayer(PlayerType.Player1);
            Debug.Log("Player1 Selected");
            m_activeCharacter = player.characterType;
            m_characterController.target = m_activeCharacter;
            m_cameraController.setCameraTarget(m_activeCharacter.transform, 0.2f);
            //m_animator.target = 
        }
        else if (m_inputDevice.DPadRight.WasPressed || Input.GetButtonDown("2Button"))
        {
            Debug.Log("Player2 Selected");
            //m_activeCharacter = FindObjectOfType<CharacterPlayer2>();
            //m_characterController.target = m_activeCharacter;
            //m_cameraController.setCameraTarget(m_activeCharacter.transform, 0.2f);
            PlayerGameobjectData player = new PlayerFactory().GetPlayer(PlayerType.Player2);
            Debug.Log("Player1 Selected");
            m_activeCharacter = player.characterType;
            m_characterController.target = m_activeCharacter;
            m_cameraController.setCameraTarget(m_activeCharacter.transform, 0.2f);
        }
    }

}

public enum PlayerType
{
    Player1,
    Player2,
    Player3,
    Player4
}
public class PlayerGameobjectData
{
    private GameObject m_characterGameobject;
    private CharacterBase m_characterType;
    private Animator m_playerAnimator;

    public CharacterBase characterType
    {
        set { m_characterType = value; }
        get { return m_characterType; }
    }

    public Animator playerAnimator
    {
        set { m_playerAnimator = value; }
        get { return m_playerAnimator; }
    }

    public GameObject characterGameobject
    {
        set { m_characterGameobject = value; }
        get { return m_characterGameobject; }
    }
}

public interface IPlayerGameobjectComponents
{    
    PlayerGameobjectData GetPlayerComponents();
}

public class Player1GameObject : IPlayerGameobjectComponents
{
    private GameObject m_playerGameObj;
    private PlayerGameobjectData m_playerComponents;

    public PlayerGameobjectData GetPlayerComponents()
    {
        m_playerComponents = new PlayerGameobjectData();
        m_playerGameObj = GameObject.Find("Player1");

        m_playerComponents.characterGameobject = m_playerGameObj;
        m_playerComponents.characterType = m_playerGameObj.GetComponent<CharacterPlayer1>();
        m_playerComponents.playerAnimator = m_playerGameObj.GetComponent<Animator>();

        return m_playerComponents;
    }
}

public class Player2GameObject : IPlayerGameobjectComponents
{
    private GameObject m_playerGameObj;
    private PlayerGameobjectData m_playerComponents;

    public PlayerGameobjectData GetPlayerComponents()
    {
        m_playerComponents = new PlayerGameobjectData();
        m_playerGameObj = GameObject.Find("Player2");

        m_playerComponents.characterGameobject = m_playerGameObj;
        m_playerComponents.characterType = m_playerGameObj.GetComponent<CharacterPlayer2>();
        m_playerComponents.playerAnimator = m_playerGameObj.GetComponent<Animator>();

        return m_playerComponents;
    }
}

public class PlayerFactory
{
    public PlayerGameobjectData GetPlayer(PlayerType type)
    {
        switch(type)
        {
            case PlayerType.Player1:
                return new Player1GameObject().GetPlayerComponents();
            case PlayerType.Player2:
                return new Player2GameObject().GetPlayerComponents();
            default:
                throw new NotSupportedException();
        }
    }
}

//public class Player