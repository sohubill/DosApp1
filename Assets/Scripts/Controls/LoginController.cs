
public class LoginController
{
    private static LoginController instance;
    public static LoginController Instance 
    {
        get
        {
            if (instance==null)
            {
                instance = new LoginController();
            }
            return instance;
        }
    }
    private static User mUser { get; } = new User();
    public bool mNeedLoginPage
    {
        get
        {
            mUser.Load();
            return mUser.mNeedLogin;
        }
    }

    
}
