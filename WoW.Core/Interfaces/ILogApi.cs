namespace WoW.Core.Interfaces
{
    public interface ILogApi
    {
        string GetCharacterProfile(string characterName, string server, string region);
    }
}