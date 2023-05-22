using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    private CharacterController controller;

    private float horizonalMovement;
    private float verticalMovement;
    private Vector3 direction;

    public float turnSmoothTime = 0.1f;  // the amount of time it take to snap from one direction to the next
    private float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementCheck();
    }

    private void MovementCheck()
    {
        // obtain input
        horizonalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizonalMovement, 0, verticalMovement);

        // move the character when there is input
        if (direction.magnitude >= 0.1)
        {
            // calculate players rotation in 3d space
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg; // get the rotaion in 360 degree
            float angle = Mathf.smoothDampAngle(tramsform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion
            controller.Move(direction * speed * Time.deltaTime); // *deltaTime to make it frame rate-indepedent
        }
    }
}
