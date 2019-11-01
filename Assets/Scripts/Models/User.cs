using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    private string mAccount { get; set; }
    private string mPassword { get; set; }
    private double mLastLogin { get; set; }
    public bool mNeedLogin { get; private set; } = true;

    //加载本地账号数据，只有当账号数据符合标准mNeedLogin为false,否则为true
    public void Load()
    {
        string loadStr = PlayerPrefs.GetString("DOS_ACCOUNT_DATA");
        if (string.IsNullOrWhiteSpace(loadStr))
        {
            mNeedLogin = true;
            return;
        }
    }
    public void ChangePassword()
    {

    }
    //登录请求
    public void Login(string account,string password)
    {

    }

}
