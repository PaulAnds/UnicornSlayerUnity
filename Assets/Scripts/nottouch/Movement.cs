using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //gets the character controller of the player
    public CharacterController controller;

    //How fast the player will go
    public float speed = 12f;
    //player health
    public int health = 3;

    public float gravity = -25f;

    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        //if the velocity is less than 0, stops the velocity
        if (velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        //if one touches a d
        float x = Input.GetAxis("Horizontal");
        //if one touches  w s
        float z = Input.GetAxis("Vertical") ;

        //make it rotate 45% for the isometric movement
        var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

        //vector move. move right * a d    + move foward * w x
        Vector3 move = transform.right * x + transform.forward * z;
        
        //multiplies the rotation to the movement
        var skewedInput = matrix.MultiplyPoint3x4(move);

        //time.deltaTime is added to make sure one moves based on time and not frames
        controller.Move(skewedInput * speed * Time.deltaTime);

        //velocity of y is added with the multi of gravity and time
        velocity.y += gravity * Time.deltaTime;

        //player can move with addition to the velocity it ones had and the time again
        controller.Move(velocity * Time.deltaTime);
    }


}
