using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectAndEnd : MonoBehaviour
{
    #region Variables
    public string detectTag = "Player";
    
    bool detected = false;
    #endregion

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag(detectTag) && !detected) {
            detected = true;
            RestartGame();
        }
    }

    void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
