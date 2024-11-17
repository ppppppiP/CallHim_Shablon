using Zenject;
using UnityEngine;
public class GameInstaller: MonoInstaller
{
    [SerializeField] Reward RewardCanvas;
    [SerializeField] Scores scores;
    public override void InstallBindings()
    {
       
        Container.Bind<Scores>().FromInstance(scores);
        Container.Bind<Reward>().FromInstance(RewardCanvas);
        Container.Bind<VideoManager>().FromNew();
    }

}

