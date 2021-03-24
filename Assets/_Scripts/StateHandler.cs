using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public abstract class StateHandler : MonoBehaviour
{

    sealed public class Direction {

        public const string Left = "Left";
        public const string Right = "Right";
        public const string Up = "Up";
        public const string Down = "Down";
        public const string Forward = "Forward";
        public const string Back = "Back";
    }
    public abstract void StartHandler();

    public abstract void StopHandler();

    

}
