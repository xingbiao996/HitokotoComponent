using System.Net.Http;
using System.Threading.Tasks;
using ClassIsland.Core.Controls;
using System.Windows;
using ClassIsland.Core.Abstractions.Controls;
using ClassIsland.Core.Attributes;
using MaterialDesignThemes.Wpf;

namespace HitokotoComponent
{
    [ComponentInfo(
            "3DFE17BA-92D3-9E14-F5CA-CC9EE40C5F58",
            "一言",
            PackIconKind.CalendarOutline,
            "在主界面显示一言。"
        )]
    public partial class HitokotoControl : ComponentBase
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public HitokotoControl()
        {
            InitializeComponent();
            LoadHitokotoAsync();
        }

        private async void LoadHitokotoAsync()
        {
            try
            {
                var result = await _httpClient.GetStringAsync("https://v1.hitokoto.cn/?encode=text");
                Dispatcher.Invoke(() => HitokotoText.Text = result);
            }
            catch (HttpRequestException)
            {
                Dispatcher.Invoke(() => HitokotoText.Text = "加载失败");
            }
        }
    }
}