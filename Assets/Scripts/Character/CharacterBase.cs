using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour {

    public float m_movementSpeed;
    public bool m_disableDiagonalMovement;

    private GameObject m_collidedObject;


    private Rigidbody2D m_rigidBody;

    private void Start()
    {
        m_movementSpeed = 5.0f;
        m_disableDiagonalMovement = true;
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_collidedObject = null;
    }

    public virtual void MoveCharacter(Vector2 moveInput)
    {
        float xValue = moveInput.x;
        float yValue = moveInput.y;

        //Restricts diagonal movement
        if (m_disableDiagonalMovement)
        {
            if (Mathf.Abs(xValue) > Mathf.Abs(yValue))
            {
                yValue = 0f;
            }
            else
            {
                xValue = 0f;
            }
        }

        Vector2 move = new Vector2(m_movementSpeed * xValue, m_movementSpeed * yValue);
        m_rigidBody.velocity = move;
    }

    public virtual void Interact()
    {
        if (m_collidedObject == null)
        {
            return;
        }
        else
        {
            //m_collidedObject.GetComponent;
        }
        //call the onInteract method of the object you interact with.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_collidedObject = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        m_collidedObject = collision.gameObject;
    }

    public GameObject GetCollidedObject()
    {
        return m_collidedObject;
    }







}
