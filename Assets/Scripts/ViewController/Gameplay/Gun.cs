using UnityEngine;
using FrameworkDesign;
namespace ShootingEditor2D
{
    public class Gun : MonoBehaviour, IController
    {
        private Bullet mBullet;
        private GunInfo mGunInfo;
        void Awake()
        {
            mBullet = transform.Find("Bullet").GetComponent<Bullet>();
            mGunInfo = this.GetSystem<IGunSystem>().CurrentGun;
        }

        public void Shoot()
        {
            if (mGunInfo.BulletCountInGun.Value > 0 && mGunInfo.GunState.Value == GunState.Idle)
            {
                var bullet = Instantiate(mBullet, mBullet.transform.position, mBullet.transform.rotation);
                bullet.transform.localScale = mBullet.transform.lossyScale;
                bullet.gameObject.SetActive(true);
                this.SendCommand(ShootCommand.Single);
            }

        }
        private void OnDestroy()
        {
            mGunInfo = null;
        }
        public IArchitecture GetArchitecture()
        {
            return ShootingEditor2D.Interface;
        }
    }
}

