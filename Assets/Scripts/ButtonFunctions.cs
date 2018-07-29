using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void EnableGameObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void DisableGameObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenUrl(string url)
    {
        Application.OpenURL(url);
    }

    public void ChangeShopName(Text nameField)
    {
        PlayerInfo.Instance.UpdateShopName(nameField.text);
    }
}
