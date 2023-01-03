using UnityEngine;
using FrameworkDesign;
namespace ShootingEditor2D
{
    public class ShootingEditor2DController:MonoBehaviour,IController
    {
        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return ShootingEditor2D.Interface;
        }
    }
}
