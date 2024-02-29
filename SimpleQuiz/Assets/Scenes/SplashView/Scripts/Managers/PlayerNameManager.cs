using System;
using System.Text;

namespace Assets.Scenes.SplashView.Scripts.Managers
{
    public class PlayerNameManager
    {
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string RandomizeName(int nameLength)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var random = new Random();
            for (int i = 0; i < nameLength; i++)
            {
                stringBuilder.Append(_chars[random.Next(_chars.Length)]);
            }
            return stringBuilder.ToString();
        }
    }
}