using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign
{
    public interface IModel : IBelongToArchitecture, ICanSetArchitecture, ICanGetUtility, ICanSendEvent
    {

        void Init();
    }
    public abstract class AbstractModel : IModel
    {
        private IArchitecture mArchitecturel;
        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return mArchitecturel;
        }
        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
        {
            mArchitecturel = architecture;
        }

        void IModel.Init()
        {
            OnInit();
        }
        protected abstract void OnInit();

    }
}

