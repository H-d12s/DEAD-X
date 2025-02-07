using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newgamemanager : MonoBehaviour
{ [SerializeField]private float timeToWait;
   public void OnplayerDied()
   {
        Invoke(nameof(Restartlevel),timeToWait);
   }
   public void Restartlevel()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
