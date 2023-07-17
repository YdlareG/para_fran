﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Loteria.Presentacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mainmaster : MasterDetailPage
    {
        public mainmaster()
        {
            InitializeComponent();
            this.Master = new Master();
            this.Detail = new NavigationPage(new Detail());

            App.MasterDet = this;
        }
    }
}