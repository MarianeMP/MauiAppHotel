
namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;
	
    public ContratacaoHospedagem()
    {
        InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);
    }

   // Ação ao clicar no botão Sobre
    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Sobre());

        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }

    }


    // Ação ao clicar no botão Avançar
    private void Button_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new HospedagemContratada());

        } catch(Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }

    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_ckeckin = elemento.Date;

        dtpck_checkout.MinimumDate = data_selecionada_ckeckin.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada_ckeckin.AddMonths(6);
    }
}