using UnityEngine.UI;
using System;
using UnityEngine;
using FrameworkDesign;

namespace ShootingEditor2D
{
    public class UIController : MonoBehaviour, IController
    {
        private IPlayerModel mPlayerModel;
        private IStatSystem mStatSystem;
        public Text HpText;
        public Text KillNumText;
        void Awake()
        {
            mPlayerModel = this.GetComponent<IPlayerModel>();
            mStatSystem = this.GetSystem<IStatSystem>();
            Debug.Log("ww");
            // HpText = transform.Find("HPText").GetComponent<Text>();
            // KillNumText = transform.Find("killCountText").GetComponent<Text>();
        }
        private void Update()
        {
            Debug.Log("fgg");
            HpText.text = "生命：" + (int)mPlayerModel.HP.Value;
            KillNumText.text = "击杀数：" + (int)mStatSystem.killCount.Value;
        }
        // private readonly Lazy<GUIStyle> mLabelStyle = new Lazy<GUIStyle>(() => new GUIStyle(GUI.skin.label)
        // {
        //     fontSize = 40
        // });
        // private void OnGUI()
        // {
        //     GUI.Label(new Rect(10, 10, 300, 100), $"生命：{mPlayerModel.HP.Value}/3");
        //     GUI.Label(new Rect(Screen.width - 10 - 300, 10, 300, 100), $"击杀数：{mStatSystem.killCount.Value}");
        // }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditor2D.Interface;
        }
    }
}

