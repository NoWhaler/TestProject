using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Main.Scripts.UI
{
    public class PlayButtonView : MonoBehaviour
    {
        private Button _playButton;

        private void Awake()
        {
            _playButton = GetComponentInChildren<Button>();
        }

        private void Start()
        {
            var nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            
            _playButton.onClick.AddListener(() => 
                SceneManager.LoadScene(nextSceneIndex));
        }
    }
}