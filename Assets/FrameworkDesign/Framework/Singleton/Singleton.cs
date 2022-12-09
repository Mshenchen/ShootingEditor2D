using System;
using System.Reflection;
using UnityEngine;
namespace FrameworkDesign
{
    public class Singleton<T> where T : Singleton<T>
    {
        private static T mInstance;
        public static T Instance
        {
            get
            {
                if (mInstance == null)
                {
                    var type = typeof(T);
                    // ͨ�������ȡ����
                    var ctors = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                    // ��ȡ�޲η� public �Ĺ���
                    var ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
                    if (ctor == null)
                    {
                        throw new Exception("Non Public Constructor Not Fount in " + type.Name);
                    }
                    mInstance = ctor.Invoke(null) as T;
                }
                return mInstance;
            }
        }
    }
}


