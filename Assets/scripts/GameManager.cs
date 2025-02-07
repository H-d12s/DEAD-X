using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{[SerializeField]private float timeToWait;
   public void OnplayerDied()
   {
        Invoke(nameof(Endgame),timeToWait);
   }
   private void Endgame()
   {
        SceneManager.LoadScene("MainMenu");
   }
}
