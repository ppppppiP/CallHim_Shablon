using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FlappyBirdInstaller : MonoInstaller
{
    [SerializeField] LocalGameManager gameManager;
    public override void InstallBindings()
    {
        Container.Bind<LocalGameManager>().FromInstance(gameManager).AsSingle().NonLazy();
       
    }
}
