namespace DataBaseLayer.DBSettings
{
    internal static class DataBaseManager
    {
        private static string _connectionString;
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
        private static string _defaultConnectionString = "root@127.0.0.1:3306";

        public static void SetConnectionString(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }
    }
}
