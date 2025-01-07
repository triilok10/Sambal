using Microsoft.AspNetCore.Http;

namespace Sambal.AppCode
{
    public interface IClsSession
    {
        void SetString(string key, string value);
        string GetString(string key);

        void SetBool(string key, bool value);
        bool GetBool(string key);
        void SetInt32(string key, int value);
        int GetInt32(string key);
        void Remove(string key);
    }

    public class ClsSession : IClsSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClsSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetInt32(string key)
        {
            return _httpContextAccessor.HttpContext.Session.GetInt32(key) ?? 0; 
        }

        public string GetString(string key)
        {
            return _httpContextAccessor.HttpContext.Session.GetString(key);
        }

        public bool GetBool(string key)
        {
            return _httpContextAccessor.HttpContext.Session.GetInt32(key) == 1;
        }

        public void Remove(string key)
        {
            _httpContextAccessor.HttpContext.Session.Remove(key);
        }

        public void SetInt32(string key, int value)
        {
            _httpContextAccessor.HttpContext.Session.SetInt32(key, value);
        }

        public void SetBool(string key, bool value)
        {
            // Store boolean as an integer (1 for true, 0 for false)
            _httpContextAccessor.HttpContext.Session.SetInt32(key, value ? 1 : 0);
        }

        public void SetString(string key, string value)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, value);
        }
    }
}
