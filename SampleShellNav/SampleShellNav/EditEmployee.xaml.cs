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

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            var isDelete = await DisplayAlert("Konfirmasi", "Apakah data akan di delete?",
                "Yes", "No");
            if (isDelete)
            {
                try
                {
                    var deleteEmp = new Employee
                    {
                        EmpId = Convert.ToInt32(entryEmpID.Text)
                    };
                    App.DBUtils.DeleteEmployee(deleteEmp);
                    await DisplayAlert("Keterangan", "Berhasil Di Delete", "OK");
                    await Navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"Kesalahan: {ex.Message}","OK");
                }
            }
        }
    }
}