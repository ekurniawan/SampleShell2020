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
    public partial class AddEmployeeServicesPage : ContentPage
    {
        private EmployeeServices _empServices;
        public AddEmployeeServicesPage()
        {
            InitializeComponent();
            _empServices = new EmployeeServices();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                var newEmp = new Employee
                {
                    EmpName = entryEmpName.Text,
                    Department = entryDepartment.Text,
                    Designation = entryDesignation.Text,
                    Qualification = entryQualification.Text,
                    BirthDate = dtBirthdate.Date
                };
                await _empServices.InsertData(newEmp);
                await DisplayAlert("Keterangan", "Data berhasil ditambah", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Kesalahan", ex.Message, "OK");
            }
        }
    }
}