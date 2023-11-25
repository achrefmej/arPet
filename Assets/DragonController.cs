using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float speed;
    private FixedJoystick fixedJoystick;
    private Rigidbody rigidbody;
    private Animator dragonAnimator;

    private void OnEnable()
    {
        fixedJoystick = FindObjectOfType<FixedJoystick>();
        rigidbody = GetComponent<Rigidbody>();
        dragonAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float xVal = fixedJoystick.Horizontal;
        float yVal = fixedJoystick.Vertical;
        Vector3 movement = new Vector3(xVal, 0, yVal);
        rigidbody.velocity = movement * speed;

        if (movement.magnitude > 0)
        {
            // When moving, set the IsWalking bool to true
            dragonAnimator.SetBool("IsWalking", true);

            // Set rotation towards the movement direction
            if (xVal != 0 && yVal != 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg, transform.eulerAngles.z);
            }
        }
        else
        {
            // When not moving, set the IsWalking bool to false
            dragonAnimator.SetBool("IsWalking", false);
        }
    }
}
