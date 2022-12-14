using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingEditor2D.Tests
{
    public class TimeSystemTest : MonoBehaviour
    {
        void Start()
        {
            Debug.Log(Time.time);
            ShootingEditor2D.Interface.GetSystem<ITimeSystem>().AddDelayTask(3, () =>
            {
                Debug.Log(Time.time);
            });
        }
    }
}

