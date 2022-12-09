using UnityEngine;

namespace ShootingEditor2D
{
    public class Gun : MonoBehaviour
    {
        private Bullet mBullet;
        void Awake()
        {
            mBullet = transform.Find("Bullet").GetComponent<Bullet>();
        }

        public void Shoot()
        {
            var bullet = Instantiate(mBullet, mBullet.transform.position, mBullet.transform.rotation);
            bullet.transform.localScale = mBullet.transform.lossyScale;
            bullet.gameObject.SetActive(true);
        }
    }
}

