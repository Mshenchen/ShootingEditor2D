using UnityEngine.SceneManagement;
using UnityEngine;

namespace ShootingEditor2D 
{
    public class NextLevel : MonoBehaviour
    {
        public string LevelName;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene(LevelName);
            }
        }
    }

}
