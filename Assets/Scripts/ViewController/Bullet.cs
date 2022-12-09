using UnityEngine;
using FrameworkDesign;
namespace ShootingEditor2D
{
    public class Bullet : MonoBehaviour, IController
    {
        private Rigidbody2D mRigidbody2D;
        private void Awake()
        {
            mRigidbody2D = GetComponent<Rigidbody2D>();
        }
        // Use this for initialization
        void Start()
        {
            mRigidbody2D.velocity = Vector2.right * 10;
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                this.SendCommand<KillEnemyCommand>();
                Destroy(other.gameObject);
            }
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditor2D.Interface;
        }
    }
}

