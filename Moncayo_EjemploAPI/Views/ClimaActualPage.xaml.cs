using Moncayo_EjemploAPI.Model;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Moncayo_EjemploAPI.Views;

public partial class ClimaActualPage : ContentPage
{
	public ClimaActualPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		string latitud = lat.Text;
		string longitud = lon.Text;

		if (Connectivity.NetworkAccess == NetworkAccess.Internet)
		{
			using (var client = new HttpClient())
			{
				string url = $"https://api.openweathermap.org/data/2.5/weather?lat="+latitud+"&lon="+longitud+"&appid=0e5c00cb18673328aae5e82ec1a0789d";
				var response = await client.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					var clima = JsonConvert.DeserializeObject<Rootobject>(json);

                    weatherlabel.Text = clima.weather[0].main;
					cityLabel.Text = clima.name;
					paisLabel.Text = clima.sys.country;
					
				}
						



			}

		}

    }
}