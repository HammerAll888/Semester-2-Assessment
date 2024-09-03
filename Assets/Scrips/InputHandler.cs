using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector2 InputVector {  get; private set; } //Will detect the vector thats been inputed

    public Vector3 MousePosition { get; private set; } //Will detect where the mouse position is

     //This will get all the axis', vectors and positions needed for the script
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        InputVector = new Vector2(h, v);

        MousePosition = Input.mousePosition;
    }
}
