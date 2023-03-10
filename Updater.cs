using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows;

namespace Terra_Telemetry_App
{
    public class Updater
    {
        private const string RELEASES_API_URL = "https://api.github.com/repos/RELMYMathieu/Terra-Telemetry-App/releases/latest";

        private readonly string _currentVersion;

        public Updater(string currentVersion)
        {
            _currentVersion = currentVersion;
        }

        public async Task CheckForUpdatesAsync()
        {
            string latestVersion = await GetLatestVersionAsync();

            if (_currentVersion != latestVersion)
            {
                MessageBoxResult result = MessageBox.Show($"An update is available! Current version: {_currentVersion}, Latest version: {latestVersion}. Do you want to download the latest version?", "Update Available", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    // TODO: Download and install the latest version
                }
            }
            else
            {
                MessageBox.Show($"Terra Telemetry App is up-to-date. Version: {_currentVersion}", "Up-to-date");
            }
        }

        private async Task<string> GetLatestVersionAsync()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

                var response = await client.GetAsync(RELEASES_API_URL);
                var content = await response.Content.ReadAsStringAsync();
                dynamic release = JsonConvert.DeserializeObject(content);

                return release.tag_name;
            }
        }
    }
}
