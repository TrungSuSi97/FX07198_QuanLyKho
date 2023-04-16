namespace TPH.Lab.Middleware.Helpers
{
    public class LoginSessionInfo
    {
        /// <summary>
        /// 	Logger
        /// </summary>

        public LoginSessionInfo()
        {

        }
        private static LoginSessionInfo _sessionInfo = null;

        public string LoginUserId { get; set; }

        public string DepartmentId { get; set; }

        public string RoomId { get; set; }

        public string TableId { get; set; }

        public static LoginSessionInfo GetInstance()
        {
            if (_sessionInfo == null)
            {
                _sessionInfo = new LoginSessionInfo();
            }

            return _sessionInfo;
        }
    }
}
