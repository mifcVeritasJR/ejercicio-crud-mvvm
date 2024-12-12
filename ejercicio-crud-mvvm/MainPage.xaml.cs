public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new ProveedorViewModel();
    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }
}