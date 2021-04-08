using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : NetworkBehaviour
{
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float activeforwardSpeed = 0.001f, activeStrafeSpeed= 0.001f, activeHoverSpeed= 0.001f;
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

    public float yawSpeed = 25f, yawAcceleration = 2f;
    private float activeYawSpeed, yawInput;
    public float lookrateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    private Vector2 mouseDelta;
    private Vector2 mouseNew;
    private Vector2 mouseOld;

    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;

    #region Server

    [Command] private void Cmdmove(MovementInputs inputs)
    {


        /* mouseDistance.x = (lookInput.x - inputs.screenWidth / 2) / inputs.screenHeight / 2;
         mouseDistance.y = (lookInput.y - inputs.screenHeight / 2) / inputs.screenHeight / 2;
        */
     


        //mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);
        mouseDelta = Vector2.ClampMagnitude(mouseDelta, 1f);

        rollInput = Mathf.Lerp(rollInput, inputs.rollInput, rollAcceleration * Time.deltaTime);

        // transform.Rotate(-mouseDistance.y * lookrateSpeed * Time.deltaTime, mouseDistance.x * lookrateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(-mouseDelta.y * lookrateSpeed * Time.deltaTime, mouseDelta.x * lookrateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        yawInput = inputs.Yaw;
        activeYawSpeed = Mathf.Lerp(activeYawSpeed, yawInput * yawSpeed, yawAcceleration * Time.deltaTime);
        transform.Rotate(0,activeYawSpeed * Time.deltaTime,0);
        activeforwardSpeed = Mathf.Lerp(activeforwardSpeed, inputs.verticalInput * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, inputs.horizontalInput * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, inputs.hoverInput * hoverSpeed, hoverAcceleration * Time.deltaTime);

        transform.position += transform.forward * activeforwardSpeed * Time.deltaTime + transform.right * activeStrafeSpeed * Time.deltaTime + transform.up * activeHoverSpeed * Time.deltaTime;
      
        mouseOld = mouseNew;
    }
    #endregion


    #region Client
    [ClientCallback]
    private void Start()
    {
        screenCenter.x = Screen.width / 2;
        screenCenter.y = Screen.height / 2;

        Cursor.lockState = CursorLockMode.Locked;
    }

    [ClientCallback]
    private void Update()
    {
        if (!hasAuthority) { return; }
        Cmdmove(Move());
    }

    private MovementInputs Move()
    {
        return new MovementInputs(Input.GetAxisRaw("Roll"), Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Hover"), Input.GetAxisRaw("Yaw"), Screen.width, Screen.height);
    }
    #endregion
}

