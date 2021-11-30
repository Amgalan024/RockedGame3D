using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;

    private void Start()
    {
        startButton.onClick.AddListener(delegate{ SceneManager.LoadSceneAsync(1); });
        settingsButton.onClick.AddListener(delegate { SceneManager.LoadScene(1); });
        exitButton.onClick.AddListener(delegate { Application.Quit(); });
    }

}
