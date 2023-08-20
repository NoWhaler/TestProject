using System.Collections;
using Main.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main.Scripts
{
    public class LoadingScene : MonoBehaviour
    {
        private int _nextSceneIndex;
        private ProgressBar _progressBar;
        
        public Transform[] preloadContainer;

        private void Awake()
        {
            _nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            _progressBar = FindObjectOfType<ProgressBar>();
        }

        private void Start()
        {
            StartCoroutine(LoadSceneCo());
        }

        private IEnumerator LoadSceneCo()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(_nextSceneIndex);

            operation.allowSceneActivation = false;

            yield return new WaitForSecondsRealtime(2f);
            
            PreloadPrefabs();
            
            while (!operation.isDone)
            {
                _progressBar.UpdateFraction(operation.progress);
                
                operation.allowSceneActivation = true;
                
                yield return null;
            }
        }

        private void PreloadPrefabs()
        {
            if (preloadContainer == null) return;
            
            foreach (var child in preloadContainer)
            {
                Instantiate(child.gameObject);
            }
        }
    }
}