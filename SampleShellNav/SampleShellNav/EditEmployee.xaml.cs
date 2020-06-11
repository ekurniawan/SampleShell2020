using SampleShellNav.Models;
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
    public partial class EditEmployee : ContentPage
    {
        public EditEmployee()
        {
            InitializeComponent();
        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            var editData = new Employee
            {
                EmpId = Convert.ToInt32(entryEmpID.Text),
                EmpName = entryEmpName.Text,
                Designation = entryDesignation.Text,
                Department = entryDepartment.Text,
                Qualification = entryQualification.Text,
                BirthDate = dtBirthdate.Date
            };
            try
            {
                App.DBUtils.EditEmployee(editData);
                await DisplayAlert("Keterangan", $"Data berhasil diedit", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"{ex.Message}", "OK");
            }
        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {

        }
    }
}