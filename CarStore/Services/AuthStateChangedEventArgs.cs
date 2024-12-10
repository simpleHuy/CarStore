namespace CarStore.Services;
public class AuthStateChangedEventArgs : EventArgs
{
    public bool IsAuthenticated
    {
        get;
    }


    public AuthStateChangedEventArgs(bool isAuthenticated)
    {
        IsAuthenticated = isAuthenticated;
    }
}