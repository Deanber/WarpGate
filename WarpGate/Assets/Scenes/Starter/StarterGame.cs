using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarterGame : MonoBehaviour
{
    public GameObject text_;
    TextMeshProUGUI text_t;
    int count = 0;
    float time = 0.4f;
    GameObject Servers;
    ServerController sc;
    bool isconnecting = false;
    void Start()
    {
        Servers = null;
        text_t = text_.GetComponent<TextMeshProUGUI>();
        text_t.text = "Loading";
    }
    void Update()
    {
        if (Servers == null)
        {
            Servers = GameObject.Find("Servers");
            sc = Servers.GetComponent<ServerController>();
        }
        isconnecting = sc.isconnected;
        if (isconnecting == true)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                count += 1;
                time = 0.4f;
            }
            switch (count)
            {
                case 0:
                    text_t.text = "Connecting";
                    break;
                case 1:
                    text_t.text = "Connecting.";
                    break;
                case 2:
                    text_t.text = "Connecting..";
                    break;
                case 3:
                    text_t.text = "Connecting...";
                    break;
                case 4:
                    count -= 4;
                    break;
            }
        }
    }
}
