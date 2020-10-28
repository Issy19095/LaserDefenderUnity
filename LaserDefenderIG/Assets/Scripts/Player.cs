using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //moves the player ship
    private void Move()
    {
        //var changes its variable type according on what i save in it
        //deltaX will have the difference in the x-axis which the Player moves
        var deltaX = Input.GetAxis("Horizontal");
        //newXPos = current x-pos + difference in x
        var newXPos = transform.position.x + deltaX;

        


        //to move on the y-axis:
        var deltaY = Input.GetAxis("Vertical");
        var newYPos = transform.position.y + deltaY;

        this.transform.position = new Vector2(newXPos, newYPos);
    }
}
