using EvaluacionNet.Bussines.interfaces.Calculo;
using EvaluacionNet.Entities;
using EvaluacionNet.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionNet.App.ViewModels.Pages
{
    public partial class InsertarCalculoViewModel : ObservableObject
    {
       private readonly ICalculoBussines _caluloBussines;
        public InsertarCalculoViewModel(ICalculoBussines caluloBussines)
        {
            _caluloBussines = caluloBussines;
        }

        [ObservableProperty]
        private string _usuario = "";

        [ObservableProperty]
        private int _limite = 0;

        [ObservableProperty]
        private string _mensaje = "";

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
    }
}
