using SampleShellNav.Models;
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
    public partial class EditEmployeeServicesPage : ContentPage
    {
        private EmployeeServices _empServices;
        public EditEmployeeServicesPage()
        {
            InitializeComponent();
            _empServices = new EmployeeServices();
        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            try
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
                await _empServices.UpdateData(editData);
                await DisplayAlert("Keterangan", "Data berhasil diedit", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await DisplayAlert("Konfirmasi", $"Apakah anda yakin akan mendelete data?", "OK", "Cancel");
                if (result)
                {
                    await _empServices.DeleteData(entryEmpID.Text);
                    await DisplayAlert("Keterangan", "Data berhasil di delete", "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}