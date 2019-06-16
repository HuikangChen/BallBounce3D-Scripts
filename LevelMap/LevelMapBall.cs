using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMapBall : MonoBehaviour
{
    [SerializeField] private RaycastCollisionDetection collisionDetection;
    [SerializeField] private BallBounce ballBounce;
    [SerializeField] private BallPhysics ballPhysics;

    private Transform ground; //The ground we detect with raycast

    private void Start()
    {
        collisionDetection.Init();

        ////Kinematics equations, gravity needs to be calculated based on the specified jump height and time it takes to get there 
        ballPhysics.CalculateGravity(ballBounce.bounceHeight, ballBounce.timeToApex);

        //////Next jump velocity is calculated based on the previously calculated gravity
        ballBounce.Init(ballPhysics.gravity);
    }

    private void FixedUpdate()
    {
        collisionDetection.CastRayCast();

        /* Since we are applying gravity constantly with our own physics, 
         * we want to check if raycast hit anything, then we set the velocity.y back to 0, 
           so our ball don't fall through the platform. 
           We don't want to set velocity.y to 0 when bouncing, or else the ball won't bounce */
        ballPhysics.ApplyVerticalCollision(collisionDetection);

        if (collisionDetection.collidedObject != null) // If our raycast system detects something
        {
            ground = collisionDetection.collidedObject.transform; // Set the ground variable to the detected gameobject 
        }

        // If raycast hits something, we want the ball to bounce up 
        if (collisionDetection.hasCollided)
        {
            ballBounce.Bounce(ref ballPhysics.velocity);
            HapticFeedback.Generate(UIFeedbackType.ImpactMedium);
            if (ground.GetComponent<Brick>() != null)
            {
                ground.GetComponent<Brick>().CallJiggle();
            }
        }
        ballPhysics.ApplyPhysics(transform);
    }
}
