using SampleShellNav.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleShellNav
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowEmployeeServicesPage : ContentPage
    {
        private EmployeeServices _empService;
        public ShowEmployeeServicesPage()
        {
            InitializeComponent();
            _empService = new EmployeeServices();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            lvEmployee.ItemsSource = await _empService.GetData();
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEmployeeServicesPage());
        }
    }
}