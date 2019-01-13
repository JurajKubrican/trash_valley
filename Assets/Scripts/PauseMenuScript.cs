using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class PauseMenuScript : MonoBehaviour
    {
        public List<GameObject> menus = new List<GameObject>();
        private GameObject panel;
        public bool isPause = false;

        void Start()
        {
            

            panel = gameObject.transform.Find("Panel").gameObject;
            foreach (Transform child in panel.transform)
            {
                Debug.Log(child.name);
                menus.Add(child.gameObject);
            }
            hidePanel();
            panel.SetActive(false);
        }

        void Update()
        {
            if (Input.GetKeyDown("escape") )
            {
                if (panel.activeSelf && isPause)
                    Resume();
                else
                    Pause();
            }
        }


        public void Resume()
        {
            hidePanel();
        }


        public void Restart()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        public void NextLevel()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


        public void Exit()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }


        private void showPanel(int index)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
            menus[index].SetActive(true);
        }


        private void hidePanel()
        {
            Time.timeScale = 1;
            isPause = false;
            panel.SetActive(false);
            foreach (var moveT in menus)
                moveT.SetActive(false);
        }


        public void Pause()
        {
            isPause = true;
            showPanel(0);
        }


        public void Die()
        {
            showPanel(1);
        }


        public void Win()
        {
            showPanel(2);
        }
    }
}