using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAction;
        public void StartAction(IAction action){
            if(currentAction == action) return;
            if( currentAction != null){
                print("Cancelando a acao "+currentAction);
                currentAction.Cancel();
            }
            currentAction = action;
        }
    }
}