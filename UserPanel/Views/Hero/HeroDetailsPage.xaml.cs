namespace UserPanel.Views.Hero;

public partial class HeroDetailsPage : ContentPage
{
    public HeroDetailsPage(UserPanel.Models.Hero hero)
    {
        InitializeComponent();
        BindingContext = hero;
    }
    // ���������� ����� �� ������ "�����"
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // ������������ �� ���������� ��������
    }
}