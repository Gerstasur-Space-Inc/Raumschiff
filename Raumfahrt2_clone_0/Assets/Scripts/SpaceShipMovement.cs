using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SpaceShipMovement : MonoBehaviour
{

    //https://www.youtube.com/watch?v=8VVgIjWBXks
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float activeforwardSpeed , activeStrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

    public float yawSpeed = 20f, yawAcceleration = 1.2f;
    private float activeYawSpeed, yawInput;
    public float lookrateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    private float rollInput;
    public float rollSpeed = 60f, rollAcceleration = 3.5f;

    public Camera mainCam;
    public Camera playerCam;

    public GameObject projectile;

    private void Start()
    {
        mainCam.enabled = false;
        playerCam.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
       Move( new MovementInputs(Input.GetAxisRaw("Roll"), Input.GetAxisRaw("Hover"), Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Yaw"), Screen.width, Screen.height));


    }

    private void Move(MovementInputs inputs)
    {
        
        

        rollInput = Mathf.Lerp(rollInput, inputs.rollInput, rollAcceleration * Time.deltaTime);

        // transform.Rotate(-mouseDistance.y * lookrateSpeed * Time.deltaTime, mouseDistance.x * lookrateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);


        yawInput = inputs.Yaw * 2;
        activeYawSpeed = Mathf.Lerp(activeYawSpeed, yawInput * yawSpeed, yawAcceleration * Time.deltaTime);
        transform.Rotate(0, activeYawSpeed * Time.deltaTime , rollInput * rollSpeed * Time.deltaTime, Space.Self);
        
        activeforwardSpeed = Mathf.Lerp(activeforwardSpeed, inputs.verticalInput * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, inputs.horizontalInput * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, inputs.hoverInput * hoverSpeed, hoverAcceleration * Time.deltaTime);

        transform.position += transform.forward * activeforwardSpeed * Time.deltaTime + transform.right * activeStrafeSpeed * Time.deltaTime + transform.up * activeHoverSpeed * Time.deltaTime;

      
    }

 //run on server, called on client

    #region Commands

  
    #endregion
}
