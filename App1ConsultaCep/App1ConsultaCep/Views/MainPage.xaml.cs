using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App1ConsultaCep.Models;
using App1ConsultaCep.Services;

namespace App1ConsultaCep.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            Botao.Clicked += BuscarCEP;

            //Logo.Source

            //MasterBehavior = MasterBehavior.Popover;

            //MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        private void BuscarCEP(object sender, EventArgs args)
        {

             string cep = Cep.Text.Trim();

            if (isValidCep(cep))
            {
                try
                {
                    Endereco end = ViaCEPService.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        Resultado.Text = String.Format("Endereco: " + end.Logradouro
                       + " " + end.Bairro + ", " + end.Localidade + ", " + end.UF + ", " + end.Cep);
                    }
                    else{
                      DisplayAlert("Erro", "O endereco nao foi encontrado para o CEP informado", "OK");  
                    }

                   
                }
                catch (Exception ex)
                {

                    DisplayAlert("Erro critico ", ex.Message, "OK");
                }

     
            }

    
        }

        private bool isValidCep(string cep)
        {
            bool valid = true;

            if(cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP invalido! O CEP deve conter 8 caracteres", "OK");

                valid = false;
            }

            int novoCep = 0;

            if (!int.TryParse(cep, out novoCep))
            {
                DisplayAlert("Erro", "CEP invalido! O CEP deve ser composto apenas por numeros", "OK");

                valid = false;
            }


            return valid;
        }

        
    }
}