using ProjectTeamFour.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace ProjectTeamFour.Service
{
    public class PasswordService
    {
        //    private MemberService _memberservice;

        //    public PasswordService()
        //    {
        //        _memberservice = new MemberService();
        //    }

        //    //SaltSize 鹽長 HashSize Hash長 HashIter 迭代
        //    const int SaltSize = 16  , HashSize = 20, HashIter = 10000;
        //    byte[] _salt, _hash;


        //    //做 salt
        //    public byte[] MakeSalt()
        //    {
        //        new RNGCryptoServiceProvider().GetBytes(_salt = new byte[SaltSize]);
        //        return _salt;
        //    }

        //    //做 hash
        //    public byte[] MakeHash(string password, byte[] _salt)
        //    {
        //        _hash = new Rfc2898DeriveBytes(password, _salt, 100000).GetBytes(HashSize);
        //        return _hash;
        //    }

        //    //把 salt + hash 接在一起存資料庫, 所以我有個 pattern 這樣 salt 就不須存進去資料庫 解碼的時候再解回來就好
        //    public byte[] TotalHashByte(byte[] _hash, byte[] _salt)
        //    {
        //        byte[] hashBytes = new byte[36];
        //        Array.Copy(_salt, 0, hashBytes, 0, SaltSize); //要拿來複製的array A, 從 A 第幾個index複製, 要複製到的array B, 從 B 第幾個index開始放, 要複製多長的A 到 B
        //        Array.Copy(_hash, 0, hashBytes, SaltSize, HashSize);
        //        return hashBytes;
        //    }

        //    // byte[] 轉 string 存資料庫
        //    public string HashBytesToString(byte[] hashBytes)
        //    {
        //        string savedPasswordHash = Convert.ToBase64String(hashBytes);
        //        return savedPasswordHash;
        //    }

        //    public bool VerifyPasswordWithHash(MemberLoginViewModel memberLoginInfo)
        //    {
        //        //找會員
        //        MemberViewModel memberInfo = _memberservice.GetMember(x => x.MemberRegEmail == memberLoginInfo.Email);

        //        //找會員hash字串
        //        string savedPasswordwithHash = memberInfo.Hash;

        //        //轉成 byte[]  這個是原本資料庫裡的 hash
        //        byte[] originalHashBytes = Convert.FromBase64String(savedPasswordwithHash);

        //        //先宣告 salt
        //        byte[] salt = new byte[16];

        //        //然後得到原本的 salt
        //        Array.Copy(originalHashBytes, 0, salt, 0, 16);

        //        //計算使用者傳進來的 hash
        //        var pbkdf2 = new Rfc2898DeriveBytes(memberLoginInfo.Password, salt, HashIter);

        //        //轉成 byte[]
        //        byte[] hash = pbkdf2.GetBytes(20);

        //        //比較 使用者傳進來的hash pbkdf2 和 originalHashBytes
        //        for (int i = 0; i < 20; i++)
        //        {
        //            if (originalHashBytes[i + 16] != hash[i])
        //            {
        //                return false;
        //            }
        //        }
        //        return true;
        //    }
    }
}