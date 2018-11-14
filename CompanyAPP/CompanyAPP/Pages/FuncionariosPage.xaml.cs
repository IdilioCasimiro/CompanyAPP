using CompanyAPP.Client;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CompanyAPP.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FuncionariosPage : ContentPage
    {
        private FuncionariosClient funcionarios = new FuncionariosClient();
        public FuncionariosPage()
        {
            InitializeComponent();
            Initialize();

        }

        public async void Initialize()
        {
            //HttpClient httpClient = new HttpClient();
            //var response = await httpClient.GetStringAsync("https://localhost:44337/api/todo");
            ////var obj = JsonConvert.DeserializeObject<List<TodoItem>>(response);

            await funcionarios.GetAsync();
        }
    }

    class TodoItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
    }
}