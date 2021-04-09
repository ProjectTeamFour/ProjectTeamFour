using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTeamFour.Repositories;
using ProjectTeamFour.Models;
using System.Data.Entity;
using System.Net.Http;
using ProjectTeamFour.ViewModels;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace ProjectTeamFour.Service
{
    public class MemberService
    {
        //SaltSize 鹽長 HashSize Hash長 HashIter 迭代
        private const int SaltSize = 16, HashSize = 20, HashIter = 100000;

        //private PasswordService _passwordservice;
        private DbContext _context;

        private BaseRepository _repository;
        private byte[] _salt, _hash;

        public MemberService()
        {
            //_passwordservice = new PasswordService();
            _context = new ProjectContext();
            _repository = new BaseRepository(_context);
        }

        public object Session { get; private set; }

        //byLambda搜尋
        public MemberViewModel GetMember(Expression<Func<Member, bool>> KeySelector)
        {
            var entity = _repository.GetAll<Member>().FirstOrDefault(KeySelector);
            if (entity != null)
            {
                var viewModel = new MemberViewModel
                {
                    MemberId = entity.MemberId,
                    MemberName = entity.MemberName,
                    MemberTeamName = entity.MemberTeamName,
                    MemberAccount = entity.MemberAccount,
                    //MemberPassword = entity.MemberPassword,
                    MemberAddress = entity.MemberAddress,
                    MemberPhone = entity.MemberPhone,
                    MemberRegEmail = entity.MemberRegEmail,
                    MemberConEmail = entity.MemberConEmail,
                    Gender = entity.Gender,
                    MemberBirth = entity.MemberBirth,
                    AboutMe = entity.AboutMe,
                    ProfileImgUrl = entity.ProfileImgUrl,
                    MemberWebsite = entity.MemberWebsite,
                    MemberMessage = entity.MemberMessage,
                    Permission = entity.Permission,
                    Hash = entity.Hash,
                    Salt = entity.Salt
                };
                return viewModel;
            }
            return null;
        }

        //全部
        public MemberListViewModel GetMembers()
        {
            var listViewmodel = new MemberListViewModel()
            {
                Items = new List<MemberViewModel>()
            };
            foreach (var entity in _repository.GetAll<Member>())
            {
                var viewModel = new MemberViewModel
                {
                    MemberId = entity.MemberId,
                    MemberName = entity.MemberName,
                    MemberTeamName = entity.MemberTeamName,
                    MemberAccount = entity.MemberAccount,
                    //MemberPassword = entity.MemberPassword,
                    MemberAddress = entity.MemberAddress,
                    MemberPhone = entity.MemberPhone,
                    MemberRegEmail = entity.MemberRegEmail,
                    MemberConEmail = entity.MemberConEmail,
                    Gender = entity.Gender,
                    MemberBirth = entity.MemberBirth,
                    AboutMe = entity.AboutMe,
                    ProfileImgUrl = entity.ProfileImgUrl,
                    MemberWebsite = entity.MemberWebsite,
                    MemberMessage = entity.MemberMessage,
                    Permission = entity.Permission,
                    Hash = entity.Hash,
                    Salt = entity.Salt
                };
                listViewmodel.Items.Add(viewModel);
            }
            return listViewmodel;
        }

        //新增
        public OperationResult Create(MemberViewModel input)
        {
            //做hash
            byte[] _salt = MakeSalt();
            byte[] _hash = MakeHash(input.MemberPassword, _salt);
            byte[] _totalHashByte = TotalHashByte(_hash, _salt);
            string savedPasswordHash = HashBytesToString(_totalHashByte);
            string savedSaltString = SaltToString(_salt);

            var result = new OperationResult();
            try
            {
                Member entity = new Member
                {
                    MemberId = 25,
                    MemberName = input.MemberName,
                    MemberTeamName = input.MemberTeamName,
                    MemberAccount = input.MemberAccount,
                    //MemberPassword = input.MemberPassword,
                    MemberAddress = input.MemberAddress,
                    MemberPhone = input.MemberPhone,
                    MemberRegEmail = input.MemberRegEmail,
                    MemberConEmail = input.MemberConEmail,
                    Gender = input.Gender,
                    MemberBirth = input.MemberBirth,
                    AboutMe = input.AboutMe,
                    ProfileImgUrl = input.ProfileImgUrl,
                    MemberWebsite = input.MemberWebsite,
                    MemberMessage = input.MemberMessage,
                    Permission = input.Permission,
                    Hash = savedPasswordHash,
                    Salt = savedSaltString,
                };
                _repository.Create(entity);
                result.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.DateTime = DateTime.Now;
                result.IsSuccessful = false;
            }
            return result;
        }

        //修改
        public OperationResult Update(EditMemberViewModel input)
        {
            var result = new OperationResult();
            try
            {
                Member entity = _repository.GetAll<Member>().FirstOrDefault(m => m.MemberId == input.MemberId);
                entity.MemberName = input.MemberName;
                entity.MemberConEmail = input.MemberConEmail;
                if (input.Gender != "請選擇性別")
                {
                    entity.Gender = input.Gender;
                }
                //entity.MemberBirth = input.MemberBirth;
                entity.AboutMe = input.AboutMe;
                entity.ProfileImgUrl = input.ProfileImgUrl;
                entity.MemberWebsite = input.MemberWebsite;
                entity.ProfileImgUrl = input.ProfileImgUrl;
                _repository.Update(entity);
                result.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                //result.Member
                result.DateTime = DateTime.Now;
                result.Exception = ex;
                result.IsSuccessful = false;
            }
            return result;
        }

        public OperationResult Delete(int MemberId)
        {
            var result = new OperationResult();
            try
            {
                Member entity = _repository.GetAll<Member>().FirstOrDefault(m => m.MemberId == MemberId);
                _repository.Delete(entity);
            }
            catch (Exception ex)
            {
                result.DateTime = DateTime.Now;
                result.Exception = ex;
                result.IsSuccessful = false;
            }
            return result;
        }

        public int ReturnLoginnerId()
        {
            var session = HttpContext.Current.Session;
            if (session["Member"] == null)
            {
                return 0;
            }
            return ((MemberViewModel)session["Member"]).MemberId;
        }

        public void Relogin()
        {
            var session = HttpContext.Current.Session;
            int id = ((MemberViewModel)session["Member"]).MemberId;
            session["Member"] = GetMember(p => p.MemberId == id);
        }

        public void Reloging(int id)
        {
            var session = HttpContext.Current.Session;
            //id = ((MemberViewModel)session["Member"]).MemberId;
            session["Member"] = GetMember(p => p.MemberId == id);
        }

        public OperationResult ResetPassWord(MemberViewModel input)
        {
            var result = new OperationResult();
            try
            {
                Member entity = _repository.GetAll<Member>().FirstOrDefault(m => m.MemberId == input.MemberId);

                //做hash
                byte[] _salt = MakeSalt();
                byte[] _hash = MakeHash(input.MemberPassword, _salt);
                byte[] _totalHashByte = TotalHashByte(_hash, _salt);
                string savedPasswordHash = HashBytesToString(_totalHashByte);
                string savedSaltString = SaltToString(_salt);
                entity.Hash = savedPasswordHash;
                entity.Salt = savedSaltString;

                _repository.Update(entity);
                result.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                //result.Member
                result.DateTime = DateTime.Now;
                result.Exception = ex;
                result.IsSuccessful = false;
            }
            return result;
        }

        //做 salt
        public byte[] MakeSalt()
        {
            new RNGCryptoServiceProvider().GetBytes(_salt = new byte[SaltSize]);
            return _salt;
        }

        public string SaltToString(byte[] _salt)
        {
            string saltString = Convert.ToBase64String(_salt);
            return saltString;
        }

        //做 hash
        public byte[] MakeHash(string password, byte[] _salt)
        {
            _hash = new Rfc2898DeriveBytes(password, _salt, 100000).GetBytes(HashSize);
            return _hash;
        }

        //把 salt + hash 接在一起存資料庫, 所以我有個 pattern 這樣 salt 就不須存進去資料庫 解碼的時候再解回來就好
        public byte[] TotalHashByte(byte[] _hash, byte[] _salt)
        {
            byte[] hashBytes = new byte[36];
            Array.Copy(_salt, 0, hashBytes, 0, SaltSize); //要拿來複製的array A, 從 A 第幾個index複製, 要複製到的array B, 從 B 第幾個index開始放, 要複製多長的A 到 B
            Array.Copy(_hash, 0, hashBytes, SaltSize, HashSize);
            return hashBytes;
        }

        // byte[] 轉 string 存資料庫
        public string HashBytesToString(byte[] hashBytes)
        {
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        public bool VerifyPasswordWithHash(MemberViewModel memberLoginInfo)
        {
            //找會員
            MemberViewModel memberInfo = GetMember(x => x.MemberRegEmail == memberLoginInfo.MemberRegEmail);

            if (memberInfo == null)
            {
                return false;
            }

            //找會員hash字串
            string savedPasswordwithHash = memberInfo.Hash;  //7vfJ9hbD4S+FtmFUKNCDmaGxCn2pNuxRRzS8NZRI1VmfjnZ3

            //轉成 byte[]  這個是原本資料庫裡的 hash
            byte[] originalHashBytes = Convert.FromBase64String(savedPasswordwithHash);

            byte[] originalSalt = Convert.FromBase64String(memberInfo.Salt);

            ////先宣告 salt
            //byte[] salt = new byte[16];

            ////然後得到原本的 salt
            //Array.Copy(originalHashBytes, 0, salt, 0, 16);

            //計算使用者傳進來的 hash
            var pbkdf2 = new Rfc2898DeriveBytes(memberLoginInfo.MemberPassword, originalSalt, HashIter);

            //轉成 byte[]
            byte[] hash = pbkdf2.GetBytes(20);

            //比較 使用者傳進來的hash pbkdf2 和 originalHashBytes
            for (int i = 0; i < 20; i++)
            {
                if (originalHashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<OperationResult> GetFacebookInfo(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                var or = new OperationResult();
                try
                {
                    var getUserInfoUrl = "https://graph.facebook.com/me?access_token=";
                    getUserInfoUrl += token;

                    HttpResponseMessage userInforesponse = await client.GetAsync(getUserInfoUrl);
                    userInforesponse.EnsureSuccessStatusCode();

                    var userInfoResponseBody = await userInforesponse.Content.ReadAsStringAsync();

                    or.IsSuccessful = true;
                    or.MessageInfo = userInfoResponseBody;
                }
                catch (Exception ex)
                {
                    or.IsSuccessful = false;
                    or.Exception = ex;
                    or.DateTime = new DateTime();
                    or.MessageInfo = "錯誤發生";
                }
                return or;
            }
        }

        public async Task<OperationResult> GetGoogleInfo(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                var or = new OperationResult();
                try
                {
                    var url = $"https://oauth2.googleapis.com/tokeninfo?id_token={token}";
                    client.Timeout = TimeSpan.FromSeconds(30);
                    HttpResponseMessage response = await client.GetAsync(url); //發送Get 請求
                    response.EnsureSuccessStatusCode();

                    var responsebody = await response.Content.ReadAsStringAsync();

                    or.IsSuccessful = true;
                    or.MessageInfo = responsebody;
                }
                catch (Exception ex)
                {
                    or.IsSuccessful = false;
                    or.Exception = ex;
                    or.MessageInfo = "發生錯誤";
                }
                return or;
            }
        }

        public OperationResult SocialAccountRegisterCreate(string name, string email, string socialPlatform, string imgUrl)
        {
            var result = new OperationResult();
            try
            {
                Member entity = new Member
                {
                    MemberId = 25,
                    MemberName = name,
                    MemberRegEmail = email,
                    MemberBirth = DateTime.ParseExact("19970101", "yyyyMMdd", null),
                    Permission = 1,
                    IsThirdParty = socialPlatform,
                    ProfileImgUrl = imgUrl,
                };
                _repository.Create(entity);
                result.IsSuccessful = true;
                result.MessageInfo = entity.MemberRegEmail;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.DateTime = DateTime.Now;
                result.IsSuccessful = false;
                result.MessageInfo = "拿email失敗";
            }
            return result;
        }

        public bool IsSocialAccountRegister(string email, string socailPlatform)
        {
            var member = _repository.GetAll<Member>().FirstOrDefault(x => x.MemberRegEmail == email && x.IsThirdParty == socailPlatform);

            if (member != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Member GetUser(string email, string socailPlatform)
        {
            return _repository.GetAll<Member>().FirstOrDefault(x => x.MemberRegEmail == email && x.IsThirdParty == socailPlatform);
        }
    }
}