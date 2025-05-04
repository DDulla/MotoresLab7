using UnityEngine;

[CreateAssetMenu(fileName = "RoomAudioSO", menuName = "Scriptable Objects/Game Systems/Audio/Room Audio")]
public class RoomAudioSettings : ScriptableObject
{
    [SerializeField] private AudioClip roomMusic;
    [SerializeField] private string roomName;

    public AudioClip RoomMusic => roomMusic;
    public string RoomName => roomName;
}