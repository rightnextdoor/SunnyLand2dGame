using UnityEngine;
using UnityEngine.UI;

public class CherryCount : MonoBehaviour
{
    private int totalCherry = 0;
    private static int cherryCollect = 0;
    private static bool allCherry = false;
   
    public Text countText;
    
    private void Start()
    {
       totalCherry = GameObject.FindGameObjectsWithTag("Cherry").Length;
        
    }

    private void Update()
    {
        countText.text = cherryCollect.ToString("00") + " / " + totalCherry.ToString("00");

        if (cherryCollect == totalCherry)
            allCherry = true;
    }

    public static void ResetCherryCount() {
        cherryCollect = 0;
    }

    public void CherryCollected() {
        cherryCollect++;
        
    }

    public static bool AllCherryCollected() {
        return allCherry;
    }

}
