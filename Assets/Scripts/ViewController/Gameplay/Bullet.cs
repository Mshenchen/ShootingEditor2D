using UnityEngine;
using FrameworkDesign;
namespace ShootingEditor2D
{
    public class Bullet : ShootingEditor2DController
    {
        private Rigidbody2D mRigidbody2D;
        private void Awake()
        {
            mRigidbody2D = GetComponent<Rigidbody2D>();
            Destroy(gameObject, 5f);
        }
        // Use this for initialization
        void Start()
        {
            var isRight = Mathf.Sign(transform.lossyScale.x);
            mRigidbody2D.velocity = Vector2.right * 10 * isRight;
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                this.SendCommand<KillEnemyCommand>();
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}

