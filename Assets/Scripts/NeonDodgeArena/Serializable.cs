namespace Ithiel
{
  public enum NoteKey
  {
  Left,
  Right,
  Up,
  Down
  }

  [System.Serializable]
  public class NotesData
  {

    public NoteKey key;
    public float floatTime;
  }
}
    

