﻿using SampleShellNav.Models;
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
    public partial class ShowEmployee : ContentPage
    {
        public ShowEmployee()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            lvEmployee.ItemsSource = App.DBUtils.GetAllEmployee();
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEmployeePage());
        }

        private async void lvEmployee_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var empDetail = (Employee)e.SelectedItem;

            EditEmployee editEmp = new EditEmployee();
            editEmp.BindingContext = empDetail;
            await Navigation.PushAsync(editEmp);
        }
    }
}