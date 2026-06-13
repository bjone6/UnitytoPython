using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class PythonBridge : MonoBehaviour
{
	public void SendStringToPython(string message)
	{
		StartCoroutine(PostMessage(message));
	}

	IEnumerator PostMessage(string message)
	{
		string url = "http://127.0.0.1:5000/send";
		string json = "{\"message\":\"" + message + "\"}";

		using UnityWebRequest request = new UnityWebRequest(url, "POST");
		byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

		request.uploadHandler = new UploadHandlerRaw(bodyRaw);
		request.downloadHandler = new DownloadHandlerBuffer();
		request.SetRequestHeader("Content-Type", "application/json");

		yield return request.SendWebRequest();

		if (request.result == UnityWebRequest.Result.Success)
		{
			Debug.Log("Python replied: " + request.downloadHandler.text);
		}
		else
		{
			Debug.LogError(request.error);
		}
	}
}
