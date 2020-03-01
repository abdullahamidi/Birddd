using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float acc;
    public float maxSpeed;

    private Rigidbody rigidBody;
    private KeyCode[] keyCodes;
    private Vector3[] directions; 
    // Start is called before the first frame update
    void Start()
    {
        keyCodes = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
        directions = new Vector3[] { Vector3.forward, Vector3.left, Vector3.back, Vector3.right };
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            var key = keyCodes[i];
            if (Input.GetKey(key))
            {
                Vector3 movement = directions[i] * acc * Time.deltaTime;
                movePlayer(movement);
            }
        }

    }

        void movePlayer(Vector3 movement)
    {
        if (rigidBody.velocity.magnitude * acc > maxSpeed)
        {
            rigidBody.AddForce(movement * -1);
        }
        else
        {
            rigidBody.AddForce(movement);
        }
    }
}
