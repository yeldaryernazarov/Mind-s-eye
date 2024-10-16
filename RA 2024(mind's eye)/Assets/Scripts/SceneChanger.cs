using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void PlayGame(string GameScene){
        SceneManager.LoadScene(GameScene);
    }
    public void quit(){
        Application.Quit();
        Debug.Log("quir");
    }
}
