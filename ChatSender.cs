using TMPro;
using UnityEngine;

public class ChatSender : MonoBehaviour
{
	public TMP_InputField inputField;
	public PythonBridge bridge;

	public void SendChat()
	{
		bridge.SendStringToPython(inputField.text);
	}
}
