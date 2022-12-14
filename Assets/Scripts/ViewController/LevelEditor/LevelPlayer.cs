using System.Xml;
using UnityEngine;

namespace ShootingEditor2D
{
    public class LevelPlayer : MonoBehaviour
    {
        public TextAsset LevelFile;
        private void Start()
        {
            var xml = LevelFile.text;
            var document = new XmlDocument();
            document.LoadXml(xml);
            var levelNode = document.SelectSingleNode("Level");
            foreach (XmlElement levelItemNode in levelNode.ChildNodes)
            {
                var levelItemName = levelItemNode.Attributes["name"].Value;
                var levelItemX = int.Parse(levelItemNode.Attributes["x"].Value);
                var levelItemY = int.Parse(levelItemNode.Attributes["y"].Value);
                var levelItemPrefab = Resources.Load<GameObject>(levelItemName);
                var levelItemGameObj = Instantiate(levelItemPrefab, transform);
                levelItemGameObj.transform.position = new Vector3(levelItemX, levelItemY, 0);
            }
        }
    }
}

