using System;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private IMovement moveControl;

    public void Initialize(IMovement moveControl)
    {
        this.moveControl = moveControl;
    }

    private void Update()
    {
        getInput();
    }

    private void getInput()
    {
        float dirX = joystick.Horizontal;
        float dirZ = joystick.Vertical;
      
        moveControl.OnMove(new Vector3 (dirX,0, dirZ));

    }
}