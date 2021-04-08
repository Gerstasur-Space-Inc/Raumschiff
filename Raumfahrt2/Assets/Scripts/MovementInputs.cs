using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInputs 
{
    public float rollInput {  get; set; }
    public float horizontalInput { get; set; }
    public float verticalInput { get; set; }
    public float hoverInput { get; set; }
    public Vector2 mousePosition { get; set; }
    public Vector2 lookInput { get; set; }
    public float Yaw { get; set; }
    public float screenWidth { get; set; }
    public float screenHeight { get; set; }

    public MovementInputs() { }
    public MovementInputs(float _rollInput, float _horizontalInput, 
        float _verticalInput, float _hoverInput, float _Yaw, 
        float _screenWidth, float _screenHeight ) 
    {
        rollInput = _rollInput;
        horizontalInput = _horizontalInput;
        verticalInput = _verticalInput;
        hoverInput = _hoverInput;
        Yaw = _Yaw;
        screenWidth = _screenWidth;
        screenHeight = _screenHeight;


    }

  
}
