namespace Sambal.AppCode
{
    public interface IClsSession
    {
        void SetString(string key, string value);
        string GetString(string key);

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
            return (int)_httpContextAccessor.HttpContext.Session.GetInt32(key);
        }

        public string GetString(string key)
        {
            return _httpContextAccessor.HttpContext.Session.GetString(key);
        }

        public void Remove(string key)
        {
            _httpContextAccessor.HttpContext.Session.Remove(key);
        }

        public void SetInt32(string key, int value)
        {
            _httpContextAccessor.HttpContext.Session.SetInt32(key, value);
        }

        public void SetString(string key, string value)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, value);
        }
    }
}
