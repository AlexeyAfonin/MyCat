using System.Collections;
using UnityEngine;
using MyCat.Core.Util;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

namespace MyCat.UI
{
    public class SceneLoader : MonobehSingleton<SceneLoader>
    {
        [Header("Parameters")]
        [SerializeField] private bool isLoadNextSceneWithStart = false;
        [Header("UI")]
        [SerializeField] private CanvasGroup loadScreen;
        [SerializeField] private Image loadCircle;
        [SerializeField] private Image progressCircle;

        private AsyncOperation _loadingSceneOperation;

        public string NameCurrentScene => SceneManager.GetActiveScene().name;

        private void Start()
        {
            if (isLoadNextSceneWithStart)
            {
                LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        public void LoadScene(int indexScene)
        {
            Time.timeScale = 1;
            Instance._loadingSceneOperation = SceneManager.LoadSceneAsync(indexScene, LoadSceneMode.Single);
            StartCoroutine(LoadSceneCoroutine());
        }

        public void LoadScene(string nameScene)
        {
            Time.timeScale = 1;
            Instance._loadingSceneOperation = SceneManager.LoadSceneAsync(nameScene, LoadSceneMode.Single);
            StartCoroutine(LoadSceneCoroutine());
        }

        private IEnumerator LoadSceneCoroutine()
        {
            ShowScreen();

            loadCircle.gameObject.SetActive(true);
            progressCircle.fillAmount = 0f;
            while (!_loadingSceneOperation.isDone)
            {
                yield return progressCircle.DOFillAmount(Mathf.Clamp01(_loadingSceneOperation.progress / 0.9f), 0.1f).WaitForCompletion();
            }
            loadCircle.gameObject.SetActive(false);

            HideScreen();
        }

        private void ShowScreen()
        {
            loadScreen.alpha = 1;
            loadScreen.interactable = true;
            loadScreen.blocksRaycasts = true;
        }

        private void HideScreen()
        {
            loadScreen.alpha = 0;
            loadScreen.interactable = false;
            loadScreen.blocksRaycasts = false;
        }
    }
}