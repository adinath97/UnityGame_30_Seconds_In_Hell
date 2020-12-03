using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy_Player : MonoBehaviour
{
    public GameObject playerTank;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PleaseDestroy();
    }

    public void PleaseDestroy()
    {
        if (Move_Player_Tank.playerDead == true)
        {
            Debug.Log("Destroy please");
            Destroy(playerTank);
            StartCoroutine(WaitAndLoad());
        }
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GAME_OVER_YOU_LOST");
    }
}
