using FrameworkDesign;
using UnityEngine;
namespace ShootingEditor2D
{
    public class AttackPlayer : MonoBehaviour, IController
    {
        public int Hurt = 1;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                this.SendCommand<HurtPlayerCommand>(new HurtPlayerCommand(Hurt));
            }
        }
        public IArchitecture GetArchitecture()
        {
            return ShootingEditor2D.Interface;
        }

    }
}


