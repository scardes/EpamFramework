namespace EpamFramework.BusinessObjects
{
    class User
    {
        private string username;
        private string password;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string getUsername()
        {
            return username;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        public string getPassword()
        {
            return password;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }
    }
}
