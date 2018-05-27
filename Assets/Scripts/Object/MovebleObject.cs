using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class MovebleObject : CharacterBase
{

public override void MoveCharacter(Vector2 moveInput)
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

    //Move by modifying the transform
    Vector3 moveVector = new Vector3(xValue * m_movementSpeed * Time.deltaTime, yValue * m_movementSpeed * Time.deltaTime, 0);
    transform.position += moveVector;
}

}
