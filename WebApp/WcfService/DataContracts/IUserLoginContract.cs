namespace WcfService.DataContracts
{
    public interface IUserLoginContract
    {
        string Password { get; set; }
        string Username { get; set; }
        string Rank { set; get; }

        User ToUser();

    }
}