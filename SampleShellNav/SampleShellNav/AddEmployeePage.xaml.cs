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
    public partial class AddEmployeePage : ContentPage
    {
        public AddEmployeePage()
        {
            InitializeComponent();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            var newEmp = new Employee
            {
                EmpName = entryEmpName.Text,
                Department = entryDepartment.Text,
                Designation = entryDesignation.Text,
                Qualification = entryQualification.Text,
                BirthDate = dtBirthdate.Date
            };

            try
            {
                App.DBUtils.InsertEmployee(newEmp);
                await DisplayAlert("Keterangan", $"Data {newEmp.EmpName} berhasil ditambahkan", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
            /*var tgl = $"{dtBirthdate.Date.Year}-{dtBirthdate.Date.Month}-{dtBirthdate.Date.Day}";
            DisplayAlert("Tanggal"
                ,tgl,"OK");*/
        }
    }
}