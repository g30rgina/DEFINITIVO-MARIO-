using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ChangeScene(string nombreescena)
    {
        SceneManager.LoadScene(nombreescena);
    }
    //forma de llamar la funcion change.scene a traves de codigo
    void test()
    {
        ChangeScene("escena inicial");
    }
}
