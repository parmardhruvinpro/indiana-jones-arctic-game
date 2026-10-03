using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int collectedRelics;
    private int totalRelics;
    private bool gameWon;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void RegisterRelicCount(int count)
    {
        totalRelics = count;
    }

    public void CollectRelic(RelicPickup relic)
    {
        if (gameWon)
        {
            return;
        }

        collectedRelics++;

        if (collectedRelics >= totalRelics)
        {
            gameWon = true;
        }
    }

    private void OnGUI()
    {
        GUIStyle labelStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = 22,
            normal = { textColor = Color.white }
        };

        GUIStyle winStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = 30,
            fontStyle = FontStyle.Bold,
            normal = { textColor = new Color(0.95f, 0.85f, 0.3f) }
        };

        GUI.Label(new Rect(20f, 20f, 400f, 30f), $"Relics: {collectedRelics}/{totalRelics}", labelStyle);

        if (gameWon)
        {
            GUI.Label(new Rect(Screen.width * 0.5f - 220f, Screen.height * 0.4f, 440f, 80f), "The Arctic secret is yours!", winStyle);
        }
    }
}
