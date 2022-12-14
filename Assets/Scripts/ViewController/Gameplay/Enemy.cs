using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingEditor2D
{
    public class Enemy : MonoBehaviour
    {
        private Trigger2DCheck mWallCheck;
        private Trigger2DCheck mFallCheck;
        private Trigger2DCheck mGroundCheck;
        private Rigidbody2D mRigidbody2D;
        void Awake()
        {
            mWallCheck = transform.Find("WallCheck").GetComponent<Trigger2DCheck>();
            mFallCheck = transform.Find("FallCheck").GetComponent<Trigger2DCheck>();
            mGroundCheck = transform.Find("GroundCheck").GetComponent<Trigger2DCheck>();
            mRigidbody2D = GetComponent<Rigidbody2D>();
        }
        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            var scaleX = transform.localScale.x;

            if (mGroundCheck.Triggered && mFallCheck.Triggered && !mWallCheck.Triggered)
            {
                mRigidbody2D.velocity = new Vector2(scaleX * 10, mRigidbody2D.velocity.y);
            }
            else
            {
                // 反转
                var localScale = transform.localScale;
                localScale.x = -scaleX;
                transform.localScale = localScale;
            }

        }
    }

}
