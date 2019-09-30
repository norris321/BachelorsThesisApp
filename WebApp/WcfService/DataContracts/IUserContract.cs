namespace WcfService.DataContracts
{
    public interface IUserContract
    {
        int IdUser { get; set; }
        string Rank { get; set; }
        string Username { get; set; }

        User ToUser();
    }
}