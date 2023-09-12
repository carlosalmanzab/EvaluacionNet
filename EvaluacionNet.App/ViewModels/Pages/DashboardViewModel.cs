// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using EvaluacionNet.Bussines.interfaces.Calculo;
using EvaluacionNet.Entities;
using EvaluacionNet.Util;

namespace EvaluacionNet.App.ViewModels.Pages
{
    public partial class DashboardViewModel : ObservableObject
    {
        [ObservableProperty]
        private int _counter = 0;

        [ObservableProperty]
        private string _usuario = "";

        [ObservableProperty]
        private int _limite = 0;

        [ObservableProperty]
        private string _mensaje = "";

        private readonly ICalculoBussines _caluloBussines;

        public DashboardViewModel(ICalculoBussines calculoBussines) 
        {
            _caluloBussines = calculoBussines;
        }

        [RelayCommand]
        private async void onInsertar()
        {
            ResultResponse<CalculoModel> result = await _caluloBussines.InsertarCalculo(_usuario, _limite);
            if (result.Error)
            {
                _mensaje = result.ErrorMessage;
            }
            else
            {
                _mensaje = "Ha sido guardado Correctamente";
            }
        }

        [RelayCommand]
        private void OnCounterIncrement()
        {
            Counter++;
        }
    }
}
