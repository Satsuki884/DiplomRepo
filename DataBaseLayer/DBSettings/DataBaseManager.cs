namespace DataBaseLayer.DBSettings
{
    internal static class DataBaseManager
    {
        private static string _connectionString;
        private static string _defaultConnectionString = "Data Source=127.0.0.1,3306;" +
                                                        "Database=diplom;" +
                                                        "User id=root;" +
                                                        "Password=1111;";
        internal static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    return _defaultConnectionString;
                }
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }
        internal static string PathToSave { get; set; }
     

        public static void SetConnectionString(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
    }
}
