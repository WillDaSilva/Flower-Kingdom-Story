using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerController : MonoBehaviour {
    GroundCheck groundCheck;
    Transform player;
    Rigidbody rigidBody;
    PlayerController playerController;
    void Awake()
    {
        groundCheck = GetComponent<GroundCheck>();
        rigidBody = GetComponent<Rigidbody>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        player = playerController.transform;
    }
    Vector3 displacementToPlayer;
    Vector3 directionToPlayer;
    float distanceToPlayer;
    void FixedUpdate()
    {
        displacementToPlayer = new Vector3(player.position.x - transform.position.x, 0, player.position.z - transform.position.z);
        directionToPlayer = displacementToPlayer.normalized;
        distanceToPlayer = displacementToPlayer.magnitude;
        if (distanceToPlayer < 1.5f && distanceToPlayer > 1.3f)
        {
            rigidBody.velocity = directionToPlayer * playerController.maxSpeed * Joysticks.LStick.CappedInput.magnitude + rigidBody.velocity.y * Vector3.up;
        }
        if (distanceToPlayer > 1.5f)
        {
            rigidBody.velocity = directionToPlayer * playerController.maxSpeed * distanceToPlayer / 1.5f + rigidBody.velocity.y * Vector3.up;
        }
        else rigidBody.velocity = rigidBody.velocity.y * Vector3.up;
        if (distanceToPlayer > 1.2f && distanceToPlayer < 3f && groundCheck.grounded)
        {
            if (Input.GetButtonDown("Jump"))
                StartCoroutine(StartJumpLater());
        }
        else if (!groundCheck.grounded)
            rigidBody.AddForce(Physics.gravity, ForceMode.Acceleration);
        //print(distanceToPlayer);
    }

    IEnumerator StartJumpLater()
    {
        groundCheck.jumping = true;
        yield return new WaitForSeconds(distanceToPlayer/new Vector3(rigidBody.velocity.x, 0, rigidBody.velocity.z).magnitude);
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, playerController.baseJumpStrength, rigidBody.velocity.z);
    }
}
