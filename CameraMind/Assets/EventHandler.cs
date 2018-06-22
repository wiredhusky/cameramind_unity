using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour {

    public delegate void MovementHandler();

    public static event MovementHandler OnMove;
	
}
