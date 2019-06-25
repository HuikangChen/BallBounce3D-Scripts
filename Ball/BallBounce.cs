using UnityEngine;

namespace BB3D.Ball
{
    /// <summary>
    /// Contains the settings and functionaility to bouncing, can be treated as a jump.
    /// Use this as an object/variable in other monobehaviour scripts
    /// </summary>

    [System.Serializable]
    public class BallBounce
    {
        #region Unity Inspector Fields

        [Tooltip("How high the ball should bounce")]
        [SerializeField]
        private float bounceHeight = 10f;

        [Tooltip("How long should it take for the ball to get to bounceHeight")]
        [SerializeField]
        private float timeToApex = 0.3f;

        #endregion
  
        private float bounceVelocity; //Bounce Velocity is being calculated on start with gravity and timeToApex

        #region Properties
        public float BounceHeight { get => bounceHeight; }
        public float TimeToApex { get => timeToApex;  }
        public float BounceVelocity { get => bounceVelocity; set => bounceVelocity = value; }
        #endregion

        /// <summary>
        /// Initializes the bounceVelovity by calculating it with the gravity
        /// </summary>
        /// <param name="gravity">The gravity needed to calculate the bounceVelocity</param>
        public void Init(float gravity)
        {
            ////Next jump velocity is calculated based on the previously calculated gravity
            BounceVelocity = Mathf.Abs(gravity) * TimeToApex;
        }

        /// <summary>
        /// Sets the movement vector's y to bounceVelocity
        /// </summary>
        /// <param name="velocity">The movement vector</param>
        public void Bounce(ref Vector3 velocity)
        {
            velocity.y = BounceVelocity;
        }

    }
}