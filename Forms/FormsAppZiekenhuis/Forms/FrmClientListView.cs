using FormsAppZiekenhuis.FieldChecks;
using System;
using System.Windows.Forms;
using Ziekenhuis.Business.Interfaces;
using Ziekenhuis.Model;
using FormsAppZiekenhuis.ConstantsAndEnums;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using FormsAppZiekenhuis.ViewModels;

namespace FormsAppZiekenhuis
{
    public partial class FrmClientListView : Form
    {
        readonly IClientManager _clientManager;
        readonly ICountryManager _countryManager;
        readonly IInvoiceManager _invoiceManager;
        readonly IConsultManager _consultManager;


        public FrmClientListView(IClientManager clientManager,
                                 ICountryManager countryManager,
                                 IInvoiceManager invoiceManager,
                                 IConsultManager consultManager)
        {
            InitializeComponent();
            _clientManager = clientManager;  
            _countryManager = countryManager;  
            _invoiceManager = invoiceManager;  
            _consultManager = consultManager;  
        }

        private void FrmClientListView_Load(object sender, EventArgs e)
        {

            var listClients = _clientManager.SelectAllClientsAdmin(out int nrClients);

            ListViewClienten.Items.Clear();
            foreach (var client in listClients)
            {
                var fullAddress = client.Street.Trim() + ' ' + client.HouseNumber + ' ' + client.City.Trim();
                var nrOfInvoices = _invoiceManager.NumberOfInvoicesPerClient(client.Id);
                var nrOfConsults = _consultManager.NumberOfConsultsPerClient(client.Id);

                var row = new string[]
                {
                    client.ClientNumber.ToString().PadLeft(6, '0'),
                    client.IsInsured.ToString(),
                    client.FirstName,
                    client.LastName,
                    nrOfConsults.ToString(),
                    nrOfInvoices.ToString(),
                    fullAddress,
                    client.AstrologyZodiacSign,
                    client.TypeOfSporter  
                };
                var listViewItem = new ListViewItem(row)
                {
                    Tag = client // plak onder water de hele client aan de rij
                };
                ListViewClienten.Items.Add(listViewItem);
            }

            // clear detail scherm

            ClearDetailView(); 

        }

        private void ClearDetailView()
        {
            LabelClientNumber2.Text = "";
            TextBoxFirstName.Text = "";
            TextBoxLastName.Text = "";
            SetOffErrMsg(); 
         }

        private void SetOffErrMsg()
        {
            LabelErrMsg.Visible = false;
            LabelErrorCode.Visible = false;
            TextBoxFirstName.ForeColor = Color.Black;
            TextBoxLastName.ForeColor = Color.Black;
            TextBoxInsured.ForeColor = Color.Black;
            TextBoxInsured.Focus(); 
        }

        private void SetOnErrMsg(ErrMsg errMsg)
        {
            LabelErrMsg.Visible = true;
            LabelErrMsg.Text = errMsg.ErrorMessage;
            LabelErrorCode.Visible = true;
            LabelErrorCode.Text = errMsg.ErrorId; 

        }

        private void ListViewClienten_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedClient =  (Client) ListViewClienten.SelectedItems[0].Tag; 
                if (selectedClient != null)
                {
                    switch (selectedClient.IsInsured)     
                    {
                        case true:
                            TextBoxInsured.Text = "J";  
                            break;
                            
                        case false:
                            TextBoxInsured.Text = "N";
                            break;
                    }
                    LabelClientNumber2.Text = selectedClient.ClientNumber.ToString().PadLeft(6, '0'); 
                    TextBoxFirstName.Text = selectedClient.FirstName;
                    TextBoxLastName.Text = selectedClient.LastName;
                    TextBoxZodiac.Text = selectedClient.AstrologyZodiacSign;

                    // Vul de comboBox met alle typen sporters:

                    ComboBoxSportType.Items.Clear();
                    // Haal alle enum waarden op 
                    List<SportType> lijstVanSportTypes = Enum.GetValues(typeof(SportType))
                        .Cast<SportType>()
                        .ToList();

                    ComboBoxSportType.ValueMember = "SportType"; // verwijst naar een prop in SportTypeVM
                    ComboBoxSportType.DisplayMember = "lineInComboBox"; // verwijst naar een prop in SportTypeVM

                    foreach (var sportType in lijstVanSportTypes)
                    {
                        var sportTypeVM = new SportTypeVM
                        {
                            SportType = sportType
                            //LineInComboBox wordt vanzelf gevuld, is Get Prop
                        };
                        ComboBoxSportType.Items.Add(sportTypeVM); 
                    };

                    // Zet de default waarde van de combo-box op het sportType van selectedClient
                    int index = (int) Enum.Parse(typeof(SportType), selectedClient.TypeOfSporter);

                    ComboBoxSportType.SelectedIndex = index; 

                }
            }
            catch (Exception)
            {
            }
        }

        private void ButtonUpdateClient_Click(object sender, EventArgs e)
        {
            ErrMsg errMsg;
            SetOffErrMsg();

            errMsg = Check.CheckField(FieldName.IsInsured, TextBoxInsured.Text);
            if (errMsg.ErrorId != "00")
            {
                SetOnErrMsg(errMsg);
                TextBoxInsured.Focus();
                TextBoxInsured.ForeColor = Color.Red;
                return;
            }

            errMsg = Check.CheckField(FieldName.FirstName, TextBoxFirstName.Text);
            if (errMsg.ErrorId != "00")
            {
                SetOnErrMsg(errMsg);
                TextBoxFirstName.Focus();
                TextBoxFirstName.ForeColor = Color.Red; 
                return; 
            }

            errMsg = Check.CheckField(FieldName.LastName, TextBoxLastName.Text);
            if (errMsg.ErrorId != "00")
            {
                SetOnErrMsg(errMsg);
                TextBoxLastName.Focus();
                TextBoxLastName.ForeColor = Color.Red;
                return;
            }

            // Sterrenbeeld moet kloppen:

            errMsg = Check.CheckField(FieldName.Zodiac, TextBoxZodiac.Text);
            if (errMsg.ErrorId != "00")
            {
                SetOnErrMsg(errMsg);
                TextBoxLastName.Focus();
                TextBoxLastName.ForeColor = Color.Red;
                return;
            }

        }
    }
}
