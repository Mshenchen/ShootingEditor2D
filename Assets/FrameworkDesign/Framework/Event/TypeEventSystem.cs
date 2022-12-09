using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FrameworkDesign 
{
    public interface ITypeEventSystem
    {
        void Send<T>() where T : new();
        void Send<T>(T e);
        IUnRegister Register<T>(Action<T> onEvent);
        void UnRegister<T>(Action<T> onEvent);
    }
    public interface IUnRegister
    {
        void UnRegister();
    }
    public struct TypeEventSystemUnRegister<T> : IUnRegister
    {
        public ITypeEventSystem TypeEventSystem;
        public Action<T> OnEvent;
        public void UnRegister()
        {
            TypeEventSystem.UnRegister<T>(OnEvent);
            TypeEventSystem = null;
            OnEvent = null;
        }
    }
    public class UnRegisterOnDestoryTrigger : MonoBehaviour 
    {
        private HashSet<IUnRegister> mUnRegisters = new HashSet<IUnRegister>();
        public void AddUnRegister(IUnRegister unRegister)
        {
            mUnRegisters.Add(unRegister);
        }
        private void OnDestroy()
        {
            foreach (var unRegister in mUnRegisters)
            {
                unRegister.UnRegister();
            }
            mUnRegisters.Clear();
        }
    }
    public static class UnRegisterExtension
    {
        public static void UnRegisterWhenGameObjectDestoryed(this IUnRegister unRegister, GameObject gameObject)
        {
            var trigger = gameObject.GetComponent<UnRegisterOnDestoryTrigger>();
            if (!trigger)
            {
                trigger = gameObject.AddComponent<UnRegisterOnDestoryTrigger>();
            }
            trigger.AddUnRegister(unRegister);
        }
    }

    public class TypeEventSystem : ITypeEventSystem
    {
        public interface IRegisterations
        {

        }
        public class Registerations<T> : IRegisterations
        {
            public Action<T> OnEvent = e => { };
        }
        private Dictionary<Type, IRegisterations> mEventRegistration = new Dictionary<Type, IRegisterations>();
        public IUnRegister Register<T>(Action<T> onEvent)
        {
            var type = typeof(T);
            IRegisterations registerations;
            if (mEventRegistration.TryGetValue(type, out registerations))
            {

            }
            else
            {
                registerations = new Registerations<T>();
                mEventRegistration.Add(type, registerations);
            }
            (registerations as Registerations<T>).OnEvent += onEvent;
            return new TypeEventSystemUnRegister<T>()
            {
                OnEvent = onEvent,
                TypeEventSystem = this
            };
        }   

        public void Send<T>() where T : new()
        {
            var e = new T();
            Send<T>(e);
        }

        public void Send<T>(T e)
        {
            var type = typeof(T);
            IRegisterations registerations;
            if (mEventRegistration.TryGetValue(type, out registerations))
            {
                (registerations as Registerations<T>).OnEvent(e);
            }
        }

        public void UnRegister<T>(Action<T> onEvent)
        {
            var type = typeof(T);
            IRegisterations registerations;
            if (mEventRegistration.TryGetValue(type, out registerations))
            {
                (registerations as Registerations<T>).OnEvent -= onEvent;
            }
        }
    }
}

