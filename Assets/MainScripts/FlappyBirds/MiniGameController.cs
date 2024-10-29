using UnityEngine;
using Zenject;

public class MiniGameController: MonoBehaviour
{
    [SerializeField] GameObject MiniGame;
    private GameObject currentMiniGame;
    [Inject] DiContainer container;
    

    public static MiniGameController instance;

    private void Awake()
    {
        instance = this;
        currentMiniGame = container.InstantiatePrefab(MiniGame, transform.position, transform.rotation, null);
    }
    public void ReloadGame()
    {
        Destroy(currentMiniGame);
        currentMiniGame = container.InstantiatePrefab(MiniGame, transform.position, transform.rotation, null);
    }
    
} 
