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
using System.Text.RegularExpressions;

namespace FormsAppZiekenhuis
{
    public partial class FrmClientListView : Form
    {
        readonly IClientManager _clientManager;
        readonly ICountryManager _countryManager;
        readonly IInvoiceManager _invoiceManager;
        readonly IConsultManager _consultManager;

        private Client _selectedClient; 

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
            TextBoxInsured.Text = "";
            TextBoxZodiac.Text = "";
            ComboBoxSportType.Items.Clear();
            ComboBoxSportType.Text = ""; 
            SetOffErrMsg(); 
         }

        private void SetOffErrMsg()
        {
            LabelErrMsg.Visible = false;
            LabelErrorCode.Visible = false;
            TextBoxFirstName.ForeColor = Color.Black;
            TextBoxLastName.ForeColor = Color.Black;
            TextBoxInsured.ForeColor = Color.Black;
            TextBoxZodiac.ForeColor = Color.Black;
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
                _selectedClient =  (Client) ListViewClienten.SelectedItems[0].Tag; 
                if (_selectedClient != null)
                {
                    switch (_selectedClient.IsInsured)     
                    {
                        case true:
                            TextBoxInsured.Text = "J";  
                            break;
                            
                        case false:
                            TextBoxInsured.Text = "N";
                            break;
                    }
                    LabelClientNumber2.Text = _selectedClient.ClientNumber.ToString().PadLeft(6, '0'); 
                    TextBoxFirstName.Text = _selectedClient.FirstName;
                    TextBoxLastName.Text = _selectedClient.LastName;
                    TextBoxZodiac.Text = _selectedClient.AstrologyZodiacSign;

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
                    int index = (int) Enum.Parse(typeof(SportType), _selectedClient.TypeOfSporter);

                    ComboBoxSportType.SelectedIndex = index; 
                }
            }
            catch (Exception)
            {
            }
        }

        private void ButtonUpdateClient_Click(object sender, EventArgs e)
        {
            if (_selectedClient != null)
            {
                SetOffErrMsg();
                ReformatAllFields();
                var success = CheckAllFields();
                if (success)
                {
                    UpdateClient();
                    // reload
                    FrmClientListView_Load(null, null);
                }
                // Bij geen succes, geen reload
            }
        }

        private void UpdateClient()
        {
            switch (TextBoxInsured.Text)
            {
                case "J":
                    _selectedClient.IsInsured = true;
                    break;
                case "N":
                    _selectedClient.IsInsured = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(); 
            }

            _selectedClient.FirstName = TextBoxFirstName.Text;
            _selectedClient.LastName = TextBoxLastName.Text;
            _selectedClient.AstrologyZodiacSign = TextBoxZodiac.Text;

            var sportTypeVM = (SportTypeVM) ComboBoxSportType.SelectedItem;
            _selectedClient.TypeOfSporter = sportTypeVM.SportType.ToString();
            _clientManager.UpdateClient(_selectedClient);
        }

        private void ReformatAllFields()
        {
            TextBoxFirstName.Text = TextBoxFirstName.Text.Trim(); 
            TextBoxLastName.Text = TextBoxLastName.Text.Trim();
            TextBoxInsured.Text = TextBoxInsured.Text.Trim();
            TextBoxZodiac.Text = TextBoxZodiac.Text.Trim();

            // Haal overbodige spaties weg, en haal tussenliggende spaties weg, en maakt van eerste karakter een hoofdletter
            TextBoxFirstName.Text = ReformatTextString(TextBoxFirstName.Text); 
            TextBoxLastName.Text = ReformatTextString(TextBoxLastName.Text);
            TextBoxZodiac.Text = ReformatTextString(TextBoxZodiac.Text);
            TextBoxInsured.Text = ReformatTextString(TextBoxInsured.Text); 
        }

        private string ReformatTextString(string text)
        {
            // Remove leading and trailing spaces
            var result = text.Trim();
            // Vervang alle tussenliggende meervoudige spaces (2 of meer) door één space
            result = Regex.Replace(result, " {2,}", " ");

            // Maak van 1e karakter een hoofdletter 

            string firstChar = "";

            if (result.Length > 0)
            {
                firstChar = result[0].ToString().ToUpper();
            }

            if (result.Length > 1)
            {
                result = firstChar.ToString() + result.Substring(1);
            }
            return result; 
        }

        private bool CheckAllFields()
        {
            ErrMsg errMsg;

            errMsg = Check.CheckField(FieldName.IsInsured, TextBoxInsured.Text);
            if (errMsg.ErrorId != "00")
            {
                SetOnErrMsg(errMsg);
                TextBoxInsured.Focus();
                TextBoxInsured.ForeColor = Color.Red;
                return false; 
            }

            errMsg = Check.CheckField(FieldName.FirstName, TextBoxFirstName.Text);
            if (errMsg.ErrorId != "00")
            {
                SetOnErrMsg(errMsg);
                TextBoxFirstName.Focus();
                TextBoxFirstName.ForeColor = Color.Red;
                return false;
            }

            errMsg = Check.CheckField(FieldName.LastName, TextBoxLastName.Text);
            if (errMsg.ErrorId != "00")
            {
                SetOnErrMsg(errMsg);
                TextBoxLastName.Focus();
                TextBoxLastName.ForeColor = Color.Red;
                return false;
            }

            // Sterrenbeeld moet kloppen:

            errMsg = Check.CheckField(FieldName.Zodiac, TextBoxZodiac.Text);
            if (errMsg.ErrorId != "00")
            {
                SetOnErrMsg(errMsg);
                TextBoxZodiac.Focus();
                TextBoxZodiac.ForeColor = Color.Red;
                return false;
            }

            return true; 
        }
    }
}
