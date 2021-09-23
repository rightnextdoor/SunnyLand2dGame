using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    void Start() {
        if (gm == null) {
            gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        }
       
    }

    public void RespawnPlayer() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        CherryCount.ResetCherryCount();
    }

    public static void KillPlayer(PlayerStatus player) {
        Destroy(player.gameObject);
        gm.RespawnPlayer();
    }
}
