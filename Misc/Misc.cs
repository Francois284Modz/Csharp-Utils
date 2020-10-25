    
   
    public void Notification(string title, string message,int time)
        {
            NotifyIcon notifyIcon = new NotifyIcon();
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = message;
            notifyIcon.Icon = SystemIcons.Application;
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(time);
        }
        
    
    public static string getTimestamp(string value)
        {
            var dateNow = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            var expireTime = new DateTimeOffset(Convert.ToDateTime(value + "  23:59:00")).ToUnixTimeSeconds();

            if (dateNow > expireTime)
            {
                return "Licence expired";
            }
            else
            {
                var diff = expireTime - dateNow;
                decimal d = diff / (60 * 60 * 24);
                var days = Math.Round(d);

                decimal h = (diff - days * 60 * 60 * 24) / (60 * 60);
                var hours = Math.Round(h);

                return "time left: " + days + " days " + hours + " hours";
            }
        }
        
        
        public static Random random = new Random((int)DateTime.Now.Ticks);
        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
